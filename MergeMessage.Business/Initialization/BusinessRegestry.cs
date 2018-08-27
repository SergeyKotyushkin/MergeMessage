using MergeMessage.Business.Repository;
using MergeMessage.Business.Services;
using MergeMessage.Common.Contracts.Services;

using StructureMap;

namespace MergeMessage.Business.Initialization
{
    public class BusinessRegestry : Registry
    {
        public BusinessRegestry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions();
            });

            For<IBranchRepository>().Use<BranchRepository>().Singleton();
            For<ISettingsService>().Use<SettingsService>();
            For<ITfsChangesetParsingService>().Use<TfsChangesetParsingService>();
            For<IAlertService>().Use<WindowsMessageBoxAlertService>();
        }
    }
}