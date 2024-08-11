public interface IPoolable
{
    public void CreatePool();
    public void HideItem<T>(T item);
    public void HideAllItems();
}
