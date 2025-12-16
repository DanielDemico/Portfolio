namespace backend.Models
{
    public class LoginRequest
    {
        public string Password {get; set;} = string.;
    }
    public class LoginResponse
    {
        public string Token {get; set;} = string.Empty;
        public DateTime ExpiresAt {get; set;}
        
    }
}