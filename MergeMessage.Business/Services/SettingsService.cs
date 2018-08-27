using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using log4net;

using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Contracts.Services;
using MergeMessage.Common.Models;

namespace MergeMessage.Business.Services
{
    public class SettingsService : ISettingsService
    {
        private const string BranchSettingPrefix = "Branch:";

        private static readonly ILog Logger = LogManager.GetLogger(typeof(SettingsService));

        public IBranch[] TryParse(string filePath, out IList<string> errorMessages)
        {
            errorMessages = new List<string>();

            string errorMessage;
            var settingsLines = TryReadSettingsFile(filePath, out errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                errorMessages.Add(errorMessage);
                return null;
            }

            var branches = ParseBranches(settingsLines).ToArray();

            return branches;
        }

        private static IEnumerable<string> TryReadSettingsFile(string filePath, out string errorMessage)
        {
            errorMessage = null;

            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception)
            {
                errorMessage = "An error occured while the settings file reading.";
                Logger.Error(errorMessage);
                return null;
            }
        }

        private static IEnumerable<IBranch> ParseBranches(IEnumerable<string> settingsLines)
        {
            return settingsLines
                .Where(settingsLine => settingsLine.StartsWith(BranchSettingPrefix))
                .Select(settingsLine => settingsLine.Substring(BranchSettingPrefix.Length).Split(','))
                .Where(branchSplits => branchSplits.Length > 1)
                .Select(branchSplits =>
                {
                    var additionalLabel = branchSplits.Length == 2 ? null : branchSplits[2];
                    return new Branch(branchSplits[0], branchSplits[1], additionalLabel);
                });
        }
    }
}