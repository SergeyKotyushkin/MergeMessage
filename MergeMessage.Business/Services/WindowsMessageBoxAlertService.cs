using System.Windows.Forms;
using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Contracts.Services;

namespace MergeMessage.Business.Services
{
    public class WindowsMessageBoxAlertService : IAlertService
    {
        public void Alert(IAlertEntity alertEntity)
        {
            var icon = ResolveIcon(alertEntity);
            MessageBox.Show(alertEntity.Text, alertEntity.Header, MessageBoxButtons.OK, icon);
        }

        private static MessageBoxIcon ResolveIcon(IAlertEntity alertEntity)
        {
            if (alertEntity.IsError)
            {
                return MessageBoxIcon.Error;
            }

            if (alertEntity.IsWarn)
            {
                return MessageBoxIcon.Warning;
            }

            return MessageBoxIcon.None;
        }
    }
}