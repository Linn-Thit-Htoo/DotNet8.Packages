namespace DotNet8.Packages.Polly.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public object Dob { get; set; }
        public object Gender { get; set; }
        public object PortfolioUrl { get; set; }
        public object GitHubUrl { get; set; }
        public object ImageName { get; set; }
        public bool IsActive { get; set; }
        public object IsPremium { get; set; }
    }
}
