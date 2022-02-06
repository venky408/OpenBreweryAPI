using Newtonsoft.Json;
using OpenBreweryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OpenBreweryAPI.APIHelper
{
    // static class creates and single copy of objects. Since i do not need to test these methods, i'm making them as static.
    public static class OpenBreweryAPIHelper
    {
        public static List<OpenBreweryModel> GetAllBreweries()
        {
            List<OpenBreweryModel> breweryList = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseHelper.BASE_URI);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET ALL BREWERIES.
                    HttpResponseMessage response = client.GetAsync(BaseHelper.GET_ALL_BREWERY_URL).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //breweryList = new List<OpenBreweryModel>();
                        var jsonString = response.Content.ReadAsStringAsync();
                        breweryList = JsonConvert.DeserializeObject<List<OpenBreweryModel>>(jsonString.Result);
                    }
                }
            }

            catch(Exception ex)
            {
                // log exception.
            }

            return breweryList;
        }

        public static OpenBreweryModel GetBrewery(string breweryName, string breweryId)
        {
            OpenBreweryModel brewery = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseHelper.BASE_URI);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //var input = new { by_name = breweryName };
                    //string json = JsonConvert.SerializeObject(input);
                    //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    // HTTP GET BREWERY.
                    //HttpResponseMessage response = client.GetAsync($"breweries?by_name={breweryName}").Result;

                    HttpResponseMessage response = client.GetAsync($"{BaseHelper.GET_BREWERY_URL}{breweryName}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //brewery = new List<OpenBreweryModel>();
                        var jsonString = response.Content.ReadAsStringAsync();
                        var breweryList = JsonConvert.DeserializeObject<List<OpenBreweryModel>>(jsonString.Result);

                        // returns mulitple breweries by same name, we need to filter the list by Id to get the selected brewery.
                        brewery = breweryList.Where(x => string.Equals(x.id, breweryId)).FirstOrDefault();
                    }
                }
            }

            catch (Exception ex)
            {
                // log exception.
            }

            return brewery;
        }
    }
}
