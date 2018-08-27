namespace MergeMessage.Common.Contracts.Models
{
    public interface IAlertEntity
    {
        string Header { get; set; }

        string Text { get; set; }

        bool IsSuccess { get; }

        bool IsError { get; }

        bool IsWarn { get; }
    }
}