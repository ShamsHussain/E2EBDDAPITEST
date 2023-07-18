using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowBddFramework.Models.Payload
{
    public class RoleUser
    {
        public int WorkflowRoleId { get; set; }
        public Users User { get; set; } = new Users();
    }
}
