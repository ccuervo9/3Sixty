using Microsoft.AspNetCore.Http;
using static WebApi2c2p.Program;
using System.Threading.Tasks;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace WebApi2c2p.JWTAuthorize
{
    public static class JWTToken
    {
        /// <summary>
        /// handles requests from /connect/token
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="jwtOptions"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static async Task<IResult> Connect(HttpContext ctx, JwtOptions jwtOptions)
        {
            // validates the content type of the request
            //if (ctx.Request.ContentType != "application/x-www-form-urlencoded")
            //    return Results.BadRequest(new { Error = "Invalid Request" });

            var formCollection = await ctx.Request.ReadFormAsync();

            // pulls information from the form
            if (formCollection.TryGetValue("grant_type", out var grantType) == false)
                return Results.BadRequest(new { Error = "Invalid Request" });

            if (formCollection.TryGetValue("username", out var userName) == false)
                return Results.BadRequest(new { Error = "Invalid Request" });

            if (formCollection.TryGetValue("password", out var password) == false)
                return Results.BadRequest(new { Error = "Invalid Request" });

            //creates the access token (jwt token)
            var tokenExpiration = TimeSpan.FromSeconds(jwtOptions.expirationInMinutes);


            var accessToken = JWTToken.CreateAccessToken(
                jwtOptions,
                userName,
                TimeSpan.FromMinutes(60),
                new[] { "read_todo", "create_todo" });

            //returns a json response with the access token
            return Results.Ok(new
            {
                access_token = accessToken,
                expiration = (int)tokenExpiration.TotalSeconds,
                type = "bearer"
            });
        }
        /// <summary>
        /// CreateAccessToken
        /// </summary>
        /// <param name="jwtOptions"></param>
        /// <param name="username"></param>
        /// <param name="expiration"></param>
        /// <param name="permissions"></param>
        /// <returns></returns>
        public static string CreateAccessToken(JwtOptions jwtOptions, string username, TimeSpan expiration, string[] permissions)
        {
            var keyBytes = Encoding.UTF8.GetBytes(jwtOptions.Key);
            var symmetricKey = new SymmetricSecurityKey(keyBytes);

            var signingCredentials = new SigningCredentials(
                symmetricKey,
                // one of the most popular. 
                SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim("sub", username),
                new Claim("name", username),
                new Claim("aud", jwtOptions.Audience)
            };

            var roleClaims = permissions.Select(x => new Claim("role", x));
            claims.AddRange(roleClaims);

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.Add(expiration),
                signingCredentials: signingCredentials);

            var rawToken = new JwtSecurityTokenHandler().WriteToken(token);
            return rawToken;
        }


    }
}
