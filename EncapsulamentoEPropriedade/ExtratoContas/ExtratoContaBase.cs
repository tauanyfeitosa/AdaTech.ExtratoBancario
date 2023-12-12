
namespace EncapsulamentoEPropriedade.ExtratoContas
{
    using OperacoesContasBancarias;
    internal abstract class ExtratoContaBase
    {
        protected decimal _saldoAnterior;
        protected List<OperacoesContas> Operacoes;

        protected ExtratoContaBase(decimal saldoAnterior)
        {
            Operacoes = new List<OperacoesContas>();
            SaldoAnterior = saldoAnterior;
        }

        protected decimal SaldoAnterior
        {
            get
            {
                return _saldoAnterior;
            }

            private set
            {
                if (value < 0) throw new ArgumentException("Valor inválido");
                _saldoAnterior = value;
            }
        }

        public decimal Total
        {
            get
            {
                return SaldoAnterior + CalcularOperacoesHoje();
            }
        }

        public decimal TotalComLambda
        {
            get => CalcularOperacoesHoje();
        }

        private decimal CalcularOperacoesHoje()
        {
            decimal saldo = 0;

            foreach (var operacao in Operacoes)
            {
                if (operacao.Tipo == TipoOperacoesConta.Entrada)
                {
                    saldo = saldo + operacao.Valor;
                    continue;
                }

                else if (operacao.Tipo == TipoOperacoesConta.Saida)
                {
                    saldo = saldo - operacao.Valor;
                    continue;
                }

                throw new ArgumentException("Operação Inválida");
            }

            return saldo;
        }

        public void Saque(decimal valor)
        {
            if (valor > Total)
            {
                throw new ArgumentException("Total em C/C insuficiente");
            }

            Operacoes.Add(new OperacoesContas { Tipo = TipoOperacoesConta.Saida, Valor = valor });
        }

        public void Deposito(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("Depósito inválido");
            }

            Operacoes.Add(new OperacoesContas { Tipo = TipoOperacoesConta.Entrada, Valor = valor });
        }
    }
}
