using DIO.Bank.Domain.Entities;
using DIO.Bank.Domain.Enums;
using System;
using System.Collections.Generic;

namespace DIO.Bank.AppConsole
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        public static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        Console.WriteLine();
                        PressioneParaContinuar();
                        break;
                        

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
		
		private static void ListarContas()
		{
            Console.Clear();
			Console.WriteLine("-Listar Contas-");
            Console.WriteLine();

			if(listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
                PressioneParaContinuar();
				return;
			}
			
			for(int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("{0} - ",i);
				Console.WriteLine(conta);
			}

            PressioneParaContinuar();
        }
		
		private static void InserirConta()
		{
            Console.Clear();
			Console.WriteLine("-Inserir Nova Conta-");
            Console.WriteLine();

			Console.Write("Digite 1 para Conta Física ou 2 para Juridica: ");
			int entradaTipoConta =  int.Parse(Console.ReadLine());
			
			Console.Write("Digite o Nome do Cliente: ");
			string entradaNome = Console.ReadLine();
			
			Console.Write("Digite o saldo inicial: ");
			double entradaSaldo =  double.Parse(Console.ReadLine());
			
			Console.Write("Digite o crédito: ");
			double entradaCredito =  double.Parse(Console.ReadLine());
			
			Conta novaConta =  new Conta(tipoConta: (TipoConta)entradaTipoConta,
										 saldo: entradaSaldo,
										 credito: entradaCredito,
										 nome: entradaNome);
			listContas.Add(novaConta);

            PressioneParaContinuar();
        }
		
		private static void Transferir() 
		{
            Console.Clear();
            Console.WriteLine("-Transferir-");
            Console.WriteLine();

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                PressioneParaContinuar();
                return;
            }

            Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());
			
			Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());
			
			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = int.Parse(Console.ReadLine());
			
			listContas[indiceContaOrigem].Transferir(valorTransferencia,listContas[indiceContaDestino]);
            PressioneParaContinuar();
        }
		
		private static void Sacar()
		{
            Console.Clear();
            Console.WriteLine("-Sacar-");
            Console.WriteLine();

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                PressioneParaContinuar();
                return;
            }

            Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());
			
			Console.Write("Digite o valor  a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());
			
			listContas[indiceConta].Sacar(valorSaque);

            PressioneParaContinuar();
        }
		
		private static void Depositar()
		{
            Console.Clear();
            Console.WriteLine("-Despositar-");
            Console.WriteLine();

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                PressioneParaContinuar();
                return;
            }

            Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());
			
			Console.Write("Digite o valor  a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());
			
			listContas[indiceConta].Depositar(valorDeposito);

            PressioneParaContinuar();
        }
		
        
        private static string ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("DIO Bank App!!!");
            Console.WriteLine();
            Console.WriteLine("-Lista de Opções-");
            Console.WriteLine();
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            Console.Write("Informe a opção desejada: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void PressioneParaContinuar()
        {
            Console.WriteLine();
            Console.Write("<pressione qualquer tecla para continuar>");
            Console.ReadKey(false);
        }

    }
}
