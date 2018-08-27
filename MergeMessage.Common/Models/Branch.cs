using MergeMessage.Common.Contracts.Models;

namespace MergeMessage.Common.Models
{
    public class Branch : IBranch
    {
        public Branch(string name, string format, string additionalLabel = null)
        {
            Name = name;
            Format = format;
            AdditionalLabel = additionalLabel;
        }

        public string Name { get; }

        public string Format { get; }

        public string AdditionalLabel { get; }

        public bool IsAdditionalNeeded => !string.IsNullOrEmpty(AdditionalLabel);

        public override bool Equals(object obj)
        {
            var branch = obj as Branch;
            return branch != null && Name == branch.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}