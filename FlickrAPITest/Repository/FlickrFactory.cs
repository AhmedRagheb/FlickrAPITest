using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using FlickrAPITest.Helper;

namespace FlickrAPITest.Repository
{
    public class FlickrFactory
    {
        private static Type RepoType;

        public Type GetRepoType()
        {
            if (RepoType == null)
            {

                RepoType = (from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.GetInterfaces().Contains(typeof (IRepository))
                          && t.GetConstructor(Type.EmptyTypes) != null
                          && t.Name == Configurations.GetRepository()
                    select t).FirstOrDefault();

            }

            return RepoType;
        }
        public IRepository Create()
        {
            var type = GetRepoType();
            IRepository instance = Activator.CreateInstance(type) as IRepository;

            return instance ?? new FlickrRepository();
        }
    }
}