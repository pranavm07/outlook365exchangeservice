using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;

namespace Service.Utility
{
    public class FileHandler
    {
        public static string GetContents()
        {
            var path1 = HttpRuntime.AppDomainAppPath;
            string path = Path.Combine(path1, @"Content\contacts.html");
            string filecontent = File.ReadAllText(path);
            return filecontent;
        }
    }
}