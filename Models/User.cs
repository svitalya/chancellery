using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chancellery.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }

        public int UserRoleID {  get; set; }
        public UserRole UserRole { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public static User authUser = null;
        

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string prior to .NET 5
                StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }

        public static bool Auth(string login, string password)
        {
            ApplicationContext bd = Program.bd;
            User user = bd.Users.Where(u => u.Login == login && u.PasswordHash == User.CreateMD5(password)).FirstOrDefault();

            if (user != null)
            {
                user.UserRole = bd.UserRoles.Find(user.UserRoleId);

                authUser = user;
                return true;
            }

            return false;
        }

        public static void Logout()
        {
            authUser = null;
        }

        public static int getLevelAccess()
        {
            if(authUser == null)
            {
                return 0;
            }

            return authUser.UserRole.LevelAccess;
        }
    }
}
