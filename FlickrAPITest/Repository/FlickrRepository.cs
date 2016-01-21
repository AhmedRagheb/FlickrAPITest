using System.Collections.Generic;
using System.Xml;
using FlickrAPITest.Cache;
using FlickrAPITest.Models;

namespace FlickrAPITest.Repository
{
    /// <summary>
    /// Acting as a repository for Flickr
    /// </summary>
    public class FlickrRepository : IRepository
    {

        // To see the raw data, have a look at
        // http://api.flickr.com/services/feeds/photos_public.gne?tags=cats


        public CacheResponse<List<FlickrImage>> GetImagesByTagsWIthCacheResponse(string tags)
        {
            var images = GetImagesByTags(tags);
            var response = new CacheResponse<List<FlickrImage>>
            {
                Obj = images,
                IsLoadedFromCache = false
            };
            return response;
        }

        /// <summary>
        /// Returns the image
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public List<FlickrImage> GetImagesByTags(string tags)
        {
            var nodes = LoadData(tags);
            var images = new List<FlickrImage>();

            foreach (XmlNode item in nodes)
            {
                var image = new FlickrImage {Title = item.FirstChild.InnerText};
                var xmlAttributeCollection = item.ChildNodes[9].Attributes;
                if (xmlAttributeCollection != null){ 
                    image.ImageUrl = xmlAttributeCollection["href"].Value;
                }
                if (!image.ImageUrl.Contains("creativecommons"))
                {
                    images.Add(image);
                }
            }

            return images;
        }

        /// <summary>
        /// Load data from flickr
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        private XmlNodeList LoadData(string tags){
            var xdoc = new XmlDocument();//xml doc used for xml parsing
            xdoc.Load(string.Format("http://api.flickr.com/services/feeds/photos_public.gne?tags={0}",tags));
            var xNodelst = xdoc.GetElementsByTagName("entry");
            return xNodelst;
        }
    }

}
