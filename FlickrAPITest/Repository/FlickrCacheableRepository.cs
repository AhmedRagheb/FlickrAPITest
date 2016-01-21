using System.Collections.Generic;
using FlickrAPITest.Cache;
using FlickrAPITest.Models;

namespace FlickrAPITest.Repository
{
    /// <summary>
    /// Acting as a cacheable repository for Flickr
    /// </summary>
    public class FlickrCacheableRepository : IRepository
    {
        readonly FlickrRepository _flickrRepository;

        public FlickrCacheableRepository() {
            _flickrRepository = new FlickrRepository();
        }

        /// <summary>
        /// Returns image based on the tag
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public CacheResponse<List<FlickrImage>> GetImagesByTagsWIthCacheResponse(string tags)
        {
            // Load the data from the cache if it exist
            return CacheHelper<List<FlickrImage>>.Get(tags, () => GetImagesByTags(tags));
            
        }

        public List<FlickrImage> GetImagesByTags(string tags)
        {
            return  _flickrRepository.GetImagesByTags(tags);
        }
    }
}
