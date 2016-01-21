using System.Web.Mvc;

namespace FlickrAPITest.App_Start
{
    /// <summary>
    /// Handles filter configuration
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers global filters
        /// </summary>
        /// <param name="filters">Collection of filters</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}