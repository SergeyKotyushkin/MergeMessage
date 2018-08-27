namespace MergeMessage.Common.Contracts.Models
{
    public interface ITfsChangeset
    {
        string Changeset { get; }

        string User { get; }

        string Date { get; }

        string Comment { get; }
    }
}