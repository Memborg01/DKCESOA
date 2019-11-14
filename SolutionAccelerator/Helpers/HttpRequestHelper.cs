using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Helpers
{
    public class HttpRequestHelper
    {
        public HttpRequestHelper()
        {

        }

        public APIReponse SendRequest(string date, float weight, float height, float length, float width, TransportationModeEnum transportationMode)
        {
            string URL;
            switch (transportationMode)
            {
                case TransportationModeEnum.Ocean:
                    URL = "http://wa-eitdk.azurewebsites.net/api/Shipping/BestShippingRoute";
                    break;
                case TransportationModeEnum.Land:
                    URL = "http://wa-tldk.azurewebsites.net/api/ShippingRequest";
                    break;
                case TransportationModeEnum.Air:
                    return new APIReponse();
                default:
                    return new APIReponse();
            }
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = GetJsonData(date, weight, height, length, width);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                APIReponse responseRootObject = JsonConvert.DeserializeObject<APIReponse>(result);

                return responseRootObject;
            }
        }

        public string GetJsonData(string date, float weight, float height, float length, float width)
        {
            var request = new RootObejct
            {
                date = date,
                weight = weight,
                height = height,
                length = length,
                width = width,
                parceltype = new Parceltype
                {
                    animal = false,
                    cautious = false,
                    heated = false,
                    nuclear = false,
                    recommended = false,
                    refrigerated = false,
                    weaponry = false
                }
            };

            var jsonString = JsonConvert.SerializeObject(request);
            return jsonString;
        }
    }
}