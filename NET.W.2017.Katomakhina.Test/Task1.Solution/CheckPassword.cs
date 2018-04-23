using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class CheckPassword : IVerifyPassword
    {
        public bool VerifyPassword(string password)
        {
            bool flag = false;

            if (password == null)
            {
                return flag;
                throw new ArgumentException($"{nameof(password)} is null arg");
            }                

            if (password == string.Empty)
            {
                return flag;
                throw new ArgumentException($"{nameof(password)} is empty ");                
            }            

            if (password.Length <= 7)
            {
                return flag;
                throw new ArgumentOutOfRangeException($"{nameof(password)} length too short ");
            }

            if (password.Length >= 15)
            {
                return flag;
                throw new ArgumentOutOfRangeException($"{nameof(password)} length too long ");
            }

            if (!password.Any(char.IsLetter))
            {
                return flag;
                throw new ArgumentException($"{nameof(password)} hasn't alphanumerical chars ");
            }

            if (!password.Any(char.IsNumber))
            {
                return flag;
                throw new ArgumentException($"{nameof(password)} hasn't digits ");
            }

            return flag = true;
        }
    }
}
