using System;
using System.Web;

namespace FlickrAPITest.Cache
{
    public static class CacheHelper<T>
    {

        /// <summary>
        /// Simple cache helper
        /// </summary>
        /// <param name="key">The cache key used to reference the item.</param>
        /// <param name="function">The underlying method that referes to the object to be stored in the cache.</param>
        /// <returns>The item</returns>
        public static CacheResponse<T> Get(string key, Func<T> function)
        {
            var response = new CacheResponse<T>();

            var obj = HttpContext.Current.Cache[key];
            response.IsLoadedFromCache = true;

            if (obj == null)
            {
                response.IsLoadedFromCache = false;
                obj = function.Invoke();
                HttpContext.Current.Cache.Add(key, obj, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero,
                    System.Web.Caching.CacheItemPriority.Normal, null);
            }
            response.Obj = (T)obj;
            return response;
        }
    }

   
}