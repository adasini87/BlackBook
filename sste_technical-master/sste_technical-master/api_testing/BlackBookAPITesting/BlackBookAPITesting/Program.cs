using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using Newtonsoft.Json;

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
                    //Console.WriteLine("GET");
                    var byteArray = Encoding.ASCII.GetBytes("RGSZQrvO:enrKTFzr");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    HttpResponseMessage httpresponse = await client.GetAsync(url1);
                    //EffectiveParameters epresponse = new EffectiveParameters();
                    


                    if (httpresponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("The Response for the request is 200 Status code");
                        Result list1 = await httpresponse.Content.ReadAsAsync<Result>();                        
                        Console.WriteLine(list1.error_count);
                        Console.WriteLine(list1.warning_count);
                        
                        bool check = false;
                        foreach(var v in list1.message_list)
                        {
                            if(v.type.ToLower()=="error")
                            {
                                check = true;
                                break;
                            }
                        }
                        if(check==true)
                            Console.WriteLine("Message List Type has error type");
                        else
                            Console.WriteLine("Message List Type has no error type");

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
