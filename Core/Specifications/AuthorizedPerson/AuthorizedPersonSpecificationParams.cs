using Core.Entities;

namespace Core.Specifications.AuthorizedPerson
{
    public class AuthorizedPersonSpecificationParams
    {
        private const int MAX_PAGE_SIZE = 50;

        private int _pageSize = 5;

        public int PageIndex { get; set; }

        public int PageSize { get => _pageSize; set => _pageSize = (value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value); }

        public string IdentificationNumber { get; set; }

        public PersonType? Type { get; set; }

        public string Sort { get; set; }

        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }


    }
}