using System.Collections.Generic;
using FlickrAPITest.Cache;
using FlickrAPITest.Models;

namespace FlickrAPITest.Repository
{
    /// <summary>
    /// The Repository interface
    /// </summary>
    public interface IRepository
    {
        CacheResponse<List<FlickrImage>> GetImagesByTagsWIthCacheResponse(string tags);
        List<FlickrImage> GetImagesByTags(string tags);
    }
}
