using System.Collections.Generic;
using System.Linq;

using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Models
{
    public class TfsChangesetParsingResult : ITfsChangesetParsingResult
    {
        public IList<string> Errors { get; set; }

        public ITfsChangeset TfsCommitLine { get; set; }

        public bool HasErrors => Errors.Any();
    }
}