using System;
using EncapsulamentoEPropriedade.ExtratoContas.ContasBancarias;
using EncapsulamentoEPropriedade.ExtratoContas;
using ConsoleMenuLibrary;

namespace EncapsulamentoEPropriedade
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var saldoCCAnterior = 3000;
            var extratoCC = new ExtratoBancario<ExtratoContaCorrente>("1", DateTime.Now.Date, saldoCCAnterior);

            var saldoRendaFixaAnterior = 5000;
            var extratoRendaFixa = new ExtratoBancario<ExtratoRendaFixa>("2", DateTime.Now.Date, saldoRendaFixaAnterior);

            var saldoPoupancaAnterior = 2000;
            var extratoPoupanca = new ExtratoBancario<ExtratoContaPoupanca>("3", DateTime.Now.Date, saldoPoupancaAnterior);

            var opcoesConta = new string[] { "Conta Corrente", "Renda Fixa", "Conta Poupança" };
            var opcoesOperacao = new string[] { "Depósito", "Saque", "Saldo" };

            do
            {
                var menuConta = new ConsoleMenu(opcoesConta);
                var contaSelecionadaIndex = menuConta.ShowMenu();

                var menuOperacao = new ConsoleMenu(opcoesOperacao);
                var operacaoSelecionadaIndex = menuOperacao.ShowMenu();

                switch (contaSelecionadaIndex)
                {
                    case 0: // Conta Corrente
                        if (operacaoSelecionadaIndex == 0) // Depósito
                        {
                            Console.Write("Digite o valor do depósito: ");
                            decimal valorDepositoCC = Convert.ToDecimal(Console.ReadLine());
                            extratoCC.Deposito(valorDepositoCC);
                            Console.WriteLine($"Saldo Conta Corrente: {extratoCC.Saldo}");
                        }
                        else if (operacaoSelecionadaIndex == 1) // Saque
                        {
                            Console.Write("Digite o valor do saque: ");
                            decimal valorSaqueCC = Convert.ToDecimal(Console.ReadLine());
                            extratoCC.Saque(valorSaqueCC);
                            Console.WriteLine($"Saldo Conta Corrente após saque: {extratoCC.Saldo}");
                        }
                        else // Saldo
                        {
                            Console.WriteLine($"Saldo Conta Corrente: {extratoCC.Saldo}");
                        }
                        break;

                    case 1: // Renda Fixa
                        if (operacaoSelecionadaIndex == 0) // Depósito
                        {
                            Console.Write("Digite o valor do depósito: ");
                            decimal valorDepositoRendaFixa = Convert.ToDecimal(Console.ReadLine());
                            extratoRendaFixa.Deposito(valorDepositoRendaFixa);
                            Console.WriteLine($"Saldo Renda Fixa: {extratoRendaFixa.Saldo}");
                        }
                        else if (operacaoSelecionadaIndex == 1) // Saque
                        {
                            Console.Write("Digite o valor do saque: ");
                            decimal valorSaqueRendaFixa = Convert.ToDecimal(Console.ReadLine());
                            extratoRendaFixa.Saque(valorSaqueRendaFixa);
                            Console.WriteLine($"Saldo Renda Fixa após saque: {extratoRendaFixa.Saldo}");
                        }
                        else // Saldo
                        {
                            Console.WriteLine($"Saldo Renda Fixa: {extratoRendaFixa.Saldo}");
                        }
                        break;

                    case 2: // Conta Poupança
                        if (operacaoSelecionadaIndex == 0) // Depósito
                        {
                            Console.Write("Digite o valor do depósito: ");
                            decimal valorDepositoPoupanca = Convert.ToDecimal(Console.ReadLine());
                            extratoPoupanca.Deposito(valorDepositoPoupanca);
                            Console.WriteLine($"Saldo Conta Poupança: {extratoPoupanca.Saldo}");
                        }
                        else if (operacaoSelecionadaIndex == 1) // Saque
                        {
                            Console.Write("Digite o valor do saque: ");
                            decimal valorSaquePoupanca = Convert.ToDecimal(Console.ReadLine());
                            extratoPoupanca.Saque(valorSaquePoupanca);
                            Console.WriteLine($"Saldo Conta Poupança após saque: {extratoPoupanca.Saldo}");
                        }
                        else // Saldo
                        {
                            Console.WriteLine($"Saldo Conta Poupança: {extratoPoupanca.Saldo}");
                        }
                        break;
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();
                Console.Clear();

            } while (true);
        }
    }
}
