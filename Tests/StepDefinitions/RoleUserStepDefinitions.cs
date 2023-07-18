using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WorkflowBddFramework.Configuration;
using WorkflowBddFramework.Helpers;
using WorkflowBddFramework.Models.Features;
using WorkflowBddFramework.Models.Payload;

namespace WorkflowBddFramework.Tests.StepDefinitions
{
    [Binding]
    [Scope(Feature = "RoleUser")]
    public class RoleUserStepDefinitions
    {
        private readonly CreatePayload _createPayload;
        private readonly RequestAndResponse _requestAndResponse;
        private readonly SpecFlowConfig _specFlowConfig;
        private string method, header, endPoint, queryParams, payLoad,Id;
        
        public RoleUserStepDefinitions
        (
            CreatePayload createPayload,
            RequestAndResponse requestAndResponse,
            SpecFlowConfig specFlowConfig

        )
        {
            _createPayload = createPayload;
            _requestAndResponse = requestAndResponse;
            _specFlowConfig = specFlowConfig;
        }

        [When(@"I send RoleUser ""([^""]*)"" request for ""([^""]*)"" with payload parameters")]
        public void WhenISendRoleUserRequestForWithPayloadParameters(string method, string version, Table table)
        {
            var data = table.CreateInstance<RoleUserInfo>();

            endPoint = $"{version}/RoleUser";
            payLoad = _createPayload.CreateRoleUserPayload(data.WorkflowRoleId, data.Id,data.Email);
            header = $"{{'Accept':'application/json','UserName':'{_specFlowConfig.UserName}'}}";
            queryParams = "None";
            _requestAndResponse.CreateAndCallRequest(method, endPoint, queryParams, header, payLoad);
        }

        [Then(@"I validate request (.*)")]
        public void ThenIValidateRequest(int statusCode)
        {
            _requestAndResponse.VerifyStatusCode(statusCode);
        }

        [Then(@"I validate response has id")]
        public void ThenIValidateResponseHasId()
        {

            Id = (string)_requestAndResponse.ReturnResponse();
            _requestAndResponse.ReturnResponse().Should().NotBeNull();
        }


        [When(@"I input ""([^""]*)"" in Query parameters and send ""([^""]*)"" all RoleUser request for ""([^""]*)""")]
        public void WhenIInputInQueryParametersAndSendAllRoleUserRequestFor(string workflowRoleId, string method, string version)
        {
            header = $"{{'Accept':'application/json','UserName':'{_specFlowConfig.UserName}'}}";
            endPoint = $"{version}/RoleUser";
            queryParams = $"?WorkflowRoleId={workflowRoleId}";
            payLoad = "None";
            _requestAndResponse.CreateAndCallRequest(method, endPoint, queryParams, header, payLoad);
        }

        [When(@"I input RoleUserId as path parameter and ""([^""]*)"" in Query parameters and send ""([^""]*)"" request for ""([^""]*)""")]
        public void WhenIInputRoleUserIdAsPathParameterAndInQueryParametersAndSendRequestFor(string workflowRoleId, string method, string version)
        {
            header = $"{{'Accept':'application/json','UserName':'{_specFlowConfig.UserName}'}}";
            endPoint = $"{version}/RoleUser/{Id}";
            queryParams = $"?WorkflowRoleId={workflowRoleId}";
            payLoad = "None";
            _requestAndResponse.CreateAndCallRequest(method, endPoint, queryParams, header, payLoad);
        }


    }
}
