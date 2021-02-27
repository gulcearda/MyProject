using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //hangi anahtarı ve hangi algoritma kullanılcak bunları belirttik
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
