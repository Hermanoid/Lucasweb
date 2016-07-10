using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.DatabaseAccessors.EntityFramework
{
    public class Project
    {
        [Required]
        public bool isGlyph { get; set; }

        [StringLength(256)]
        public string glyphClass { get; set; }

        [StringLength(512)]
        public string imgSrc { get; set; }

        [Required]
        [StringLength(512)]
        public string URL { get; set; }

        [StringLength(50)]
        public string DisplayName { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
    }
}
