using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lucasweb.Models
{
    public class Sound
    {
        public int SoundID { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Location { get; set; }

        public string type { get; set; }

        [Required]
        [Display(ShortName ="Title")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name ="Creator")]
        public string OwnerName { get; set; }

        [Display(Name ="Upload Date")]
        [DataType(DataType.DateTime)]
        public DateTime UploadTime { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}