using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Enums;

namespace MergeMessage.Common.Contracts.Repository
{
    public interface IProgramSettingsRepository
    {
        IBranch[] Branches { get; }

        string SingleModeMergeMessageFormat { get; }

        string MultiModeMergeMessageFormat { get; }

        string ChangesetNumberFormat { get; }

        string ChangesetTaskPrefix { get; }

        ProgramMode ProgramMode { get; set; }

        void SaveSettings(IProgramSettings settings);
    }
}