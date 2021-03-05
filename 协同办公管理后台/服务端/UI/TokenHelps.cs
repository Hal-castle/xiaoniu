
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class Users
    {
        public string Name { get; set; }
        public string Pass { get; set; }
    }

    public class JwtTokenUtil
    {
       

        public object Configuration { get; private set; }

        public string GetToken(Users user)
        {
            // push the user’s name into a claim, so we can identify the user later on.
            var claims = new[]
            {
                   new Claim("Name", user.Name),
                   new Claim("Pass",user.Pass)
            };
            //sign the token using a secret key.This secret will be shared between your API and anything that needs to check that the token is legit.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dd%88*377f6d&f£$$£$FdddFF33fssDG^!3")); // 获取密钥
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //凭证 ，根据密钥生成
           
            var token = new JwtSecurityToken(
                issuer: "jwttest",
                audience: "jwttest",
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string UpToken(string token)
        {
            var validateParameter = new TokenValidationParameters()
            {
                ValidateIssuer = true,//是否验证Issuer
                ValidateAudience = true,//是否验证Audience
                ValidateLifetime = true,//是否验证失效时间
                ValidateIssuerSigningKey = true,//是否验证SecurityKey
                ValidAudience = "jwttest",//Audience
                ValidIssuer = "jwttest",//Issuer，这两项和前面签发jwt的设置一致
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dd%88*377f6d&f£$$£$FdddFF33fssDG^!3"))//拿到SecurityKey
            };
            try
            {
                //校验并解析token
                var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, validateParameter, out SecurityToken validatedToken);//validatedToken:解密后的对象
                var jwtPayload = ((JwtSecurityToken)validatedToken).Payload.SerializeToJson(); //获取payload中的数据 
                return jwtPayload;
            }
            catch (SecurityTokenExpiredException)
            {
                //token过期
                return null;
            }
            catch (SecurityTokenException)
            {
                //表示token错误
                return null;
            }
        }
    }
}
