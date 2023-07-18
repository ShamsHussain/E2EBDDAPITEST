using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowBddFramework.Models.Response
{
    public class WorkflowByIdGetResponse
    {
        public string WorkflowName { get; set; }
        public string CurrentStage { get; set; }
        public string Description { get; set; }
        public object Notes { get; set; }
        public StageData StageData { get; set; } = new StageData();
        public List<Action> Actions { get; set; } = new List<Action> { };
    }
}
