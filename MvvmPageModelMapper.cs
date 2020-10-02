using System;
using FreshMvvm;

namespace Av_Planner_Demo.Helpers
{
    // Source: https://github.com/rid00z/FreshMvvm/issues/218
    public class MvvmPageModelMapper : IFreshPageModelMapper
    {
        readonly string _pageAssemblyName;
        readonly string _pageNamespace;

        public MvvmPageModelMapper(string pageNamespace = null, string pageAssemblyName = null)
        {
            _pageNamespace = pageNamespace;
            _pageAssemblyName = pageAssemblyName;
        }

        public string GetPageTypeName(Type pageModelType)
        {
            var assemblyQualifiedName = pageModelType.AssemblyQualifiedName;

            // Replace Namespace
            if (_pageNamespace != null)
                assemblyQualifiedName = assemblyQualifiedName?.Replace(pageModelType.Namespace, _pageNamespace);

            // Replace Assembly
            if (_pageAssemblyName != null)
                assemblyQualifiedName =
                    assemblyQualifiedName?.Replace(pageModelType.Assembly.ToString(), _pageAssemblyName);

            // Replace "Model"
            assemblyQualifiedName = assemblyQualifiedName?.Replace("PageModel", "Page")
                .Replace("ViewModel", "Page");

            return assemblyQualifiedName;
        }
    }
}
