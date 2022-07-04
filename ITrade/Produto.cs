using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; } // indica o valor da transação em dólares
        public string ClientSector { get; set; } // indica o setor do cliente que pode ser "Público" ou "Privado"
        public DateTime NextPaymentDate { get;  set; } // indica quando é esperado o próximo pagamento do cliente ao banco

    }

}
