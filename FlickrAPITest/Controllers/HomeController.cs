using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using System.Linq;
using FlickrAPITest.Helper;
using FlickrAPITest.Models;
using FlickrAPITest.Repository;

namespace FlickrAPITest.Controllers
{
    /// <summary>
    /// The home controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: /Home/
        /// </summary>
        /// <returns>Returns an action result containing the view</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets images from repository
        /// </summary>
        /// <param name="tags">Tags that should be searched for in the repository</param>
        /// <returns>A Json object containing the images from the repository</returns>
        
        [HttpPost]
        public ActionResult GetImages(string tags)
        {
            var factory = new FlickrFactory();
            IRepository flickr = factory.Create();
            var response = flickr.GetImagesByTagsWIthCacheResponse(tags);

            List<FlickrImage> images = response.Obj.ToList();
            ViewBag.ImagesSource = response.IsLoadedFromCache ? "Loaded from cache" : "Loaded from flickr";

            return PartialView("_Images", images);
            
            
        }


    }
}
