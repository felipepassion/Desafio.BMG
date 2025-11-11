using Bmg.Desafio.Core.Application.DTO.Http.Models.Responses;
using Bmg.Desafio.Users.Identity;
using Bmg.Desafio.Users.Identity.Security; // added
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Commands.Handlers;

using Entities;

public partial class UserCommandHandler
{
    // On create we also create the corresponding Identity ApplicationUser.
    public override async Task<DomainResponse> OnCreateAsync(User entity)
    {
        var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var signinManager = _serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
        var tokenService = _serviceProvider.GetRequiredService<IJwtTokenService>(); // new

        // Basic validations
        if (string.IsNullOrWhiteSpace(entity.Email)) return DomainResponse.Error("Email obrigatório");
        if (string.IsNullOrWhiteSpace(entity.UserName)) return DomainResponse.Error("UserName obrigatório");
        if (string.IsNullOrWhiteSpace(entity.Password)) return DomainResponse.Error("Senha obrigatória");

        // Check duplicates in Identity store
        if (await userManager.FindByEmailAsync(entity.Email) != null)
            return DomainResponse.Error("E-mail já cadastrado");
        if (await userManager.FindByNameAsync(entity.UserName) != null)
            return DomainResponse.Error("Username já cadastrado");

        var appUser = new ApplicationUser
        {
            UserName = entity.UserName,
            Email = entity.Email,
            Name = entity.Name,
            PhoneNumber = entity.PhoneNumber,
            ExternalId = entity.ExternalId
        };

        var createResult = await userManager.CreateAsync(appUser, entity.Password);
        if (!createResult.Succeeded)
            return DomainResponse.Error(createResult.Errors.Select(e => e.Description).ToArray());

        // Optional cookie sign-in (can be removed if only JWT is desired)
        await signinManager.PasswordSignInAsync(appUser, entity.Password, isPersistent: false, lockoutOnFailure: false);

        // Generate JWT token and expose it
        entity.AuthToken = tokenService.GenerateToken(appUser);
        entity.Id = appUser.Id;

        return DomainResponse.Ok();
    }

    // On update we sync changes to Identity user and optionally change password.
    public override async Task<DomainResponse> OnUpdateAsync(User entity, User entityAfter)
    {
        var userManager = _serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        // Find existing identity user (prefer username, fallback to email)
        ApplicationUser appUser = await userManager.FindByNameAsync(entity.UserName);
        if (appUser == null && !string.IsNullOrWhiteSpace(entity.Email))
            appUser = await userManager.FindByEmailAsync(entity.Email);

        if (appUser == null)
            return DomainResponse.Error("Usuário Identity não encontrado");

        // Validate e-mail change
        if (!string.Equals(entityAfter.Email, entity.Email, System.StringComparison.InvariantCultureIgnoreCase))
        {
            if (string.IsNullOrWhiteSpace(entityAfter.Email))
                return DomainResponse.Error("Email não pode ser vazio");

            var otherWithEmail = await userManager.FindByEmailAsync(entityAfter.Email);
            if (otherWithEmail != null && otherWithEmail.Id != appUser.Id)
                return DomainResponse.Error("E-mail já utilizado");

            appUser.Email = entityAfter.Email;
        }

        // Validate username change
        if (!string.Equals(entityAfter.UserName, entity.UserName, System.StringComparison.InvariantCultureIgnoreCase))
        {
            if (string.IsNullOrWhiteSpace(entityAfter.UserName))
                return DomainResponse.Error("UserName não pode ser vazio");

            var otherWithUserName = await userManager.FindByNameAsync(entityAfter.UserName);
            if (otherWithUserName != null && otherWithUserName.Id != appUser.Id)
                return DomainResponse.Error("UserName já utilizado");

            appUser.UserName = entityAfter.UserName;
        }

        var updateResult = await userManager.UpdateAsync(appUser);
        if (!updateResult.Succeeded)
            return DomainResponse.Error(updateResult.Errors.Select(e => e.Description).ToArray());

        return DomainResponse.Ok();
    }
}
