namespace TaskFlowAPI
{
    public sealed class JwtOptions
    {
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public int ExpiresInMinutes { get; init; }
        public string SecretKey { get; init; }
    }
}
