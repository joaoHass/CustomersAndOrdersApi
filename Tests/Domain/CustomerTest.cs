using Domain.Customers;

namespace Tests.Domain
{
    public class CustomerTest
    {
        [Fact]
        private void should_only_accept_cpf_with_11_digits()
        {
            Customer sut = new();
            string newCpf = "12345678901234";

            void setCpf() => sut.CPF = newCpf;

            Assert.True(newCpf.Length != 11);
            Assert.Throws<ArgumentException>(setCpf);
        }

        [Fact]
        private void should_only_accept_cpf_with_only_digits()
        {
            Customer sut = new();
            string newCpf = "123A3^|C!@_~ '";

            void setCpf() => sut.CPF = newCpf;

            Assert.False(newCpf.All(char.IsDigit));
            Assert.Throws<ArgumentException>(setCpf);
        }
    }
}