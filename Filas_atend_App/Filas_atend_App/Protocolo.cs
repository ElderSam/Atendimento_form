using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filas_atend_App
{
    class Protocolo
    {
        public int Num { get; private set; } //número do protocolo
        public String NomeRes { get; private set; } // nome do responsável
        public String Desc { get; private set; } //descrição do protocolo

        //Construtor
        public Protocolo()
        {
        
        }

        public void setAll (int n, String nome, String dsc)
        {
            this.Num = n;
            this.NomeRes = nome;
            this.Desc = dsc;
        }
        public void imprimir()
        {
            Console.WriteLine(this.Num + " " + this.NomeRes);
        }

    }
}
