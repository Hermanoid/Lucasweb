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

        public bool isHome { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        public static explicit operator DataContracts.Project(Project EFProj)
        {
            return new DataContracts.Project()
            {
                DisplayName = EFProj.DisplayName,
                glyphClass = EFProj.glyphClass,
                isGlyph = EFProj.isGlyph,
                imgSrc = EFProj.imgSrc,
                ProjectId = EFProj.ProjectId,
                URL = EFProj.URL,
                isHome = EFProj.isHome
            };
        }

        public static explicit operator Project(DataContracts.Project DCProj)
        {
            return new Project()
            {
                DisplayName = DCProj.DisplayName,
                glyphClass = DCProj.glyphClass,
                isGlyph = DCProj.isGlyph,
                imgSrc = DCProj.imgSrc,
                ProjectId = DCProj.ProjectId,
                URL = DCProj.URL,
                isHome = DCProj.isHome
            };
        }
    }
}
