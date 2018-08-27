using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Models
{
    public class TfsChangeset : ITfsChangeset
    {
        public TfsChangeset(string changeset, string user, string date, string comment)
        {
            Changeset = changeset;
            User = user;
            Date = date;
            Comment = comment;
        }
        
        public string Changeset { get; }

        public string User { get; }

        public string Date { get; }

        public string Comment { get; }
    }
}