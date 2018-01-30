using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;

namespace Portfolio.Models
{
    public class Project
    {
        public string name { get; set; }
        public string language { get; set; }
        public string html_url { get; set; }


        public Project() 
        {
            
        }

        public static List<Project> GetProjects()
        {
            var client = new RestClient("https://api.github.com/users/saneyee/starred");
            var request = new RestRequest();
            //var request = new RestRequest(string.Format("{0}/starred", "saneyee"), Method.GET);

            request.AddHeader("User-Agent", "saneyee");
            request.AddParameter("per_page", "3");
            request.AddParameter("direction", "asc");

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var projectList = JsonConvert.DeserializeObject<List<Project>>(jsonResponse.ToString());
            return projectList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
