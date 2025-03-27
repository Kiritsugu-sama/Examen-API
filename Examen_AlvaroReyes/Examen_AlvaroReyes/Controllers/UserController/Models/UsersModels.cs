namespace Examen_AlvaroReyes.Controllers.UserController.Models
{
    public class UserResponseDto
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public bool UserActive { get; set; }
        public DateTime UserCreatedAt { get; set; }
        public DateTime UserUpdatedAt { get; set; }
    }
    public class UserRegisterDto
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
    public class UserUpdateDto
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool UserActive { get; set; }
    }
}
