using Lucasweb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucasweb.DataContracts;

using Lucasweb.DatabaseAccessors.EntityFramework;
namespace Lucasweb.DatabaseAccessors
{
    public class ProjectAccessor : IProjectAccessor
    {
        private DatabaseContext db = new DatabaseContext();
        
        private static DataContracts.Project Convert(EntityFramework.Project EFProj)
        {
            return new DataContracts.Project()
            {
                DisplayName=EFProj.DisplayName,
                glyphClass=EFProj.glyphClass,
                imgSrc=EFProj.imgSrc,
                isGlyph=EFProj.isGlyph,
                ProjectId=EFProj.ProjectId,
                URL=EFProj.URL
            };
        }

        public List<DataContracts.Project> GetProjects()
        {
            db.Projects.Add(new EntityFramework.Project()
            {
                DisplayName="Home",
                glyphClass="glyphicon-home",
                imgSrc=null,
                isGlyph=true,
                URL="~/Home"
            });
            db.SaveChanges();
            List<EntityFramework.Project> EFProjs = db.Projects.ToList();
            List<DataContracts.Project> DCProjs = new List<DataContracts.Project>();
            foreach(EntityFramework.Project EFProj in EFProjs)
            {
                DCProjs.Add(Convert(EFProj));
            }

            return DCProjs;
        }
    }
}
