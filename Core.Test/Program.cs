using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UsuallyCommon;
using System.Net.Http;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace Core.Test
{
     

    class Program
    { // <Snippet1>
        const string programText =
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
 
namespace TopLevel
{
    using Microsoft;
    using System.ComponentModel;
 
    namespace Child1
    {
        using Microsoft.Win32;
        using System.Runtime.InteropServices;
 
        class Foo { }
    }
 
    namespace Child2
    {
        using System.CodeDom;
        using Microsoft.CSharp;
 
        class Bar { }
    }
}";
        static void Main(string[] args)
        {
            string path = @"D:\code\中南建设\源代码\分支4\明源整体解决方案\Mysoft.Fygl.Services\Apply\ApplyService.cs";
            CSharpParserHelper parser = new CSharpParserHelper(UsuallyCommon.IoHelper.FileReader(path));

            //var s = parser.GetUsing();

            //foreach (var item in s)
            //{
            //    Console.WriteLine(item);
            //}
             


            var res = parser.collector.classList;

            foreach (var item in res)
            {
                foreach (var method in item.Methods)
                {
                    string Params = string.Join(",", method.MethodArguments.Select(x => x.Name).ToList<string>().ToArray());
                    Console.WriteLine($"MethodName:{method.Name},Params:{Params}");
                }
            }
            //string key = "0123456789ABCDEF";
            //string message = "你是大傻b";
            Console.ReadLine();
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
