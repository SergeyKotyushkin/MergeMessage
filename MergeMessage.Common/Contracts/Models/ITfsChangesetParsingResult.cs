using System.Collections.Generic;

namespace MergeMessage.Common.Contracts.Models
{
    public interface ITfsChangesetParsingResult
    {
        IList<string> Errors { get; set; }

        ITfsChangeset TfsCommitLine { get; set; }

        bool HasErrors { get; }
    }
}