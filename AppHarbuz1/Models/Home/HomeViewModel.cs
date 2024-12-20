using AppHarbuz.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AppHarbuz1.Models.Home
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = "This field is mandatory")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        public DateTime? DateTime {  get; set; }

        public IEnumerable<TaskApp>? Tasks { get; set; } 
    }
}