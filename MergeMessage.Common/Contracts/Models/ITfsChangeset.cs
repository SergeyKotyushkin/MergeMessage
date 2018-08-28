namespace MergeMessage.Common.Contracts.Models
{
    public interface ITfsChangeset
    {
        string ChangesetNumber { get; }

        string User { get; }

        string Date { get; }

        string Comment { get; }

        string TaskNumber { get; }
    }
}