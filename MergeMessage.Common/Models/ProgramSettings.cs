using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Enums;

namespace MergeMessage.Common.Models
{
    public class ProgramSettings : IProgramSettings
    {
        public ProgramSettings(IBranch[] branches, string mergeMessageFormat, ProgramMode programMode = ProgramMode.Single)
        {
            Branches = branches;
            MergeMessageFormat = mergeMessageFormat;
            ProgramMode = programMode;
        }

        public IBranch[] Branches { get; }

        public string MergeMessageFormat { get; }

        public ProgramMode ProgramMode { get; }
    }
}