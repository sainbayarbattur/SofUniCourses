namespace Problem8CollectionHierarchy.Model
{
    using Problem8CollectionHierarchy.Contracts;
    using System.Collections.Generic;

    public class AddCollection : IAddCollection
    {
        List<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public IReadOnlyList<string> Collection { get => this.collection.AsReadOnly(); }

        public int Add(string item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
        }
    }
}
