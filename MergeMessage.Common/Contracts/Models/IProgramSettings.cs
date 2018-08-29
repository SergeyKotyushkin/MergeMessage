using MergeMessage.Common.Enums;

namespace MergeMessage.Common.Contracts.Models
{
    public interface IProgramSettings
    {
        IBranch[] Branches { get; }

        string SingleModeMergeMessageFormat { get; }

        string MultiModeMergeMessageFormat { get; }

        string ChangesetNumberFormat { get; }

        ProgramMode ProgramMode { get; }
    }
}