namespace Jimmys20.BlazorComponents
{
    public class DropEventArgs<T>
    {
        /// <summary>
        /// Gets the dropped item.
        /// </summary>
        public T Item { get; }

        /// <summary>
        /// Gets the index where the item was dropped.
        /// </summary>
        public int Index { get; }

        public DropEventArgs(T item, int index)
        {
            Item = item;
            Index = index;
        }
    }
}
