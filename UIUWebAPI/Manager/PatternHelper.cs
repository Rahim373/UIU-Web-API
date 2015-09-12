using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace UIUWebAPI.Manager
{
    public static class PatternHelper
    {
        public static List<string> GetNoticeTitle(string fullHtml)
        {
            List<string> Title = new List<string>();
            string getAnchorPattern = "bookmark.*</a>";
            string filterFirsttime = @"bookmark.{2}";
            string filterFinalTime = @"</a>";

            var matches = Regex.Matches(fullHtml, getAnchorPattern);    // bookmark">Title</a>
            for(int i = 0; i<matches.Count; i++)
            {
                string string1 = Regex.Replace(matches[i].ToString(), filterFirsttime, ""); // Title</a>
                string filtered = Regex.Replace(string1, filterFinalTime, "");
                Title.Add(FilterUnwantedCharecters(filtered)); // Title
            }
            return Title;
        }


        public static List<string> GetNoticeDate(string fullHtml)
        {
            List<string> Date = new List<string>();
            string getAnchorPattern = "box-date.*</span>";
            string filterFirsttime = @"box-date.{2}";
            string filterFinalTime = @"</span>";

            var matches = Regex.Matches(fullHtml, getAnchorPattern);    // bookmark">Title</a>
            for (int i = 0; i < matches.Count; i++)
            {
                string string1 = Regex.Replace(matches[i].ToString(), filterFirsttime, ""); // Title</a>
                string filtered = Regex.Replace(string1, filterFinalTime, "");
                Date.Add(filtered); // Title
            }
            return Date;
        }

        public static List<string> GetNoticeLink(string fullHtml)
        {
            List<string> Link = new List<string>();
            string getAnchorPattern = "entry-title.*rel";
            string filterFirsttime = @".*href.{2}";
            string filterFinalTime = @"/.{2}rel";

            var matches = Regex.Matches(fullHtml, getAnchorPattern);    // bookmark">Title</a>
            for (int i = 0; i < matches.Count; i++)
            {
                string string1 = Regex.Replace(matches[i].ToString(), filterFirsttime, ""); // Title</a>
                string filtered = Regex.Replace(string1, filterFinalTime, "");
                Link.Add(filtered); // Title
            }
            return Link;
        }

        public static string FilterUnwantedCharecters(string stringToFilter)
        {
            string finalString = stringToFilter.Replace("&#8211;", "-");
            finalString = finalString.Replace(@"Ã¢â‚¬â„¢", "'");
            finalString = finalString.Replace(@"Ã¢â‚¬â„¢", "`");
            finalString = finalString.Replace("&#8217;", "'");
            finalString = finalString.Replace("&#038;", "&");
            finalString = finalString.Replace("&#8220;", "\"");
            finalString = finalString.Replace("&#8221;", "\"");
            
            return finalString;
        } 
    }
}