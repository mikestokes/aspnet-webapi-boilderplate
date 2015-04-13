using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace WebApi.Boilderplate.Helpers.DependencyInjection
{
    // Web Api 2 Dependency Resolver using Microsoft Unity
    //
    // I hate the way Web Api uses service location and calls it Dependency Injection and IoC!

    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer Container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return Container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            // Controllers are created per-request.
            return new UnityResolver(Container.CreateChildContainer());
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}