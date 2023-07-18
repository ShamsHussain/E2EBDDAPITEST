using System;
using TechTalk.SpecFlow;
using WorkflowBddFramework.Configuration;
using WorkflowBddFramework.Helpers;

namespace WorkflowBddFramework.Tests.StepDefinitions
{
    [Binding]
    public class WorkflowRoleStepDefinitions
    {
        private readonly RequestAndResponse _requestAndResponse;
        private readonly SpecFlowConfig _specFlowConfig;
        private string method, header, endPoint, queryParams, payLoad, Id;

        public WorkflowRoleStepDefinitions
        (
            RequestAndResponse requestAndResponse,
            SpecFlowConfig specFlowConfig

        )
        {
            _requestAndResponse = requestAndResponse;
            _specFlowConfig = specFlowConfig;
        }

        [When(@"I send ""([^""]*)"" all WorkflowRole request for ""([^""]*)""")]
        public void WhenISendAllWorkflowRoleRequestFor(string method, string version)
        {
            header = $"{{'Accept':'application/json','UserName':'{_specFlowConfig.UserName}'}}";
            endPoint = $"{version}/workflowrole";
            queryParams = "None";
            payLoad = "None";
            _requestAndResponse.CreateAndCallRequest(method, endPoint, queryParams, header, payLoad);
        }

        [Then(@"I validate request (.*)")]
        public void ThenIValidateRequest(int statusCode)
        {
            _requestAndResponse.VerifyStatusCode(statusCode);
        }

        [Then(@"I validate response body is not null")]
        public void ThenIValidateResponseBodyIsNotNull()
        {
            _requestAndResponse.ReturnResponse().Should().NotBeNull();

        }

    }
}
