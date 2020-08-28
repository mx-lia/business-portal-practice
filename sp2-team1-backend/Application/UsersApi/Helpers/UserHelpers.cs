using Application.Common.Interfaces;
using System.Linq;

namespace Application.Common.Helpers
{
    public class UserHelpers
    {
        public static bool CheckForUniqueUserName(IDbContext context, string username)
        {
            var user = context.Users.Where(item => item.UserName == username).FirstOrDefault();
            if (user != null)
                return false;
            return true;
        }

        public static bool CheckForUniqueEmail(IDbContext context, string email)
        {
            var user = context.Users.Where(item => item.Email == email).FirstOrDefault();
            if (user != null)
                return false;
            return true;
        }
    }
}
