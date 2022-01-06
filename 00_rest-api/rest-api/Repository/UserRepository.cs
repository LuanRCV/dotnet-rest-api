using rest_api.Data.VO;
using rest_api.Model;
using rest_api.Model.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace rest_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            string pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.UserName == user.Username) && (u.Password == pass));
        }

        public User ValidateCredentials(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public bool RevokeToken(string userName)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null) return false;

            user.RefreshToken = null;
            _context.SaveChanges();

            return true;
        }

        public User RefreshUserInfo(User user)
        {
            try
            {
                var result = _context.Users.SingleOrDefault(i => i.Id.Equals(user.Id));

                if (result == null) return null;

                _context.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
