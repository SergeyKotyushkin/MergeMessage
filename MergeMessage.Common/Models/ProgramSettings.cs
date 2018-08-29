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
            ProgramMode programMode = ProgramMode.Single)
        {
            Branches = branches;
            SingleModeMergeMessageFormat = singleModeMergeMessageFormat;
            MultiModeMergeMessageFormat = multiModeMergeMessageFormat;
            ChangesetNumberFormat = changesetNumberFormat;
            ProgramMode = programMode;
        }

        public IBranch[] Branches { get; }

        public string SingleModeMergeMessageFormat { get; }

        public string MultiModeMergeMessageFormat { get; }

        public string ChangesetNumberFormat { get; }

        public ProgramMode ProgramMode { get; }
    }
}