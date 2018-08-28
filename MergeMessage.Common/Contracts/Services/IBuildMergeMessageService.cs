using System.Collections.Generic;
using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Contracts.Services
{
    public interface IBuildMergeMessageService
    {
        string[] Build(IList<ITfsChangeset> tfsChangesets, IBranch branch, string additionalText);
    }
}