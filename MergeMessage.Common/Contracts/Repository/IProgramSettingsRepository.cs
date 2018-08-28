using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Enums;

namespace MergeMessage.Common.Contracts.Repository
{
    public interface IProgramSettingsRepository
    {
        IBranch[] Branches { get; }

        string MergeMessageFormat { get; }

        ProgramMode ProgramMode { get; set; }

        void SaveSettings(IProgramSettings settings);
    }
}