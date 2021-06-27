using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications.Suits
{
    public class SuitWithAuthorizedPerson : BaseSpecification<Suit>
    {
        public SuitWithAuthorizedPerson() : base()
        {
            AddInclude(s => s.AuthorizedPerson);
        }

        public SuitWithAuthorizedPerson(int id) : base(x => x.Id == id)
        {
            AddInclude(s => s.AuthorizedPerson);
        }
    }
}