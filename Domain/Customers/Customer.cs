using System.ComponentModel.DataAnnotations.Schema;
using Domain.Orders;

namespace Domain.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Even though CPF is a number, we would have to consider everytime
        // if the length is 14 (because of the loss of leading zeros) or add
        // a paddingLeft everytime. So, I'll be going with the string route
        private string _cpf;

        /// <summary>
        /// Set Customer's CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <exception cref="ArgumentException">The informed CPF number has length different than 14, which is invalid</exception>
        /// <exception cref="ArgumentException">The CPF can only contain numbers</exception>
        public string CPF
        {
            get => _cpf;
            set
            {
                if (value.Length != 11)
                    throw new ArgumentException("The informed CPF number has length different than 14, which is invalid");

                if (!value.All(char.IsDigit))
                    throw new ArgumentException("The CPF can only contain numbers");

                // I won't be checking if the CPF is valid or not, for simplicity.
                _cpf = value;
            }
        }

        public string? Adress { get; set; }
        public int? PhoneNumber { get; set; } // I won't be adding verification to phone number to keep things simple.
        public DateTime? BirthDate { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

        private ICollection<string> ValidateCPF(string cpf, bool throwException = true)
        {
            ICollection<string> errors = new List<string>();

            if (cpf.Length != 11)
               errors.Add("The informed CPF number has length different than 14, which is invalid");

            if (!cpf.All(char.IsDigit))
                errors.Add("The CPF can only contain numbers");

            if (errors.Count > 0 && throwException)
                throw new ArgumentException(string.Join(Environment.NewLine, errors));

            return errors;
        }
    }
}
