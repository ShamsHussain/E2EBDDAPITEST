using WorkflowBddFramework.Configuration;
using RestSharp;
using ProceduresBDDFramework.Core;
using WorkflowBddFramework.Core;
using WorkflowBddFramework.Models.Response;
using SpecFlow.Internal.Json;

namespace WorkflowBddFramework.Helpers
{
    public class RequestAndResponse
    {
        private RestResponse response;
        private readonly SpecFlowConfig _specFlowConfig;
        private readonly BusinessUtilsAPI _businessUtilsApi;

        public RequestAndResponse(
            SpecFlowConfig specFlowConfig,
            BusinessUtilsAPI businessUtilsApi
        )
        {
            _specFlowConfig = specFlowConfig;
            _businessUtilsApi = businessUtilsApi;
        }

        public void CreateAndCallRequest(string method, string endPoint, string queryParams, string header, string? payLoad)
        {
            if (queryParams == "None")
                queryParams = "";
            if (header == "None")
                header = "{}";
            if (payLoad == "None")
                payLoad = null;
            string url = _specFlowConfig.BaseUrl + endPoint + queryParams;
            response = _businessUtilsApi.CallRequest(method, url, header, payLoad);
        }

        public void VerifyStatusCode(int statusCode)
        {
            // This method is used to verify if the API response status code is same as expected or not, using common _businessUtilsApi > VerifyOkResponse method

            try
            {
                _businessUtilsApi.VerifyResponseStatusCode(response, statusCode).Should().BeTrue();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in VerifyStatusCode method -->" + e.Message);
                throw;
            }
        }

        public IList<string> ConvertToProcedureList(string procedure)
        {
            string[] sub = procedure.Split(',');
            var procedureList = new List<string>();
            foreach (string subItem in sub)
            {
                procedureList.Add(subItem);
            }
            return procedureList;
        }

        public object ReturnResponse()
        {
            var content = ContentHelpers.GetResponse(response);
            return content.ToString();
        } 

        public WorkFlowGetTypesResponse VerifyWorkFlowGetTypesResponse()
        {
            try
            {
               var content =  ContentHelpers.GetContent<WorkFlowGetTypesResponse>(response);
                return content;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in VerifyResponseContent method -->" + e.Message);
                throw;
            }
        }

        public WorkflowGetResponse VerifyWorkflowGetResponse()
        {
            try
            {
                var content = ContentHelpers.GetContent<WorkflowGetResponse>(response);
                return content;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in VerifyResponseContent method -->" + e.Message);
                throw;
            }
        }

        public WorkflowByIdGetResponse VerifyWorkflowByIdGetResponse()
        {
            try
            {
                var content = ContentHelpers.GetContent<WorkflowByIdGetResponse>(response);
                return content;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in VerifyResponseContent method -->" + e.Message);
                throw;
            }
        }

        public WorkflowroleGetResponse VerifyWorkflowroleGetResponse()
        {
            try
            {
                var content = ContentHelpers.GetContent<WorkflowroleGetResponse>(response);
                return content;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in VerifyResponseContent method -->" + e.Message);
                throw;
            }
        }

        public void ReturnWorkFlowResponse()
        {
            Console.WriteLine("Pending Case");
        }
    }
}
