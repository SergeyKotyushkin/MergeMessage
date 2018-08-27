namespace MergeMessage.Common.Contracts.Models
{
    public interface IProgramSettings
    {
        IBranch[] Branches { get; }

        string MergeMessageFormat { get; }
    }
}