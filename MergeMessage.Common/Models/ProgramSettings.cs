using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Enums;

namespace MergeMessage.Common.Models
{
    public class ProgramSettings : IProgramSettings
    {
        public ProgramSettings(
            IBranch[] branches, 
            string singleModeMergeMessageFormat, 
            string multiModeMergeMessageFormat, 
            string changesetNumberFormat, 
            string changesetTaskPrefix, 
            ProgramMode programMode = ProgramMode.Single)
        {
            Branches = branches;
            SingleModeMergeMessageFormat = singleModeMergeMessageFormat;
            MultiModeMergeMessageFormat = multiModeMergeMessageFormat;
            ChangesetNumberFormat = changesetNumberFormat;
            ChangesetTaskPrefix = changesetTaskPrefix;
            ProgramMode = programMode;
        }

        public IBranch[] Branches { get; }

        public string SingleModeMergeMessageFormat { get; }

        public string MultiModeMergeMessageFormat { get; }

        public string ChangesetNumberFormat { get; }

        public string ChangesetTaskPrefix { get; }

        public ProgramMode ProgramMode { get; }
    }
}