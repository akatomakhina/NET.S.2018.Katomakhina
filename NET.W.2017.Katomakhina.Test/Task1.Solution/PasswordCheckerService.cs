using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class PasswordCheckerService
    {
        private SqlRepository repository = new SqlRepository();

        IEnumerable<IVerifyPasswordTwo> verifiables;

        public Tuple<bool, string> VerifyPassword(string password)
        {
            
            foreach (var verifiable in verifiables)
            {
                var temp = verifiable.VerifyPassword(password);
                if (temp.Item1)
                {
                    return Tuple.Create(false, temp.Item2);
                }
            }

            repository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
