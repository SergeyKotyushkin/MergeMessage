using System.Collections.Generic;

namespace MergeMessage.Common.Contracts.Models
{
    public interface ITfsChangesetParsingResult
    {
        IList<string> Errors { get; set; }

        IList<ITfsChangeset> TfsCommitLines { get; set; }

        bool HasErrors { get; }
    }
}