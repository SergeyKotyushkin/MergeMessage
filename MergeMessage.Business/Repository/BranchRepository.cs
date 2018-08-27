using System.Collections.Generic;
using System.Linq;

using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Contracts.Repository;

namespace MergeMessage.Business.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly HashSet<IBranch> _mBranches;

        public BranchRepository()
        {
            _mBranches = new HashSet<IBranch>();
        }

        public void Save(IBranch branch)
        {
            _mBranches.Remove(branch);
            _mBranches.Add(branch);
        }

        public IBranch[] GetAll()
        {
            return _mBranches.ToArray();
        }

        public IBranch GetByName(string name)
        {
            return _mBranches.FirstOrDefault(branch => branch.Name.Equals(name));
        }
    }
}