using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trade;



namespace Trade
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cria uma lista para guardar as categorias
            var categorias = new List<Categoria>();

            //Insere as categorias na Lista
            categorias.Insert(0, new Categoria() { CategoriaId = 1, Nome = "EXPIRADO", NextPaymentDate = DateTime.Now });
            categorias.Insert(1, new Categoria() { CategoriaId = 2, Nome = "ALTO RISCO", Valor = 1000000, ClientSector = "Privado", NextPaymentDate = DateTime.Now });
            categorias.Insert(2, new Categoria() { CategoriaId = 3, Nome = "RISCO MÉDIO", Valor = 1000000, ClientSector = "Publico", NextPaymentDate = DateTime.Now });

            DateTime ?dtReferencia = null;
            int numTrades = 0;
            double valorNegociacao = 0;
            string setorCliente = "";
            DateTime ?dtProximoPgto = null;


            //Data de Referência
            Console.Write("Entre com a Data de Referência no formato dd/mm/yyyy: ");
            dtReferencia = DateTime.Parse(Console.ReadLine());

            //DateTime ?cleanNum1 = null;
            while (dtReferencia == null)
            {
                Console.Write("Não é uma data válida. Por favor entre com uma data válida: ");
                dtReferencia = DateTime.Parse(Console.ReadLine());
            }


            //Números de trades
            Console.Write("Entre com o Número de Trades: ");
            numTrades = int.Parse(Console.ReadLine());

            int cleanNum2 = 0;
            while (numTrades == cleanNum2)
            {
                Console.Write("Não é um número válido. Por favor entre com um númrto válido: ");
                numTrades = int.Parse(Console.ReadLine());
            }

            int numTradesDigitados = 0;

            while (numTradesDigitados < numTrades)
            {
                //Valor da negociação/trade
                Console.Write("Entre com o Valor da Negociação no formato 000000: ");
                valorNegociacao = double.Parse(Console.ReadLine());

                while (Convert.ToString(valorNegociacao).Length < 7)
                {
                    Console.Write("Não é um valor válido. Por favor entre com um valor válido: ");
                    valorNegociacao = double.Parse(Console.ReadLine());
                }


                //Setor do Cliente
                Console.Write("Entre com o o Setor do Cliente (Digite Publico ou Privado): ");
                setorCliente = Console.ReadLine();
                
                while (setorCliente == null)
                {
                    Console.Write("Não é um setor válido. Por favor entre com um setor válido: ");
                    setorCliente = Console.ReadLine();
                }


                //Data do próximo pagamento pendente
                Console.Write("Entre com a Data do próximo pagamento pendente no formato dd/mm/yyyy: ");
                dtProximoPgto = DateTime.Parse(Console.ReadLine());

                while (dtProximoPgto == null)
                {
                    Console.Write("Não é uma data válida. Por favor entre com um uma data válida: ");
                    dtProximoPgto = DateTime.Parse(Console.ReadLine());
                }

                //Atualiza o campo "NextPaymentDate" da lista para a data que o usuário digitou
                categorias[0].NextPaymentDate = (DateTime)dtProximoPgto;
                categorias[1].NextPaymentDate = (DateTime)dtProximoPgto;
                categorias[2].NextPaymentDate = (DateTime)dtProximoPgto;

                numTradesDigitados = numTradesDigitados + 1;

                //Calcula a diferença de dias
                TimeSpan date = Convert.ToDateTime(dtReferencia) - Convert.ToDateTime(categorias[0].NextPaymentDate);
                int totalDias = date.Days;
                //Lógica
                if (dtReferencia > categorias[0].NextPaymentDate && totalDias > 30)
                {
                        //pula linha
                        Console.WriteLine("\r\n");
                        Console.WriteLine(categorias[0].Nome);    
                }
                else if (valorNegociacao > categorias[1].Valor && setorCliente == "Privado") //&& dtReferencia > categorias[1].NextPaymentDate)
                {
                    //pula linha
                    Console.WriteLine("\r\n");
                    Console.WriteLine(categorias[1].Nome);
                }
                else if (valorNegociacao > categorias[2].Valor && setorCliente == "Publico") // && dtReferencia > categorias[2].NextPaymentDate)
                {
                    //pula linha
                    Console.WriteLine("\r\n");
                    Console.WriteLine(categorias[2].Nome);
                }
                else
                {
                    Console.WriteLine("Não foi possível processar! Verifique as informações de entrada"); 
                }

                //pula linha
                Console.WriteLine("\r\n");

                //para o console para exibição
                Console.ReadKey();
            }

        }

    }

}
