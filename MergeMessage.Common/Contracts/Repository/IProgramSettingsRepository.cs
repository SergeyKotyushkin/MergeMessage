using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Contracts.Repository
{
    public interface IProgramSettingsRepository
    {
        IBranch[] Branches { get; }

        string MergeMessageFormat { get; }

        void SaveSettings(IProgramSettings settings);
    }
}