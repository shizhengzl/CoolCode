﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UsuallyCommon;
using System.Net.Http;

namespace Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            SendEmail("ddd");
        }

        public static void SendEmail(string content)
        {
            EmailHelper.SendEmail("415552548@qq.com", "omgyvfhsugztbhcc", "13701859214@qq.com", "", "works", content, "smtp.qq.com", 25);
        }


        public static async void Send()
        {
            try
            { 
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                list.Add(new KeyValuePair<string, string>("username", "shizhenglock"));
                list.Add(new KeyValuePair<string, string>("password", "shizi120"));
                string url = "https://www.365vip22.com";

                var response =  new HttpHelper().Send(list, url);
                
                Console.Write(response);

                Console.ReadLine(); 
            }
            catch (Exception e)
            {

            }
        }
    }
}
