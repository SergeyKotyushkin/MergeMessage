using System.Collections.Generic;
using System.Linq;

using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Models
{
    public class TfsChangesetParsingResult : ITfsChangesetParsingResult
    {
        public IList<string> Errors { get; set; } = new List<string>();

        public IList<ITfsChangeset> TfsCommitLines { get; set; } = new List<ITfsChangeset>();

        public bool HasErrors => Errors.Any();
    }
}