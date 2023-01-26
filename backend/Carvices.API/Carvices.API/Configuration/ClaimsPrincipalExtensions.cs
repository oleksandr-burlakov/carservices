using Carvices.API.Exceptions;
using Carvices.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Carvices.API.Configuration
{
    public static class ClaimsPrincipalExtensions
    {
        public static async Task<User> GetUser(this ClaimsPrincipal principal, UserManager<User> manager)
        {
            var userName = principal.Identity?.Name;
            if (String.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException($"{nameof(ClaimsPrincipal.Identity)}.{nameof(ClaimsPrincipal.Identity.Name)}");
            }
            var user = await manager.FindByNameAsync(userName);
            if (user is null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }

        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            var id = principal.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            if (id is null)
            {
                throw new UserIdNotFoundException();
            }
            var isParsed = Guid.TryParse(id.Value, out var returnId);

            if (!isParsed)
            {
                throw new UserIdCorruptedException();
            }
            return returnId;
        }
    }
}
