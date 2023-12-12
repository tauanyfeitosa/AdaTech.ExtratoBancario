using EncapsulamentoEPropriedade.ExtratoContas;
using EncapsulamentoEPropriedade.ExtratoContas.ContasBancarias;

namespace EncapsulamentoEPropriedade
{
    internal class ExtratoBancario<T> where T : ExtratoContaBase
    {
        private string _numeroConta;

        public string NumeroConta
        {
            get { return _numeroConta; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Valor inválido");

                _numeroConta = "00000" + value;
            }
        }

        public readonly DateTime Data;

        public T ExtratoConta { get; }

        public ExtratoBancario(string numeroConta, DateTime data, decimal saldoAnterior)
        {
            NumeroConta = numeroConta;
            Data = data;
            ExtratoConta = (T)Activator.CreateInstance(typeof(T), saldoAnterior);
        }

        public void Deposito(decimal valor)
        {
            ExtratoConta.Deposito(valor);
        }
        public void Saque(decimal valor)
        {
            try
            {
                ExtratoConta.Saque(valor);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao realizar saque: {ex.Message}");
            }
        }

        public decimal Saldo
        {
            get { return ExtratoConta.Total; }
        }
    }
}
