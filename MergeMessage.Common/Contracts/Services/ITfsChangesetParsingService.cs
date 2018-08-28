using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Contracts.Services
{
    public interface ITfsChangesetParsingService
    {
        ITfsChangesetParsingResult Parse(string inputMessages);
    }
}