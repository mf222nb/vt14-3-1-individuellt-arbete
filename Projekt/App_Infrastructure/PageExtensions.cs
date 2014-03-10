using Projekt.Pages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Projekt.Pages.Shared
{
    public static class PageExtensions
    {
        public static object GetTempData(this Site page, string key)
        {
            var value = page.Session[key];
            page.Session.Remove(key);
            return value;
        }
    }
}
namespace Projekt.Pages
{
    public static class PageExtensions
    {
        public static void SetTempData(this Page page, string key, object value)
        {
            page.Session[key] = value;
        }
    }
}