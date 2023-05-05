using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosAPI.Authorization;

public class AgeAuthorization : AuthorizationHandler<MinimumAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
    {
        var dateBirthClaim = context
            .User.FindFirst(claim =>
             claim.Type == ClaimTypes.DateOfBirth);

        if (dateBirthClaim is null)
            return Task.CompletedTask;

        var dateBirth = Convert
            .ToDateTime(dateBirthClaim.Value);

        var userAge =
            DateTime.Today.Year - dateBirth.Year;

        if (dateBirth >
                DateTime.Today.AddYears(-userAge))
            userAge--;

        return Task.CompletedTask;
    }
}
