using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WorkflowBddFramework.Configuration;
using WorkflowBddFramework.Models;
using WorkflowBddFramework.Models.Payload;
using ProceduresBDDFramework.Core;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using FluentAssertions;
using WorkflowBddFramework.Core;
using WorkflowBddFramework.Helpers;
using WorkflowBddFramework.Tests.StepDefinitions;

namespace WorkflowBddFramework.Helpers
{
    public class CreatePayload
    {

        private readonly Helper _helper;
        private readonly SpecFlowConfig _specFlowConfig;
        private readonly AuthConfig _authConfig;
        private readonly RoleUser _roleUser;
        private readonly Workflow _workflow;
        private readonly RequestAndResponse _requestAndResponse;
        //private readonly WorkflowStepDefinitions _workflowStepDefinitions;



        public CreatePayload
            (
             Helper helper,
             SpecFlowConfig specFlowConfig,
             AuthConfig authConfig,
             RoleUser roleUser,
             Workflow workflow,
             RequestAndResponse requestAndResponse)
             //WorkflowStepDefinitions workflowStepDefinitions)
        {
            _specFlowConfig = specFlowConfig;
            _authConfig = authConfig;
            _helper = helper;
            _roleUser = roleUser;
            _workflow = workflow;
            _requestAndResponse = requestAndResponse;
            //_workflowStepDefinitions = workflowStepDefinitions;
        }

        public string CreateRoleUserPayload(int workFlowId, string id, string email)
        {
            _roleUser.WorkflowRoleId = workFlowId;
            _roleUser.User.Email = email;
            _roleUser.User.Id = id;
            _roleUser.User.UserName = _specFlowConfig.UserName;

            string jsonPayload = ContentHelpers.SerialiJsonString(_roleUser);
            return jsonPayload;
        }

        public string CreateWorkFlowPayload(int Id)
        {
            _workflow.WorkflowName = _requestAndResponse.VerifyWorkflowByIdGetResponse().WorkflowName;
            _workflow.WorkflowId = Id;
            _workflow.CurrentStage = _requestAndResponse.VerifyWorkflowByIdGetResponse().CurrentStage;
            _workflow.ActionName = _requestAndResponse.VerifyWorkflowByIdGetResponse().Actions[0].ActionName;
            _workflow.StageData.ClientId = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.ClientId;
            _workflow.StageData.CodingRequestId = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.CodingRequestId;
            _workflow.StageData.OrderNumber = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.OrderNumber;
            _workflow.StageData.ProcedureId = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.ProcedureId;
            _workflow.StageData.Result = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.Result;
            _workflow.StageData.Remarks = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.Remarks;
            _workflow.StageData.FollowUpProcedures = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.FollowUpProcedures;

            string jsonPayload = ContentHelpers.SerialiJsonString(_workflow);
            return jsonPayload;
        }

        public string CreateSubmitWorkFlowPayload(int Id, string actionName,string result)
        {
            _workflow.WorkflowName = _requestAndResponse.VerifyWorkflowByIdGetResponse().WorkflowName;
            _workflow.WorkflowId = Id;
            _workflow.CurrentStage = _requestAndResponse.VerifyWorkflowByIdGetResponse().CurrentStage;
            _workflow.ActionName = actionName;
            _workflow.StageData.ClientId = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.ClientId;
            _workflow.StageData.CodingRequestId = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.CodingRequestId;
            _workflow.StageData.OrderNumber = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.OrderNumber;
            _workflow.StageData.ProcedureId = _requestAndResponse.VerifyWorkflowByIdGetResponse().StageData.ProcedureId;
            _workflow.StageData.Result = result;
            _workflow.StageData.Remarks = null;
            _workflow.StageData.FollowUpProcedures =null;


            string jsonPayload = ContentHelpers.SerialiJsonString(_workflow);
            return jsonPayload;
        }
    }
}
