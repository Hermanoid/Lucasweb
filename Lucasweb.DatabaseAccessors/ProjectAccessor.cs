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

        public List<DataContracts.Project> GetHomeProjects()
        {
            return GetProjects()
                .Where(p => p.isHome)
                .ToList();
        }

        public List<DataContracts.Project> GetProjects()
        {
            List<EntityFramework.Project> EFProjs = db.Projects.ToList();
            List<DataContracts.Project> DCProjs = EFProjs
                .Select(proj => (DataContracts.Project)proj)
                .ToList();

            return DCProjs;
        }
    }
}
