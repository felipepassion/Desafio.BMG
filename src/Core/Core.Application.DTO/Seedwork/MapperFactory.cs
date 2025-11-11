using AutoMapper;
using System.Reflection;

namespace Bmg.Desafio.Core.Application.DTO.Seedwork
{
    public static class MapperFactory
    {
        static Mapper? _mapper;
        static List<Profile?>? _profiles { get; set; }
        private static readonly object _setupLock = new();

        public static Mapper Mapper { get { return _mapper ?? throw new Exception("Mapper Not Initialized"); } }

        public static void Setup(string nmspc)
        {
            // Ensure only one thread configures the mapper at a time
            lock (_setupLock)
            {
                _profiles ??= new List<Profile?>();

                // Take a snapshot of loaded assemblies to avoid collection modified during enumeration
                var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray();

                // Safely get all types from all assemblies
                var allTypes = assemblies
                    .SelectMany(a =>
                    {
                        try { return a.GetTypes(); }
                        catch (ReflectionTypeLoadException ex) { return ex.Types.Where(t => t != null)!; }
                    })
                    .Where(t => t != null)
                    .ToArray();

                // Find Profile types matching the namespace filter
                var profilesFound = allTypes
                    .Where(t => t!.Namespace != null
                                && typeof(Profile).IsAssignableFrom(t)
                                && t! != typeof(Profile)
                                && t!.Namespace!.Contains(nmspc))
                    .Distinct()
                    .Select(t => Activator.CreateInstance(t!) as Profile ?? throw new ArgumentNullException(nameof(t)))
                    .ToArray();

                // Add only new profiles (avoid duplicates by type)
                var existingTypes = _profiles.Select(p => p!.GetType()).ToHashSet();
                foreach (var p in profilesFound)
                {
                    if (!existingTypes.Contains(p.GetType()))
                        _profiles.Add(p);
                }

                // Create a snapshot to avoid modification during enumeration
                var profilesSnapshot = _profiles.Where(p => p != null).Cast<Profile>().ToArray();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AllowNullCollections = true;
                    cfg.AllowNullDestinationValues = true;

                    foreach (var profile in profilesSnapshot)
                    {
                        cfg.AddProfile(profile);
                    }
                });

                _mapper = new Mapper(config);
            }
        }
    }
}
