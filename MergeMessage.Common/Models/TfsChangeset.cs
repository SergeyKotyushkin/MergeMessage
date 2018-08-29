using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Models
{
    public class TfsChangeset : ITfsChangeset
    {
        public TfsChangeset(string changesetNumber, string user, string date, string comment, string taskNumber)
        {
            ChangesetNumber = changesetNumber;
            User = user;
            Date = date;
            Comment = comment;
            TaskNumber = taskNumber;
        }

        public string ChangesetNumber { get; }

        public string User { get; }

        public string Date { get; }

        public string Comment { get; }

        public string TaskNumber { get; }
    }
}