﻿using System;
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
        private const string MergeMessageFormatSettingPrefix = "MessageFormat:";

        private const string DefaultMergeMessageFormat = "Merged #{0} from {1} for {2}";

        private static readonly ILog Logger = LogManager.GetLogger(typeof(SettingsService));

        public IProgramSettings TryParse(string filePath, out IList<string> errorMessages)
        {
            errorMessages = new List<string>();

            string errorMessage;
            var settingsLines = TryReadSettingsFile(filePath, out errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                errorMessages.Add(errorMessage);
                return null;
            }

            var settingsLinesArray = settingsLines.ToArray();
            var branches = ParseBranches(settingsLinesArray).ToArray();
            var mergeMessageFormat = ParseMergeMessageFormat(settingsLinesArray) ?? DefaultMergeMessageFormat;

            return new ProgramSettings(branches, mergeMessageFormat);
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

        private static string ParseMergeMessageFormat(IEnumerable<string> settingsLines)
        {
            return settingsLines
                .FirstOrDefault(settingsLine => settingsLine.StartsWith(MergeMessageFormatSettingPrefix))
                ?.Substring(MergeMessageFormatSettingPrefix.Length);
        }
    }
}