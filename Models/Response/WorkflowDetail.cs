using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowBddFramework.Models.Response
{
    public class WorkflowDetail
    {
        public string WorkflowName { get; set; }
        public string CurrentStage { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public int Id { get; set; }
        public bool UserIsPrimary { get; set; }
    }
}
