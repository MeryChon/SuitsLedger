using Core.Specifications.Base;
using Core.Utils;

namespace Core.Specifications.AuthorizedPerson
{
    public class AuthorizedPersonWithSuitsSpecification : BaseSpecification<Core.Entities.AuthorizedPerson>
    {
        public AuthorizedPersonWithSuitsSpecification(AuthorizedPersonSpecificationParams authorizedPersonParams)
        : base(x =>
            (string.IsNullOrEmpty(authorizedPersonParams.Search) || AuthorizedPersonUtils.AuthorizedPersonNameContains(x, authorizedPersonParams.Search))
            && (string.IsNullOrEmpty(authorizedPersonParams.IdentificationNumber) || x.IdentificationNumber.ToLower().Contains(authorizedPersonParams.IdentificationNumber))
            && (!authorizedPersonParams.Type.HasValue || x.Type == authorizedPersonParams.Type))
        {
            // AddInclude(ap => ap.Suits); TODO

            ApplyPaging(authorizedPersonParams.PageSize * authorizedPersonParams.PageIndex, authorizedPersonParams.PageSize);

            if (!string.IsNullOrEmpty(authorizedPersonParams.Sort))
            {
                switch (authorizedPersonParams.Sort)
                {
                    case "FirstNameAsc":
                        AddOrderBy(ap => ap.FirstName);
                        break;
                    case "FirstNameDesc":
                        AddOrderByDesc(ap => ap.FirstName);
                        break;
                    case "NameAsc":
                        AddOrderBy(ap => ap.Name);
                        break;
                    case "NameDesc":
                        AddOrderByDesc(ap => ap.Name);
                        break;
                    case "LastNameDesc":
                        AddOrderByDesc(ap => ap.LastName);
                        break;
                    case "LastNameAsc":
                    default:
                        AddOrderBy(ap => ap.LastName);
                        break;
                }
            }
        }


        public AuthorizedPersonWithSuitsSpecification(int id) : base(x => x.Id == id)
        {
            // AddInclude(ap => ap.Suits); TODO
        }
    }
}