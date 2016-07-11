using Lucasweb.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucasweb.DataContracts;
using Lucasweb.Utilities;

namespace Lucasweb.Managers
{
    public class ProjectManager : IProjectManager
    {
        public List<Project> GetHomeProjects()
        {
            return ClassFactory.CreateClass<IProjectAccessor>().GetHomeProjects();
        }

        public List<Project> GetProjects()
        {
            return ClassFactory.CreateClass<IProjectAccessor>().GetProjects();
        }
    }
}
