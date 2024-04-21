using System;
using System.ComponentModel.DataAnnotations;

namespace Telestream.Models.Entities
{
    public class Setting
    {
        [Required]
        public int id { get; set; }

        [Required]
        public int type { get; set; }

        [Required]
        public string value { get; set; }

    }
}
