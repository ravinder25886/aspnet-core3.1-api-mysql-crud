namespace dc_JWT_Security
{
    public class JWTSettings
    {
        public string JWTSecret { get; set; }
        public int ExpiresInDays { get; set; }
        public string Key { get; set; }
    }
}
