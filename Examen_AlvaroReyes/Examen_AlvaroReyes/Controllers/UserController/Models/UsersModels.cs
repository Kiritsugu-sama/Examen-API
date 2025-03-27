using System.Text.Json.Serialization;

namespace Examen_AlvaroReyes.Controllers.UserController.Models
{
    public class UserResponseDto
    {
        [JsonPropertyName("ID")]
        public int? UserID { get; set; }
        [JsonPropertyName("Name")]
        public string UserName { get; set; }
        [JsonPropertyName("Email")]
        public string UserEmail { get; set; }
        [JsonPropertyName("Active")]
        public bool UserActive { get; set; }
        [JsonPropertyName("Created At")]
        public DateTime UserCreatedAt { get; set; }
        [JsonPropertyName("Updated At")]
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
