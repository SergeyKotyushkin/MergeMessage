namespace MergeMessage.Common.Contracts.Models
{
    public interface IBranch
    {
        string Name { get; }

        string Format { get; }

        string AdditionalLabel { get; }

        bool IsAdditionalNeeded { get; }
    }
}