using Core.Entities;

namespace Core.Utils
{
    public class AuthorizedPersonUtils
    {
        public static bool AuthorizedPersonNameContains(Core.Entities.AuthorizedPerson person, string part)
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