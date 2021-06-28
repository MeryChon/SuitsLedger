namespace Core.Specifications.Suits
{
    public class SuitSpecificationParams
    {
        private const int MAX_PAGE_SIZE = 50;

        private int _pageSize = 5;

        public int PageIndex { get; set; }

        public int PageSize { get => _pageSize; set => _pageSize = (value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value); }

        public int? AuthorizedPersonId { get; set; }

        public string AuthorizedPersonName { get; set; }

        public SuitStatus? Status { get; set; }

        public string Sort { get; set; }

        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }

    }
}