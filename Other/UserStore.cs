using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ukol9.Other
{
    public class UserStore : IUserStore<IdentityUser>,
        IUserPasswordStore<IdentityUser>,
        IUserSecurityStampStore<IdentityUser>
    {
        // Not implemented in this example, use EF asnyc
        public async Task CreateAsync(IdentityUser identityUser)
        {
            await Task.Delay(0);

            throw new NotImplementedException();
        }

        // Not implemented in this example, use EF asnyc
        public async Task DeleteAsync(IdentityUser identityUser)
        {
            await Task.Delay(0);

            throw new NotImplementedException();
        }

        // Hard coded implementation, use EF asnyc instead
        public async Task<IdentityUser> FindByIdAsync(string userId)
        {
            await Task.Delay(0);

            IdentityUser identityUser = null;

            if (userId == "1")
            {
                identityUser = new IdentityUser();
                identityUser.Id = "1";
                identityUser.UserName = "admin";
            }

            return identityUser;
        }

        // Hard coded implementation, use EF asnyc instead
        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            await Task.Delay(0);

            IdentityUser identityUser = null;

            if (userName == "admin")
            {
                identityUser = new IdentityUser();
                identityUser.Id = "1";
                identityUser.UserName = "admin";
            }

            return identityUser;
        }

        // Not implemented in this example, use EF asnyc
        public async Task UpdateAsync(IdentityUser identityUser)
        {
            await Task.Delay(0);

            throw new NotImplementedException();
        }

        // Hard coded implementation, use EF asnyc instead
        public async Task<string> GetPasswordHashAsync(IdentityUser identityUser)
        {
            await Task.Delay(0);

            if (identityUser.Id == "1")
            {
                // Hash for "password"
                return "ADkPKi0mACIBxyl1rRv2VVjnw83jG3JZEL2XyKJM5ffpFtlKNq70pMgobayb9nd7tQ==";
            }

            throw new ApplicationException("Invalid identity user.");
        }

        // Hard coded implementation, use EF asnyc instead
        public async Task<bool> HasPasswordAsync(IdentityUser identityUser)
        {
            await Task.Delay(0);

            if (identityUser.Id == "1")
            {
                return true;
            }

            throw new ApplicationException("Invalid identity user.");
        }

        // Not implemented in this example, use EF asnyc
        public async Task SetPasswordHashAsync(
            IdentityUser identityUser,
            string passwordHash)
        {
            await Task.Delay(0);

            throw new NotImplementedException();
        }

        // Hard coded implementation, use EF asnyc instead
        public async Task<string> GetSecurityStampAsync(
            IdentityUser identityUser)
        {
            await Task.Delay(0);

            if (identityUser.Id == "1")
            {
                return "0EB32F4F-2C30-40B7-8EAB-09000836833B";
            }

            throw new ApplicationException("Invalid identity user.");
        }

        // Not implemented in this example, use EF asnyc
        public async Task SetSecurityStampAsync(
            IdentityUser identityUser,
            string stamp)
        {
            await Task.Delay(0);

            throw new NotImplementedException();
        }

        // No dispose implementation required in this example
        public void Dispose()
        {
        }
    }
}
