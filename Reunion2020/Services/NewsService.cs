using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reunion2020.Models;
using Reunion2020.Services.Helpers;
using Xamarin.Forms;

namespace Reunion2020.Services
{
    // This service is to fetch News data from the Backend
    public class NewsService
    {
        private const string NewsRoute = "http://165.227.129.108:3000/api/news/fetchpublishednews";


        // Gets all published news from the API
        public async static Task GetPublishedNews(Action<IEnumerable<News>> action)
        {
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(NewsRoute);
                    var json = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var eventRoot = JsonConvert.DeserializeObject<NewsRoot>(json);
                        var list = eventRoot.Data as IEnumerable<News>;
                        foreach (News item in list)
                        {

                            item.Image = ImageHelper.ImageFromBase64(item.ImagesBase64[0].ToString());

                        }
                        action(list);

                    }

                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong while getting events", "Ok");

            }


        }
    }
}
