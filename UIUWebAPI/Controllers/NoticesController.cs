using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using UIUWebAPI.Manager;
using Newtonsoft.Json;

namespace UIUWebAPI.Controllers
{
    public class NoticesController : ApiController
    {
        public HttpResponseMessage GetNotices()
        {
            var notice = HtmlHelperClass.GetAllNotices(@"http://uiu.ac.bd/?post_type=notice");
            string content = JsonConvert.SerializeObject(notice);
            var response = new HttpResponseMessage() { Content = new StringContent(content) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }


        public HttpResponseMessage GetNotices(string id)
        {
            var notice = HtmlHelperClass.GetAllNotices(@"http://uiu.ac.bd/page/"+ id +"/?post_type=notice");
            string content = JsonConvert.SerializeObject(notice);
            var response = new HttpResponseMessage() { Content = new StringContent(content) };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }
    }
}
