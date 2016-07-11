using Lucasweb.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Contracts
{
    public interface IProjectAccessor
    {
        List<Project> GetProjects();
        List<Project> GetHomeProjects();
    }
}
