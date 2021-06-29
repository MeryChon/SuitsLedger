namespace API.Helper
{
    public class Pagination
    {
        public Pagination(int pageIndex, int pageSize, int count)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;

        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }


    }
}