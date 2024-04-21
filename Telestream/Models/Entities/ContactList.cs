using System;
using System.ComponentModel.DataAnnotations;

namespace Telestream.Models.Entities
{
    public class ContactList
    {
        
        [Required]
        public int id { get; set; }

        [Required]
        public string displayName { get; set; }
        [Required]
        public string fileName { get; set; }

        [Required]
        public DateTime uploadedAt { get; set; } = DateTime.Now;

    }
}
