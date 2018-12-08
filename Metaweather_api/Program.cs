using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;


namespace Metaweather
{
    class Program
    {
        const string baseurl = "https://www.metaweather.com/api";
        const string query = "Boston";

        static void Main(string[] args)
        {
            Task t = new Task(APILocationSearch);
            t.Start();
            Console.ReadLine();
        }

        static async void APILocationSearch()
        {
            string requestUrl = string.Format("{0}/location/search/?query={1}", baseurl, query);
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync(requestUrl))
                    {
                        HttpContent content = response.Content;
                        string result = await content.ReadAsStringAsync();
                        var locations = DeserializeJSON<List<Location>>(result);
                        foreach (Location l in locations)
                        {
                            Console.WriteLine("{0} Type: {1} ID: {2}", l.Title, l.Location_Type, l.WoeID);
                            APIWoeid(l.WoeID);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async void APIWoeid(string woeid)
        {
            string requestUrl = string.Format("{0}/location/{1}/", baseurl, woeid);
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (HttpResponseMessage response = await httpClient.GetAsync(requestUrl))
                    {
                        HttpContent content = response.Content;
                        string result = await content.ReadAsStringAsync();
                        var location = DeserializeJSON<LocationWeather>(result);
                        Console.WriteLine("Location: {0} TimeZone: {1} Time: {2}", location.Title, location.TimeZone_Name, location.Time);
                        foreach (Consolidated_Weather cw in location.Consolidated_Weather)
                        {
                            Console.WriteLine("Date: {2} Conditions: {0} Temp: {1}", cw.Weather_State_Name, cw.The_Temp, cw.Applicable_Date);
                        }
                        Console.WriteLine("Average of {0} over the next {1} days.", location.Consolidated_Weather.Average(cw => cw.The_Temp), location.Consolidated_Weather.Count);
                        Console.WriteLine("High: {0} Low: {1}", location.Consolidated_Weather.Max(cw => cw.The_Temp), location.Consolidated_Weather.Min(cw => cw.The_Temp));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static T DeserializeJSON<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            T data = (T)serializer.ReadObject(stream);
            return data;
        }
    }
}
