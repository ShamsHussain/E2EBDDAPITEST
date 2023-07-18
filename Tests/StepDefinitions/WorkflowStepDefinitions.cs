using LivingDoc.Dtos;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WorkflowBddFramework.Configuration;
using WorkflowBddFramework.Helpers;
using WorkflowBddFramework.Models.Features;
using WorkflowBddFramework.Models.Payload;
using WorkflowBddFramework.Models.Response;

namespace WorkflowBddFramework.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "Workflow")]
    public class WorkflowStepDefinitions
    {
        private readonly CreatePayload _createPayload;
        private readonly RequestAndResponse _requestAndResponse;
        private readonly SpecFlowConfig _specFlowConfig;
        private readonly Helper _helper;
        private string method, header, endPoint, queryParams, payLoad, currentstage, workflowName,actionName;
        public int Id;
        
        public WorkflowStepDefinitions
        (
            CreatePayload createPayload,
            RequestAndResponse requestAndResponse,
            SpecFlowConfig specFlowConfig,
            Helper helper

        )
        {
            _createPayload = createPayload;
            _requestAndResponse = requestAndResponse;
            _specFlowConfig = specFlowConfig;
            _helper = helper;
        }

        [When(@"I send ""([^""]*)"" all Workflow types request for ""([^""]*)""")]
        public void WhenISendAllWorkflowTypesRequestFor(string method, string version)
        {
            header = $"{{'Accept':'application/json','UserName':'{_specFlowConfig.UserName}'}}";
            endPoint = $"{version}/Workflow/types";
            queryParams = "None";
            payLoad = "None";
            _requestAndResponse.CreateAndCallRequest(method, endPoint, queryParams, header, payLoad);
        }

        [Then(@"I validate request (.*)")]
        public void ThenIValidateRequest(int statusCode)
        {
            _requestAndResponse.VerifyStatusCode(statusCode);
        }

        [Then(@"I validate response body has (.*) result")]
        public void ThenIValidateResponseBodyHasResult(int expectedResult)
        {
            _requestAndResponse.ReturnWorkFlowResponse();  
        }

        [When(@"I send ""([^""]*)"" all workflows request for ""([^""]*)"" with query parameters")]
        public void WhenISendAllWorkflowsRequestForWithQueryParameters(string method, string version, Table table)
        {
            header = $"{{'Accept':'application/json','UserName':'{_specFlowConfig.UserName}'}}";
            endPoint = $"{version}/Workflow";
            queryParams = _helper.QueryBuilder(table);
            payLoad = "None";
            _requestAndResponse.CreateAndCallRequest(method, endPoint, queryParams, header, payLoad);
        }

        [Then(@"I get all workflows for one order that have ""([^""]*)"" stage and save ids")]
        public void ThenIGetAllWorkflowsForOneOrderThatHaveStageAndSaveIds(string stage)
        {
            for (int i = 0; i< _requestAndResponse.VerifyWorkflowGetResponse().Data.Count; i++)
            {
                if (_requestAndResponse.VerifyWorkflowGetResponse().Data[i].CurrentStage == stage)
                {
                     Id = _requestAndResponse.VerifyWorkflowGetResponse().Data[i].Id;
                    Console.WriteLine(Id);
                    break;
                }
                
            }
        }

        [When(@"I send ""([^""]*)"" workflow by Id request for ""([^""]*)"" with Id as path parameter")]
        public void WhenISendWorkflowByIdRequestForWithIdAsPathParameter(string method, string version)
        {
            header = $"{{'Accept':'application/json','UserName':'{_specFlowConfig.UserName}'}}";
            endPoint = $"{version}/Workflow/{Id}";
            queryParams = "None";
            payLoad = "None";
            _requestAndResponse.CreateAndCallRequest(method, endPoint, queryParams, header, payLoad);
        }

        [Then(@"I get all actions, staged data, workflowName, currentStage")]
        public void ThenIGetAllActionsStagedDataWorkflowNameCurrentStage()
        {
           workflowName =  _requestAndResponse.VerifyWorkflowByIdGetResponse().WorkflowName;
           currentstage = _requestAndResponse.VerifyWorkflowByIdGetResponse().CurrentStage;
            actionName = _requestAndResponse.VerifyWorkflowByIdGetResponse().Actions[0].ActionName;           
        }

        [When(@"I send workflow ""([^""]*)"" request with action name Take Ownership for ""([^""]*)"" with payload parameters")]
        public void WhenISendWorkflowRequestWithActionNameTakeOwnershipForWithPayloadParameters(string method, string version)
        {
            endPoint = $"{version}/Workflow";
            payLoad = _createPayload.CreateWorkFlowPayload(Id);
            header = $"{{'Accept':'application/json','UserName':'{_specFlowConfig.UserName}'}}";
            queryParams = "None";
            _requestAndResponse.CreateAndCallRequest(method, endPoint, queryParams, header, payLoad);
        }

        [When(@"I send workflow ""([^""]*)"" request with action name ""([^""]*)""  ""([^""]*)""  for ""([^""]*)"" with payload parameters")]
        public void WhenISendWorkflowRequestWithActionNameForWithPayloadParameters(string method, string action, string result, string version)
        {
            endPoint = $"{version}/Workflow";
            payLoad = _createPayload.CreateSubmitWorkFlowPayload(Id, action, result);
            header = $"{{'Accept':'application/json','UserName':'{_specFlowConfig.UserName}'}}";
            queryParams = "None";
            _requestAndResponse.CreateAndCallRequest(method, endPoint, queryParams, header, payLoad);
        }




    }
}
