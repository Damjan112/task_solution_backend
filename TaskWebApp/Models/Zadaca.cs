using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskWebApp.Models
{
    public class Zadaca
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
