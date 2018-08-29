using System;
using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Contracts.Repository;
using MergeMessage.Common.Enums;

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

        public string SingleModeMergeMessageFormat { get; private set; }

        public string MultiModeMergeMessageFormat { get; private set; }

        public string ChangesetNumberFormat { get; private set; }

        public ProgramMode ProgramMode { get; set; }

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

            SingleModeMergeMessageFormat = settings.SingleModeMergeMessageFormat;
            MultiModeMergeMessageFormat = settings.MultiModeMergeMessageFormat;
            ChangesetNumberFormat = settings.ChangesetNumberFormat;
            ProgramMode = settings.ProgramMode;
        }
    }
}