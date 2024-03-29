﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using SolutionAccelerator.Models.DataTypes;

namespace SolutionAccelerator.DataServices
{
    public class EastIndiaAPIController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();

        public List<RouteAPIModel> Get()
        {
            var task = GetTask();
            var result = task.Result;
            var list = JsonConvert.DeserializeObject<List<RouteAPIModel>>(result);

            return list;
        }

        private async Task<string> GetTask()
        {
            var endPoint = "http://wa-eitdk.azurewebsites.net/api/routeplan";

            var values = new Dictionary<string, string>
            {
                ["date"] = "2",

            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(endPoint, content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

    }
}
