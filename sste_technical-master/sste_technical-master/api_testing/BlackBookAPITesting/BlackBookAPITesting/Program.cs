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
using System.Text.RegularExpressions;

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

        private static bool IsIntegerRegex(string value)
        {
            const string regex = @"^\d+.$";
            return Regex.IsMatch(value, regex);
        }

        public static async Task RunAsync(string url)
        {
            try
            {


                using (var client = new HttpClient())
                {
                    //Get Response Stream

                    string url1 = url+"/listings?uvc=2015300726&vin=1FTEW1EF8FFC45951&zipcode=30518";
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Console.WriteLine("GET");
                    var byteArray = Encoding.ASCII.GetBytes("RGSZQrvO:enrKTFzr");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    HttpResponseMessage httpresponse = await client.GetAsync(url1);
                    
                    //De-serialize and check for status code



                    if (httpresponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("The Response for the request is 200 Status code");
                        Result list1 = await httpresponse.Content.ReadAsAsync<Result>();                        


                        // check for type in message list
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

                        //check for listing msrp int type


                      // List < Listings1 > lstnData = new List<Listings1>(list1.listings);
                        bool intcheck = true;


                        foreach (var c in list1.listings)
                        {
                             if (!(IsIntegerRegex(Convert.ToString(c.msrp))))
                                {
                                    Console.WriteLine("listings[].msrp is  not an integer");
                                    intcheck = false;
                                    break;
                                }


                            }
                        

                        if (intcheck == true)
                        {
                            Console.WriteLine("listings[].msrp is an integer");
                        }

                        if (!(string.IsNullOrWhiteSpace(Convert.ToString(list1.effective_parameters))))
                        {
                            Console.WriteLine("effective_parameters key exists in JSON/XML");
                        }
                        else
                        {
                            Console.WriteLine("effective_parameters dont exists in JSON/XML");
                        }




                        Console.ReadKey();


                        //if(list1.has("effective_parameters"))
                        //{

                        //}

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
