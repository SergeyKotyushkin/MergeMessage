using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Contracts.Services
{
    public interface IBranchRepository
    {
        void Save(IBranch branch);

        IBranch[] GetAll();

        IBranch GetByName(string name);
    }
}