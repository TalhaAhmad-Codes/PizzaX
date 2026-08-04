namespace PizzaX.Common.DTOs
{
    public sealed class PagedResultDto<T> where T : class
    {
        public List<T> Items { get; init; }
        public int TotalCount { get; init; }
    }
}
