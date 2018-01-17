using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class HttpHelper
    { 
        public async Task<string> Send(List<KeyValuePair<string, string>> list, string url)
        {
            try
            {
                var cookieJar = new CookieContainer();
                var handler = new HttpClientHandler
                {
                    CookieContainer = cookieJar,
                    UseCookies = true,
                    UseDefaultCredentials = true
                };
               

                HttpClient client = new HttpClient(handler);
                
                client.DefaultRequestHeaders.Connection.Clear();
                client.DefaultRequestHeaders.ConnectionClose = false;
                //client.DefaultRequestHeaders.Add("Connection", "close");
                // The next line isn't needed in HTTP/1.1
                client.DefaultRequestHeaders.Connection.Add("Keep-Alive");
           
                var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(list) };
              
                //req.Headers.

                req.Headers.Connection.Clear();
                req.Headers.ConnectionClose = false;//.Add("Connection", "close");
                // The next line isn't needed in HTTP/1.1
                req.Headers.Connection.Add("Keep-Alive");

                var response = client.SendAsync(req);

                var res = response.Result.Content.ReadAsStringAsync();

                Uri uri = new Uri(url);
                var responseCookies = cookieJar.GetCookies(uri);
                foreach (Cookie cookie in responseCookies)
                {
                    string cookieName = cookie.Name;
                    string cookieValue = cookie.Value;
                }
                return string.Empty;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}
