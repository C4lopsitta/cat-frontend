namespace cat_frontend.CatAPILib.Models
{
    public class LoginBody
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
