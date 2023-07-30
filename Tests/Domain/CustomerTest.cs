using Domain.Customers;

namespace Tests.Domain
{
    public class CustomerTest
    {
        [Fact]
        private void cpf_should_only_have_11_digits()
        {
            Customer sut = new();
            string newCpf = "12345678901234";

            void setCpf() => sut.CPF = newCpf;

            Assert.True(newCpf.Length != 11);
            Assert.Throws<ArgumentException>(setCpf);
        }

        [Fact]
        private void cpf_should_only_accept_digits()
        {
            Customer sut = new();
            string newCpf = "123A3^|C!@_~ '";

            void setCpf() => sut.CPF = newCpf;

            Assert.False(newCpf.All(char.IsDigit));
            Assert.Throws<ArgumentException>(setCpf);
        }
    }
}