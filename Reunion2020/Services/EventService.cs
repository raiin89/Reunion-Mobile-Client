using System;
using Reunion2020.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Reunion2020.Services;
using Reunion2020.Services.Helpers;

namespace Reunion2020.Services
{

    // This service is to fetch events data from the backend
    public class EventService
    {
        private const string EventsRoute =

            "http://165.227.129.108:3000/api/events/fetchapprovedevents"; // Rest API route


        // Gets all approved events from the API
        public async static Task GetApprovedEvents(Action<IEnumerable<Event>> action)
        {
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(EventsRoute);
                    var json = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var eventRoot = JsonConvert.DeserializeObject<Eventroot>(json);
                        var list = eventRoot.Data as IEnumerable<Event>;
                        foreach (Event item in list)
                        {

                            item.Image = ImageHelper.ImageFromBase64(item.ImagesBase64[0].ToString());

                        }
                        action(list);

                    }

                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message.ToString(), "Ok");
            }
            {

            }

        }










    }
}

