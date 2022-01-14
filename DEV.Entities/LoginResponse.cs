namespace DEV.Entities
{
    public class LoginResponse
    {
        public bool Authenticated { get; set; }

        public string Message { get; set; }

        public User User { get; set; }

        public string AuthenticationToken { get; set; }
    }
}
