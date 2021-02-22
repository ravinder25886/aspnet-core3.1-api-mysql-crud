namespace dc_JWT_Security
{
    public interface IJWTokenService
    {
        APIJWToken CreateToken(string UserId, string UserName);
    }
}
