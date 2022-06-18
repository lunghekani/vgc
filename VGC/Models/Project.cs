using System.ComponentModel.DataAnnotations;

namespace VGC.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
