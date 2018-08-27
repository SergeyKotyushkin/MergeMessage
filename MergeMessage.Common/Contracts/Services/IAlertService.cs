using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Contracts.Services
{
    public interface IAlertService
    {
        void Alert(IAlertEntity alertEntity);
    }
}