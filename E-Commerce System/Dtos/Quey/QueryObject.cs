namespace E_Commerce_System.Dtos.Quey
{
    public class QueryObject
    {
        public string? Name { get; set; } = null;
        public int? CategoryId { get; set; } = null;
        public int PageSize { get; set; } = 20;
        public int PageCount { get; set; } = 1;
    }
}
