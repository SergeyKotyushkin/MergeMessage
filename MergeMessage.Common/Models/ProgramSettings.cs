using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Models
{
    public class ProgramSettings : IProgramSettings
    {
        public ProgramSettings(IBranch[] branches, string mergeMessageFormat)
        {
            Branches = branches;
            MergeMessageFormat = mergeMessageFormat;
        }

        public IBranch[] Branches { get; }

        public string MergeMessageFormat { get; }
    }
}