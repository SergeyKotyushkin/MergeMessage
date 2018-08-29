using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Enums;

namespace MergeMessage.Common.Models
{
    public class AlertEntity : IAlertEntity
    {
        public AlertEntity(string header, string text, AlertType alertType)
            : this(alertType)
        {
            Header = header;
            Text = text;
        }

        public AlertEntity(AlertType alertType)
        {
            SetAlertType(alertType);
        }

        public string Header { get; set; }

        public string Text { get; set; }

        public bool IsSuccess { get; set; }

        public bool IsError { get; set; }

        public bool IsWarn { get; set; }

        private void SetAlertType(AlertType alertType)
        {
            switch (alertType)
            {
                case AlertType.Success:
                    IsSuccess = true;
                    break;
                case AlertType.Warn:
                    IsWarn = true;
                    break;
                case AlertType.Error:
                    IsError = true;
                    break;
                default: break;
            }
        }
    }
}