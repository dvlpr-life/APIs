using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;


namespace Venmo
{
    class Program
    {
        const string baseURL = "https://venmo.com";
        static public string nextURL = string.Empty;
        static void Main(string[] args)
        {
            string key = string.Empty;
            while (true)
            {
                APIVenmo();
                key = Console.ReadLine();
                if (key.Equals("e"))
                {
                    break;
                }
            }

            //Task t = new Task(APIVenmo);
            //t.Start();
            //Console.ReadLine();
        }

        static void APIVenmo()
        {
            string requestUrl = (nextURL == string.Empty) ? string.Format("{0}/api/v5/public", baseURL) : nextURL;
            string result = string.Empty;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (HttpResponseMessage response = httpClient.GetAsync(requestUrl).Result)
                    {
                        HttpContent content = response.Content;
                        result = content.ReadAsStringAsync().Result;
                        var apiresult = DeserializeJSON<APIResult>(result);
                        Console.WriteLine("\nNext: {0}\nPrev: {1}\n", apiresult.Paging.Next, apiresult.Paging.Previous);
                        foreach (Data d in apiresult.Data)
                        {
                            Console.WriteLine("Created: {3}\nID: {0} Username: {1} Name: {2}", d.Payment_ID, d.Actor.UserName, d.Actor.Name, d.Created_Time);
                            foreach (Transaction t in d.Transactions)
                            {
                                Console.WriteLine("Target: {0} {1}", t.Target.UserName, t.Target.Name);
                            }
                            Console.WriteLine("{0}\n\n", d.Message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(result);
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
