using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace Findly.Admin
{
	public class AdminApplication : IApplicationSource
	{
	    public FubuApplication BuildApplication()
	    {
            return FubuApplication.For<AdminFubuRegistry>()
				.StructureMap<AdminRegistry>();
	    }
	}
}