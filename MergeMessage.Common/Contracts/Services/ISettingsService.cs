using System.Collections.Generic;

using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Contracts.Services
{
    public interface ISettingsService
    {
        IBranch[] TryParse(string filePath, out IList<string> errorMessages);
    }
}