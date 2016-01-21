using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlickrAPITest.Cache
{
    public class CacheResponse<T>
    {
        public bool IsLoadedFromCache { get; set; }
        public T Obj { get; set; }
    }
}
