namespace RazorIntroduction.TagHelpers.Web.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PictureUrl { get; set; }
        public string? Description { get; set; }
        public int Followers { get; set; }
        public double Rating { get; set; }
        public int Posts { get; set; }

    }
}
