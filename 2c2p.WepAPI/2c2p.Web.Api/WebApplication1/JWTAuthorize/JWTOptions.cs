namespace WebApi2c2p.JWTAuthorize
{
    public record class JwtOptions(
            string Issuer,
            string Audience,
            string Key,
            int expirationInMinutes
        );
}
