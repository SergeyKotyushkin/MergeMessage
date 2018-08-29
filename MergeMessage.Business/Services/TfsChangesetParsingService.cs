using System;
using System.Collections.Generic;
using System.Linq;
using log4net;

using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Contracts.Repository;
using MergeMessage.Common.Contracts.Services;
using MergeMessage.Common.Models;

namespace MergeMessage.Business.Services
{
    public class TfsChangesetParsingService : ITfsChangesetParsingService
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TfsChangesetParsingService));

        private readonly IProgramSettingsRepository _programSettingsRepository;

        public TfsChangesetParsingService(IProgramSettingsRepository programSettingsRepository)
        {
            _programSettingsRepository = programSettingsRepository;
        }

        public ITfsChangesetParsingResult Parse(string inputMessagesData)
        {
            if (string.IsNullOrEmpty(inputMessagesData))
            {
                return CreateErrorResult("Input message is empty");
            }

            var inputMessages = inputMessagesData.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            if (inputMessages.Length == 0)
            {
                return CreateErrorResult("No one non-empty message");
            }

            var parsingResult = new TfsChangesetParsingResult();
            for (var i = 0; i < inputMessages.Length; i++)
            {
                string errorMessage;
                var tfsChangeset = ParseMessageLine(inputMessages[i], out errorMessage);

                if (tfsChangeset == null)
                {
                    parsingResult.Errors.Add($"Non-empty message on line #{i + 1}: {errorMessage}");
                }
                else
                {
                    parsingResult.TfsCommitLines.Add(tfsChangeset);
                }
            }

            return parsingResult;
        }

        public ITfsChangeset ParseMessageLine(string inputMessage, out string errorMessage)
        {
            errorMessage = string.Empty;

            string parsedCommitNumber;
            string parsedAuthor;
            string dateTimeString;
            string parsedCommitMessage;

            var inputMessageSplits = inputMessage.Split('\t');
            if (inputMessageSplits.Length > 0)
            {
                parsedCommitNumber = inputMessageSplits[0];
            }
            else
            {
                errorMessage = "could not find a Commit Number from the Input Message";
                return null;
            }

            if (inputMessageSplits.Length > 1)
            {
                parsedAuthor = inputMessageSplits[1];
            }
            else
            {
                errorMessage = "could not find a Commit User from the Input Message";
                return null;
            }
            
            if (inputMessageSplits.Length > 2)
            {
                dateTimeString = inputMessageSplits[2];
            }
            else
            {
                errorMessage = "could not find a Commit Time from the Input Message";
                return null;
            }
            
            if (inputMessageSplits.Length > 3)
            {
                var taskPrefix = _programSettingsRepository.ChangesetTaskPrefix;
                var commitMessageNumberIndex = inputMessageSplits[3].IndexOf(taskPrefix, StringComparison.InvariantCulture);
                if (commitMessageNumberIndex == -1)
                {
                    errorMessage = "could not find a Commit Message Number from the Input Message";
                    return null;
                }

                parsedCommitMessage = inputMessageSplits[3].Substring(commitMessageNumberIndex).Trim();
            }
            else
            {
                errorMessage = "could not find a Commit Message from the Input Message";
                return null;
            }

            var parsedCommitTaskNumber = ParseCommitTaskNumber(parsedCommitMessage);

            return new TfsChangeset(
                parsedCommitNumber, 
                parsedAuthor, 
                dateTimeString, 
                parsedCommitMessage,
                parsedCommitTaskNumber);
        }

        private static ITfsChangesetParsingResult CreateErrorResult(string message)
        {
            Logger.Warn(message);

            var errors = new List<string>(1) {message};
            return new TfsChangesetParsingResult {Errors = errors};
        }

        private static string ParseCommitTaskNumber(string parsedCommitMessage)
        {
            var parsedCommitTaskNumber = parsedCommitMessage.Split(' ').FirstOrDefault() ?? string.Empty;
            var endTaskNumberIndex = parsedCommitTaskNumber.LastIndexOfAny("0123456789".ToCharArray());
            if (endTaskNumberIndex == -1)
            {
                return parsedCommitTaskNumber;
            }

            return parsedCommitTaskNumber.Substring(0, endTaskNumberIndex + 1);
        }
    }
}