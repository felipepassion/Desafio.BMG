using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

// Assembly-level configuration
[assembly: TestCollectionOrderer("FunctionalTests.Infrastructure.NamedCollectionOrderer", "FunctionalTests")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace FunctionalTests.Infrastructure
{
    // Orders test collections so that Users runs before Proposta and Contratacao
    public class NamedCollectionOrderer : ITestCollectionOrderer
    {
        public IEnumerable<ITestCollection> OrderTestCollections(IEnumerable<ITestCollection> testCollections)
        {
            return testCollections.OrderBy(c => GetOrder(c.DisplayName));
        }

        private static int GetOrder(string displayName)
        {
            if (displayName.Contains("Users")) return 0;
            if (displayName.Contains("Proposta")) return 1;
            if (displayName.Contains("Contratacao")) return 2;
            return 3;
        }
    }
}
