using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace WebLabs_V2.Services
{
    public class NinjectDependencyresolver : IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependencyresolver(IKernel krnl)
        {
            kernel = krnl;
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);            
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}