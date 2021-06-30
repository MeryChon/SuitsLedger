using Core.Specifications.Base;
using Core.Utils;

namespace Core.Specifications.AuthorizedPerson
{
    public class AuthorizedPersonWithFiltersForCount : BaseSpecification<Core.Entities.AuthorizedPerson>
    {
        public AuthorizedPersonWithFiltersForCount(AuthorizedPersonSpecificationParams authorizedPersonParams)
        : base(x =>
            (string.IsNullOrEmpty(authorizedPersonParams.Search) || AuthorizedPersonUtils.AuthorizedPersonNameContains(x, authorizedPersonParams.Search))
            && (string.IsNullOrEmpty(authorizedPersonParams.IdentificationNumber) || x.IdentificationNumber.ToLower().Contains(authorizedPersonParams.IdentificationNumber))
            && (!authorizedPersonParams.Type.HasValue || x.Type == authorizedPersonParams.Type))
        {

        }
    }
}