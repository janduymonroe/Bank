
using System;
using System.Collections.Generic;

namespace Bank

{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario != "X")
           {
               switch(opcaoUsuario)
               {
                   case "1":
                        ListarContas();
                        break;
                   case "2":
                        InserirConta();
                        break;
                   case "3":
                        Transferir();
                        break;
                   case "4":
                        Sacar();
                        break;
                   case "5":
                        Depositar();
                        break;
                   case "C":
                        System.Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

               }

               opcaoUsuario = ObterOpcaoUsuario();
           }

           System.Console.WriteLine("Obrigado por utilizar nossos serviços.");
           System.Console.ReadLine();
        }

        private static void Transferir()
        {
            System.Console.Write("Informe o número da conta de origem: ");
            int indiceContaOrigem = Convert.ToInt32(Console.ReadLine())-1;
            System.Console.Write("Informe o número da conta de destino: ");
            int indiceContaDestino = Convert.ToInt32(Console.ReadLine())-1;
            System.Console.Write("Informe o valor a ser transferido: ");
            double valorTransferencia = Convert.ToDouble(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            System.Console.Write("Digite o número da conta: ");
            int indiceConta = Convert.ToInt32(Console.ReadLine());

            System.Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = Convert.ToDouble(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            System.Console.Write("Digite o número da conta que deseja sacar: ");
            int numeroConta = Convert.ToInt32(Console.ReadLine())-1;

            System.Console.Write("Digite o valor a ser sacado: ");
            double valorDeposito = Convert.ToDouble(Console.ReadLine());

            listContas[numeroConta].Sacar(valorDeposito);
        }

        private static void ListarContas()
        {
            System.Console.WriteLine("Listar Contas");
            if (listContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 1; i <= listContas.Count; i++)
            {
                Conta conta = listContas[i-1];
                System.Console.Write("#{0} - ", i);
                System.Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            System.Console.WriteLine("Inserir nova conta");

            System.Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = Convert.ToInt32(Console.ReadLine());

            System.Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            System.Console.Write("Digite o valor do saldo inicial: ");
            double saldoInicial = Convert.ToDouble(Console.ReadLine());

            System.Console.Write("Digite o valor do crédito: ");
            double valorCredito = Convert.ToDouble(Console.ReadLine());

            Conta novaConta = new Conta ((TipoConta)entradaTipoConta, 
                                            saldoInicial, 
                                            valorCredito, 
                                            entradaNome);

            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Banco Grana ao seu dispor!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1- Listar Contas");
            System.Console.WriteLine("2- Inserir Nova Conta");
            System.Console.WriteLine("3- Transferir");
            System.Console.WriteLine("4- Sacar");
            System.Console.WriteLine("5- Depositar");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();

            return opcaoUsuario;

        }


    }
}
