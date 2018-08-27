using System;
using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Contracts.Repository;

namespace MergeMessage.Business.Repository
{
    public class ProgramSettingsRepository : IProgramSettingsRepository
    {
        private readonly IBranchRepository _branchRepository;

        public ProgramSettingsRepository(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public IBranch[] Branches { get; private set; }

        public string MergeMessageFormat { get; private set; }

        public void SaveSettings(IProgramSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Branches = settings.Branches;
            foreach (var branch in Branches)
            {
                _branchRepository.Save(branch);
            }

            MergeMessageFormat = settings.MergeMessageFormat;
        }
    }
}