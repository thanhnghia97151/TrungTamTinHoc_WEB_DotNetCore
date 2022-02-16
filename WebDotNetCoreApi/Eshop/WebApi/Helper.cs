using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApi.Models;

namespace WebApi
{
    public static class Helper
    {
        public static string RandomString(int len)
        {
            string pattern = "qwertyuiopasdfghjklzxcvbnm1234567890";
            Random random =  new Random();
            char[] arr = new char[len];
            for (int i = 0; i < len; i++)
            {
                arr[i] = pattern[random.Next(pattern.Length)];

            }
            return string.Join(string.Empty, arr);//string.Emply => ""
        }
        public static byte[] Hash(string plaintext)
        {
            HashAlgorithm hash = HashAlgorithm.Create("SHA-512");
            return hash.ComputeHash(Encoding.ASCII.GetBytes(plaintext));
        }
        public static string CreateToken(Member obj)
        {
            byte[] key = Encoding.ASCII.GetBytes("qwertyuiopasdfghjklzxcvbnm");
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,obj.MemberId),
                   new Claim(ClaimTypes.Name,obj.UserName),
                   new Claim(ClaimTypes.Email,obj.Email),
                   new Claim(ClaimTypes.Gender,obj.Gender.ToString())
                   //new Claim(ClaimTypes.Role,obj.Role)
            };
            //Role
            if(obj.Roles != null)
            {
                foreach(string role in obj.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));

                }
            }
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
        
    }
    
}
