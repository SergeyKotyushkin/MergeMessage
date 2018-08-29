using System.Collections.Generic;
using System.Linq;
using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Contracts.Repository;
using MergeMessage.Common.Contracts.Services;
using MergeMessage.Common.Enums;

namespace MergeMessage.Business.Services
{
    public class BuildMergeMessageService : IBuildMergeMessageService
    {
        private readonly string _singleModeMergeMessageFormat;
        private readonly string _multiModeMergeMessageFormat;
        private readonly string _changesetNumberFormat;

        private readonly IProgramSettingsRepository _programSettingsRepository;

        public BuildMergeMessageService(IProgramSettingsRepository programSettingsRepository)
        {
            _programSettingsRepository = programSettingsRepository;

            _singleModeMergeMessageFormat = _programSettingsRepository.SingleModeMergeMessageFormat;
            _multiModeMergeMessageFormat = _programSettingsRepository.MultiModeMergeMessageFormat;
            _changesetNumberFormat = _programSettingsRepository.ChangesetNumberFormat;
        }

        public string[] Build(IList<ITfsChangeset> tfsChangesets, IBranch branch, string additionalText)
        {
            return _programSettingsRepository.ProgramMode == ProgramMode.Single
                ? BuildSingleMode(tfsChangesets, branch, additionalText)
                : BuildMultiMode(tfsChangesets, branch, additionalText);
        }

        private string[] BuildSingleMode(IList<ITfsChangeset> tfsChangesets, IBranch branch, string additionalText)
        {
            var builtMergeMessages = new string[tfsChangesets.Count];
            for (var i = 0; i < tfsChangesets.Count; i++)
            {
                builtMergeMessages[i] = BuildSingleModeMergeMessage(tfsChangesets[i], branch, additionalText);
            }

            return builtMergeMessages;
        }

        private string[] BuildMultiMode(IList<ITfsChangeset> tfsChangesets, IBranch branch, string additionalText)
        {
            return new[]
            {
                string.Format(
                    _multiModeMergeMessageFormat,
                    string.Join(", ", tfsChangesets.Select(i => string.Format(_changesetNumberFormat, i.ChangesetNumber))),
                    BuildBranchPartMessage(branch, additionalText),
                    string.Join(", ", tfsChangesets.Select(i => i.TaskNumber)))
            };
        }

        public string BuildSingleModeMergeMessage(ITfsChangeset tfsChangeset, IBranch branch, string additionalText)
        {
            return string.Format(
                _singleModeMergeMessageFormat,
                string.Format(_changesetNumberFormat, tfsChangeset.ChangesetNumber),
                BuildBranchPartMessage(branch, additionalText),
                tfsChangeset.Comment);
        }

        private static string BuildBranchPartMessage(IBranch branch, string additionalText)
        {
            return string.Format(branch.Format, additionalText);
        }
    }
}