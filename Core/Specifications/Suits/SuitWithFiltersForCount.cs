using Core.Entities;
using Core.Utils;
using Core.Specifications.Base;

namespace Core.Specifications.Suits
{
    public class SuitWithFiltersForCount : BaseSpecification<Suit>
    {

        public SuitWithFiltersForCount(SuitSpecificationParams suitParams) :
        base(x =>
        (string.IsNullOrEmpty(suitParams.Search) || x.Description.ToLower().Contains(suitParams.Search.ToLower()))
        && (string.IsNullOrEmpty(suitParams.AuthorizedPersonName) || x.AuthorizedPerson.FirstName.ToLower().Contains(suitParams.AuthorizedPersonName.ToLower()))
        && (!suitParams.AuthorizedPersonId.HasValue || x.AuthorizedPersonId == suitParams.AuthorizedPersonId)
        && (!suitParams.Status.HasValue) || x.Status == suitParams.Status)
        {

        }
    }
}