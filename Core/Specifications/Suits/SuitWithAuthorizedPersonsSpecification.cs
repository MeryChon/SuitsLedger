using Core.Entities;
using Core.Utils;
using Core.Specifications.Base;

namespace Core.Specifications.Suits
{
    public class SuitWithAuthorizedPersonsSpecification : BaseSpecification<Suit>
    {
        public SuitWithAuthorizedPersonsSpecification(SuitSpecificationParams suitParams)
         : base(x =>
        (string.IsNullOrEmpty(suitParams.Search) || x.Description.ToLower().Contains(suitParams.Search.ToLower()))
        && (string.IsNullOrEmpty(suitParams.AuthorizedPersonName) || AuthorizedPersonUtils.AuthorizedPersonNameContains(x.AuthorizedPerson, suitParams.AuthorizedPersonName))
        && (!suitParams.AuthorizedPersonId.HasValue || x.AuthorizedPersonId == suitParams.AuthorizedPersonId)
        && (!suitParams.Status.HasValue) || x.Status == suitParams.Status)
        {
            AddInclude(s => s.AuthorizedPerson);

            ApplyPaging(suitParams.PageSize * suitParams.PageIndex, suitParams.PageSize);

            if (!string.IsNullOrEmpty(suitParams.Sort))
            {
                switch (suitParams.Sort)
                {
                    case "RegistrationDateAsc":
                        AddOrderBy(s => s.RegistrationDate);
                        break;
                    case "DescriptionAsc":
                        AddOrderBy(s => s.Description);
                        break;
                    case "DescriptionDesc":
                        AddOrderByDesc(s => s.Description);
                        break;
                    case "LimitationPeriodAsc":
                        AddOrderBy(s => s.LimitationPeriod);
                        break;
                    case "LimitationPeriodDesc":
                        AddOrderByDesc(s => s.LimitationPeriod);
                        break;
                    case "RegistrationDateDesc":
                    default:
                        AddOrderByDesc(s => s.RegistrationDate);
                        break;
                }

            }
        }

        public SuitWithAuthorizedPersonsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(s => s.AuthorizedPerson);
        }
    }
}