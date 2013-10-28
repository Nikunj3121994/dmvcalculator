using Microsoft.Practices.Unity;

namespace ps.dmv.common.Core
{
    /// <summary>
    /// ServiceLocator
    /// </summary>
    public class ServiceLocator
    {
        public static readonly ServiceLocator Instance = new ServiceLocator();
        private IUnityContainer _container;

        /// <summary>
        /// Prevents a default instance of the <see cref="ServiceLocator"/> class from being created.
        /// </summary>
        private ServiceLocator()
        {
        }

        /// <summary>
        /// Sets the container.
        /// </summary>
        /// <param name="unityContainer">The unity container.</param>
        public void SetContainer(IUnityContainer unityContainer)
        {
            _container = unityContainer;
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// Resolves the specified dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns></returns>
        public T Resolve<T>(params ResolverOverride[] overrides)
        {
            return _container.Resolve<T>(overrides);
        }

        /// <summary>
        /// Resolves the specified name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public T Resolve<T>(string name)
        {
            return _container.Resolve<T>(name);
        }
    }
}
