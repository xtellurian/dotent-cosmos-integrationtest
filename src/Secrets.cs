namespace src
{
    public static class Secrets
    {
        public static string JwtKey => "Any long string used to sign and verify JWT Tokens";
        public static string Issuer => "self";
        public static string Audience => "this";
    }
}