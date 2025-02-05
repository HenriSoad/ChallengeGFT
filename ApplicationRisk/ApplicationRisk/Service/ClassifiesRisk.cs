using ApplicationRisk.Enuns;
using ApplicationRisk.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRisk.Service
{
    public class ClassifiesRisk
    {
        public void ClassifiesRiskTrade(List<Trade> trades)
        {
            foreach (var trade in trades)
            {
                if (DaysBetweenNow(trade.NextPaymentDate) > (int)ERisks.EXPIRED)
                {
                    Console.WriteLine("Sua operação do dia {0} foi definida com o status de {1}, portanto esta em ATRASO!!", trade.NextPaymentDate, ERisks.EXPIRED.ToString());
                }
                else if (Convert.ToInt32(trade.Value) > (int)ERisks.HIGHRISK && trade.ClientSector.ToLower().Equals("privado"))
                {
                    Console.WriteLine("Sua operação do dia {0} foi definida com o status de {1}", trade.NextPaymentDate, ERisks.HIGHRISK.ToString());
                }
                else if (Convert.ToInt32(trade.Value) > (int)ERisks.HIGHRISK && trade.ClientSector.ToLower().Equals("publico"))
                {
                    Console.WriteLine("Sua operação do dia {0} foi definida com o status de {1}", trade.NextPaymentDate, ERisks.MEDIUMRISK.ToString());
                }
                else
                {
                    Console.WriteLine("Sua operação do dia {0} foi definida com o status de {1}", trade.NextPaymentDate, ERisks.LOWRISK.ToString());
                }
            }
        }

        public static int DaysBetweenNow(DateTime data)
        {
            return (DateTime.Today - data).Days;
        }
    }
}
