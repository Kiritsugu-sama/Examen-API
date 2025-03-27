namespace Examen_AlvaroReyes.Controllers.TaskController.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TaskResponseDto
    {
        [Display(Name = "ID")]
        public int? TaskID { get; set; }

        [Display(Name = "Name")]
        public string TaskName { get; set; }

        [Display(Name = "Description")]
        public string TaskDescription { get; set; }

        [Display(Name = "Active")]
        public bool TaskActive { get; set; }

        [Display(Name = "Created At")]
        public DateTime TaskCreatedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime TaskUpdatedAt { get; set; }
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
