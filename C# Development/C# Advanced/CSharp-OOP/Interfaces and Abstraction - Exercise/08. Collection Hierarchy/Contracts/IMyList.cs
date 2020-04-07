namespace Problem8CollectionHierarchy.Contracts
{
    public interface IMyList : IAddRemoveCollection
    {
        int Used { get; }
    }
}