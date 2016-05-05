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

        [DataType(DataType.Url)]
        public string Location { get; set; }

        public string type { get; set; }

        [Display(ShortName ="Title")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(ShortName ="Creator")]
        public string OwnerName { get; set; }

        [Display(ShortName ="Upload Date")]
        [DataType(DataType.DateTime)]
        public DateTime UploadTime { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}