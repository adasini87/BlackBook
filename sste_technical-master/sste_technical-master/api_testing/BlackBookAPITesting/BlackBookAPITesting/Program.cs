using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;

namespace BlackBookAPITesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpoint = "https://sste-test.blackbookcloud.com/retailapi/retailapi";
            RunAsync(endpoint).Wait();
            //System.Threading.Thread.Sleep(10000);
            Console.ReadLine();

        }

        public static async Task RunAsync(string url)
        {
            try
            {


                using (var client = new HttpClient())
                {
                    //Get Data

                    string url1 = url+"/listings?uvc=2015300726&vin=1FTEW1EF8FFC45951&zipcode=30518";
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    Console.WriteLine("GET");
                    var byteArray = Encoding.ASCII.GetBytes("RGSZQrvO:enrKTFzr");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    HttpResponseMessage response = await client.GetAsync(url1);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("The Response for the request is 200 Status code");

                        Console.ReadKey();

                    }
                }
            }

            catch (WebException exp)
            {
                Console.WriteLine(exp);

            }

        }
    }
}
