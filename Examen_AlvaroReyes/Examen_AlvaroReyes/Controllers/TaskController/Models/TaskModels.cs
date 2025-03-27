namespace Examen_AlvaroReyes.Controllers.TaskController.Models
{
    using System.Text.Json.Serialization;

    public class TaskResponseDto
    {
        [JsonPropertyName("ID")]
        public int? TaskID { get; set; }

        [JsonPropertyName("Name")]
        public string TaskName { get; set; }

        [JsonPropertyName("Description")]
        public string TaskDescription { get; set; }

        [JsonPropertyName("Active")]
        public bool TaskActive { get; set; }

        [JsonPropertyName("Created At")]
        public DateTime TaskCreatedAt { get; set; }

        [JsonPropertyName("Updated At")]
        public DateTime? TaskUpdatedAt { get; set; }
    }
    public class TaskRegisterDto
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
    }
    public class TaskUpdateDto
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskActive { get; set; }
    }
}
