namespace CatAPILib.Models
{
    public class LoginBody
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
