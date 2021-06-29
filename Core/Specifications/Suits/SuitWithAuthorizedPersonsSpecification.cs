using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications.Suits
{
    public class SuitWithAuthorizedPersonsSpecification : BaseSpecification<Suit>
    {
        public SuitWithAuthorizedPersonsSpecification(SuitSpecificationParams suitParams) : base()
        {
            AddInclude(s => s.AuthorizedPerson);

            ApplyPaging(suitParams.PageSize * (suitParams.PageIndex - 1), suitParams.PageSize);

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