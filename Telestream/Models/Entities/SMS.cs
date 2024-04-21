using System;
using System.ComponentModel.DataAnnotations;

namespace Telestream.Models.Entities
{
    public class SMS
    {
        
        [Required]
        public int id { get; set; }
        
        [Required]
        public string contact { get; set; }

        [Required]
        public string from { get; set; }

        [Required]
        public string content { get; set; }
        
        [Required]
        public string to { get; set; }
        
        [Required]
        public Boolean read { get; set; } = false;

        [Required]
        public Boolean sent { get; set; } = false;
        
        [Required]
        public string messageId { get; set; } = "";

        [Required]
        public Boolean successed { get; set; } = false;

        [Required]
        public DateTime createdAt { get; set; } = DateTime.Now;

    }
}
