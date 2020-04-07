namespace Problem8CollectionHierarchy.Model
{
    using Problem8CollectionHierarchy.Contracts;
    using System.Collections.Generic;

    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }

        public IReadOnlyList<string> Collection { get => this.collection.AsReadOnly(); }

        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            int index = this.collection.Count - 1;

            var item = this.collection[index];

            this.collection.RemoveAt(index);

            return item;
        }
    }
}