using FubuMVC.Core;
using FubuMVC.RavenDb;
using FubuPersistence.RavenDb;

namespace Findly.Admin
{
	public class AdminFubuRegistry : FubuRegistry
	{
		public AdminFubuRegistry()
		{
			// Register any custom FubuMVC policies, inclusions, or 
			// other FubuMVC configuration here
			// Or leave as is to use the default conventions unchanged
            var dbSettings = new RavenDbSettings
            {
                RunInMemory = true,
                UseEmbeddedHttpServer = true
            };
            Services(x =>
            {
                x.AddService(dbSettings);
                x.AddService<IDocumentStoreConfigurationAction, SimpleEmbeddedRavenDbPortConfigurationAction>();
            });
            Import<RavenDbFubuRegistryExtension>();
		    
            Actions.IncludeClassesSuffixedWithController();
		    Actions.IncludeClassesSuffixedWithEndpoint();
		    Routes.IgnoreNamespaceText("Findly.Admin");
		}
	}
}