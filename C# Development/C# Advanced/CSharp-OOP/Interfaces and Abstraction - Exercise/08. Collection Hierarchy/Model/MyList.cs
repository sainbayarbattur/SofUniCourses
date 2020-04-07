namespace Problem8CollectionHierarchy.Model
{
    using Problem8CollectionHierarchy.Contracts;
    using System.Collections.Generic;

    public class MyList : IMyList
    {
        private List<string> collection;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public IReadOnlyList<string> Collection { get => this.collection.AsReadOnly(); }

        public int Used => throw new System.NotImplementedException();

        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            var item = this.collection[0];

            this.collection.RemoveAt(0);

            return item;
        }
    }
}