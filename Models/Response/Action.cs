using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowBddFramework.Models.Response
{
    public class Action
    {
        public string ActionName { get; set; }
        public bool RequiresValidation { get; set; }
    }
}