using System;
using System.Collections.Generic;

using log4net;

using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Contracts.Services;
using MergeMessage.Common.Models;

namespace MergeMessage.Business.Services
{
    public class TfsChangesetParsingService : ITfsChangesetParsingService
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(TfsChangesetParsingService));

        public ITfsChangesetParsingResult Parse(string inputMessage)
        {
            if (string.IsNullOrEmpty(inputMessage))
            {
                return CreateErrorResult("Input message is empty");
            }

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
                return CreateErrorResult("Could not find a Commit Number from the Input Message");
            }

            if (inputMessageSplits.Length > 1)
            {
                parsedAuthor = inputMessageSplits[1];
            }
            else
            {
                return CreateErrorResult("Could not find a Commit User from the Input Message");
            }
            
            if (inputMessageSplits.Length > 2)
            {
                dateTimeString = inputMessageSplits[2];
            }
            else
            {
                return CreateErrorResult("Could not find a Commit Time from the Input Message");
            }
            
            if (inputMessageSplits.Length > 3)
            {
                parsedCommitMessage = inputMessageSplits[3]
                    .Substring(inputMessageSplits[3].IndexOf("VW-", StringComparison.InvariantCulture)).Trim();
            }
            else
            {
                return CreateErrorResult("Could not find a Commit Message from the Input Message");
            }

            return new TfsChangesetParsingResult
            {
                Errors = new List<string>(0),
                TfsCommitLine = new TfsChangeset(parsedCommitNumber, parsedAuthor, dateTimeString, parsedCommitMessage)
            };
        }

        private static ITfsChangesetParsingResult CreateErrorResult(string message)
        {
            Logger.Warn(message);

            var errors = new List<string>(1) {message};
            return new TfsChangesetParsingResult {Errors = errors};
        }
    }
}