using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using UIUWebAPI.Models;

namespace UIUWebAPI.Manager
{
    public static class HtmlHelperClass
    {
        public static List<Notices> GetAllNotices(string link)
        {
            string htmlPage = "";
            List<string> NoticeTitles = new List<string>();
            List<string> NoticeDates = new List<string>();
            List<string> NoticeUrl = new List<string>();

            List<Notices> Notices = new List<Notices>();

            using(var client = new WebClient())
            {
                Uri weblink = new Uri(link, UriKind.Absolute);
                htmlPage = client.DownloadString(weblink);
            }

            NoticeTitles = PatternHelper.GetNoticeTitle(htmlPage);
            NoticeDates = PatternHelper.GetNoticeDate(htmlPage);
            NoticeUrl = PatternHelper.GetNoticeLink(htmlPage);

            foreach(var item in NoticeTitles)
            {
                Notices.Add(new Notices {
                    Title = item,
                    Date = NoticeDates[NoticeTitles.IndexOf(item)],
                    Url = NoticeUrl[NoticeTitles.IndexOf(item)]
                });
            }
            
            return Notices;
            
        }
    }
}