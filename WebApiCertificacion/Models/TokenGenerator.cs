using BEUCertificacion;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebApiCertificacion.Models
{
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(Usuario usuario)
        {
            // appsetting for Token JWT
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var _Header = new JwtHeader(signingCredentials);
            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.idusuario.ToString()),
                new Claim("Usuario", usuario.usuario),
                new Claim(JwtRegisteredClaimNames.Email, usuario.email)
            };
            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: issuerToken,
                    audience: audienceToken,
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Expira en 10 min.
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime))
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}