using ApplicationRisk.Models;
using ApplicationRisk.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationRisk
{
    public class Program
    {
        public static void Main(string[] args)
        {

            DateTime now = DateTime.Now;

            List<Trade> tradeList = new List<Trade>();
            ClassifiesRisk ClassifiesRiskService = new ClassifiesRisk();


            Console.WriteLine("Olá, voce esta prestes a categorizar a sua operação\n" +
                              "siga as intruções para obter um resultado preciso");

            Console.WriteLine("Iniciando....");

            Console.WriteLine("Data Hoje");
            Console.WriteLine(now);

            Console.WriteLine("Digite a quantidade de operações");
            int quantidadeOperacoes = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < quantidadeOperacoes; i++)
            {
                Trade trade = new Trade();

                Console.WriteLine("Digite o valor negociado da operação {0}",i);
                trade.Value = double.Parse(Console.ReadLine());

                Console.WriteLine("Digite o setor do cliente");
                trade.ClientSector = Console.ReadLine();

                Console.WriteLine("Digite a data do proximo pagamento previsto");
                trade.NextPaymentDate = Convert.ToDateTime(Console.ReadLine());

                tradeList.Add(trade);
            }
            if (tradeList.Any())
            {
                ClassifiesRiskService.ClassifiesRiskTrade(tradeList);
            }
            else
            {
                Console.WriteLine("Lista de não contem operações");
            }

            Console.ReadKey();
        }
    }
}
