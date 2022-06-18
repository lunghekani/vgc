using System.ComponentModel.DataAnnotations;

namespace VGC.Models
{
    public class Topics
    {
        [Key]
        public string TopicId { get; set; }
        public string TopicName  { get; set; }
        public string TopicDescription { get; set; }

        
    }
}
