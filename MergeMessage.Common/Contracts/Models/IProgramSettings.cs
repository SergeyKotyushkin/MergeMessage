using MergeMessage.Common.Enums;

namespace MergeMessage.Common.Contracts.Models
{
    public interface IProgramSettings
    {
        IBranch[] Branches { get; }

        string MergeMessageFormat { get; }

        ProgramMode ProgramMode { get; }
    }
}