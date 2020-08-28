
namespace Domain.Entities
{
    public class ResetPasswordToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
