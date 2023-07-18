using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowBddFramework.Helpers;
using WorkflowBddFramework.Configuration;

namespace ProceduresBDDFramework.Core
{
    public class BusinessUtilsAPI
    {
        /// <summary>
        /// This class contains the common methods or utilities for API Automation
        /// </summary>

        private RestResponse response;
        private RestClient client;
        private RestRequest request;
        private readonly AuthConfig _authConfig;

        public BusinessUtilsAPI
        (AuthConfig authConfig)
        {
            _authConfig = authConfig;
        }

        public RestResponse CallRequest(string method, string url, string headers, object payload)
        {
            /*
             * Description:
                |   This method allows user to call a Get/Post/Put/Post/Patch/Delete request

                :param method: Type of request.Get or Post etc..                
                :param url: Request URL
                :param headers: Headers to call a request (dictionary)
                :param payload: payload object               
                :param authType:
                :param authUsername:
                :param authPassword:
                :param timeout: (optional) How long to wait for the server to send
                
                :return: response - response object generated on calling a request
               
                .. note::
                    |  method (String) :
                    |  Accepts: Get, Post, Put, Patch or Delete
                    |
                    |  authType(String) :
                    |  Accepts: basic, ntlm, digest, proxy                                                           
             */

            try
            {
                request = new RestRequest();
                if (url == "")
                    Console.WriteLine("URL can not be null");

                var options = new RestClientOptions(url);
                {
                    options.Authenticator = new JsonTokenAuthorization(_authConfig.BaseTokenURI, _authConfig.Client, _authConfig.Password, _authConfig.Scope);
                }

                client = new RestClient(options);

                // add header parameters, if any
                if (headers != null)
                {
                    Dictionary<string, string> dictionary = JObject.Parse(headers).ToObject<Dictionary<string, string>>();
                    foreach (var param in dictionary)
                    {
                        request.AddHeader(param.Key, param.Value);
                    }
                }

                // add payload (HTTP body (POST request)), if any
                if (payload != null)
                {
                    request.AddParameter("application/json", payload, ParameterType.RequestBody);
                }

                if (method.ToUpper() == "GET")
                {
                    request.Method = Method.Get;
                    response = client.Execute(request);
                }

                else if (method.ToUpper() == "POST")
                {
                    request.Method = Method.Post;
                    if (payload != null)
                    {
                        response = client.Execute(request);
                    }

                    else
                        Console.WriteLine("Error-->Payload is missing");
                }

                else if (method.ToUpper() == "PUT")
                {
                    request.Method = Method.Put;
                    if (payload != null)
                    {
                        response = client.Execute(request);
                    }

                    else
                        Console.WriteLine("Error-->Payload is missing");
                }

                else if (method.ToUpper() == "PATCH")
                {
                    request.Method = Method.Patch;
                    if (payload != null)
                        response = client.Execute(request);
                    else
                        Console.WriteLine("Error-->Payload is missing");
                }

                else if (method.ToUpper() == "DELETE")
                {
                    request.Method = Method.Delete;
                    response = client.Execute(request);
                }

                else
                    Console.WriteLine("Method can be any one among Get/Post/Put/Patch/Delete but the value is " + method);

                return response;
            }

            catch (Exception e)
            {

                Console.WriteLine("Error in CallRequest method " + e.Message);
                throw;
            }
        }

        public bool VerifyResponseStatusCode(RestResponse response, int statusCode)
        {
            /*
             * Description:
            	|  This method is used to validate if the expected status code is same as returned by the provided API response.
  
                :param response: response of type IRestResponse
                :param statusCode: statusCode of type int
  
                :return: boolean
                Examples:
                |  VerifyOkResponse(response, 200)
                                                          
             */

            try
            {
                int expectedStatusCode = statusCode;
                int actualStatusCode = (int)response.StatusCode;

                bool result = (actualStatusCode == expectedStatusCode);

                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error in VerifyResponseStatusCode method -->" + e.Message);
                throw;
            }
        }

    }
}
