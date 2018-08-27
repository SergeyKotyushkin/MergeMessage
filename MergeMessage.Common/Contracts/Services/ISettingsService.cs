using System.Collections.Generic;

using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Contracts.Services
{
    public interface ISettingsService
    {
        IProgramSettings TryParse(string filePath, out IList<string> errorMessages);
    }
}