using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications.Suits
{
    public class SuitWithFiltersForCount : BaseSpecification<Suit>
    {

        public SuitWithFiltersForCount(SuitSpecificationParams suitParams) :
        base(x =>
        (string.IsNullOrEmpty(suitParams.Search) || x.Description.ToLower().Contains(suitParams.Search.ToLower()))
        && (string.IsNullOrEmpty(suitParams.AuthorizedPersonName) || AuthorizedPersonNameContains(x.AuthorizedPerson, suitParams.AuthorizedPersonName))
        && (!suitParams.AuthorizedPersonId.HasValue || x.AuthorizedPersonId == suitParams.AuthorizedPersonId)
        && (!suitParams.Status.HasValue) || x.Status == suitParams.Status)
        {

        }

        private static bool AuthorizedPersonNameContains(AuthorizedPerson person, string part)
        {
            if (part == null || part == "")
            {
                return true;
            }

            string fullName = person.Type == PersonType.PHYSICAL ? person.FirstName + " " + person.LastName : person.Name;
            return fullName.ToLower().Contains(part.ToLower());
        }

    }
}