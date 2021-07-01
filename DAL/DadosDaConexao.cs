using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexao
    {
        public static String server;// = @"localhos
        public static String database;// = "dbnfestoque";
        public static String userid;// = "root";
        public static String pass;// = "";
        public static String port;// 

        static DadosDaConexao()
        {
            string conteudo = "";
            string[] valor = new string[5];
            int counter = 0;
            // Leia o arquivo e exiba-o linha por linha.
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\ConciliacaoBancaria\conexao.txt");  // cliente Servidor
            //System.IO.StreamReader file = new System.IO.StreamReader(@"C:\StringConexaoTeste\conexaoConsolidador.txt"); // localhost

            while ((conteudo = file.ReadLine()) != null)
            {
                //conteudo = line;
                //System.Console.WriteLine(conteudo);
                valor[counter] = conteudo;
                switch (counter)
                {
                    case 0: server = valor[counter]; break;
                    case 1: database = valor[counter]; break;
                    case 2: userid = valor[counter]; break;
                    case 3: pass = valor[counter]; break;
                    case 4: port = valor[counter]; break;
                }
                counter++;
            }
            file.Close();
        }
        public static String StringDeConexao
        {
            get
            {
                return @"server=" + server + ";database=" + database + ";userid=" + userid + ";password=" + pass + ";port=" + port;
            }
        }
    }
}
