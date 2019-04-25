using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filas_atend_App
{
    public partial class Form1 : Form
    {



        int n = 0;
        int prioridade = 1;
        string prot;

        /* Listas de Priodidades: Alta, Média e Baixa */
        Queue<Protocolo> filaAlta = new Queue<Protocolo>();
        Queue<Protocolo> filaMedia = new Queue<Protocolo>();
        Queue<Protocolo> filaBaixa = new Queue<Protocolo>();

        Protocolo aux;
       
        int tamA, tamM, tamB;
        int atendimentos = 0;


        public Form1()
        {


            InitializeComponent();


            comboBox1.Items.Add("Alta");
            comboBox1.Items.Add("Média");
            comboBox1.Items.Add("Baixa");

            comboBox1.SelectedIndex = 0; //O que vai mostrar primeiro


        }




        private void txtNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxAlta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxMedia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDesc_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void listBoxBaixa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void btnInserir_Click(object sender, EventArgs e) //----------------------------------------------------------------------------------------
        {
            if ((txtNum.Text == "") || (txtNum.Text == " ")) //campo número vazio
            {
                MessageBox.Show("Informe um número válido");
                txtNum.Focus();
            }
            else if(!int.TryParse(txtNum.Text, out n))//número do protocolo não é valido
            {
                MessageBox.Show(txtNum.Text + " não é um número válido!");
                txtNum.Focus();
            }
            else if ((txtName.Text == "") || (txtName.Text == " "))//nome do responsável vazio
            {
                MessageBox.Show("Informe um nome válido!");
                txtName.Focus();
            }
            else if ((txtDesc.Text == "") || (txtDesc.Text == " "))//descrição vazia
            {
                MessageBox.Show("Escreva uma Descrição!");
                txtDesc.Focus();
            }
            else {
                n = int.Parse(txtNum.Text);
                Protocolo p = new Protocolo(); //precisa dar new aqui para não criar uma fila com o mesmo protocolo repetido
                p.setAll(n, txtName.Text, txtDesc.Text);


                int x = comboBox1.SelectedIndex;
                if (x == 0) //se foi escolhida prioridade ALTA------------------------------------------------
                {
                    
                    filaAlta.Enqueue(p);               
                    listBoxAlta.Items.Add(p.Num + " - " + p.NomeRes);
                }
                else if(x == 1) //prioridade MÉDIA
                {
                    filaMedia.Enqueue(p);
                    listBoxMedia.Items.Add(p.Num + " - " + p.NomeRes);
                }
                else if (x == 2) //prioridade BAIXA
                {
                    filaBaixa.Enqueue(p);
                    listBoxBaixa.Items.Add(p.Num + " - " + p.NomeRes);
                }
                else
                {
                    MessageBox.Show("Selecione uma prioridade!");
                    prioridade = 0;
                    
                }

                if(prioridade != 0)
                {
                    txtNum.Text = "";
                    txtName.Text = "";
                    txtDesc.Text = "";
                    comboBox1.SelectedIndex = 0;

                    txtNum.Focus();
                }

            }


            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chamar_Click(object sender, EventArgs e)
        {
            tamA = filaAlta.Count();
            tamM = filaMedia.Count();
            tamB = filaBaixa.Count();

            if (tamA > 0 && atendimentos < 5)
            {
                aux = filaAlta.Dequeue();     
                listBoxAlta.Items.RemoveAt(0);
                tamA = filaAlta.Count();
                MessageBox.Show("Protocolo " + aux.Num + " atendido!");
  
                atendimentos++;
            }
            else if (tamM > 0 && atendimentos < 5)
            {
                filaMedia.Dequeue();
  
                listBoxMedia.Items.RemoveAt(0);
                tamM = filaMedia.Count();
                MessageBox.Show("Protocolo " + aux.Num + " atendido!");
                atendimentos++;
            }
            else if (tamB > 0 && atendimentos < 5)
            {
                filaBaixa.Dequeue();
           
                listBoxBaixa.Items.RemoveAt(0);
                tamB = filaBaixa.Count();
                MessageBox.Show("Protocolo " + aux.Num + " atendido!");
                atendimentos++;
            }
            else if(tamA == 0 && tamM == 0 && tamB == 0)//Se todas as filas estão vazias
            {
                MessageBox.Show("Filas Vazias!");

            }
            else //então chegaram a 5 atendimentos
            {
               

                if(tamB > 0)
                {
                    MessageBox.Show("Atingiu 5 atendimentos! \n Vamos organizar as filas.");
                    aux = filaBaixa.Dequeue();
                    filaMedia.Enqueue(aux); //tira um da baixa e coloca na media  
                    listBoxBaixa.Items.RemoveAt(0);          
                    listBoxMedia.Items.Add(aux.Num + " - " + aux.NomeRes);

                    aux = filaMedia.Dequeue();
                    filaAlta.Enqueue(aux); // tira um da media e coloca na alta
                    listBoxMedia.Items.RemoveAt(0);
                    listBoxAlta.Items.Add(aux.Num + " - " + aux.NomeRes);
                  
                }
                atendimentos = 0; //mesmo se não tiver ninguem nas filas baixa e média, tem que zerar atendimentos, se não fica na mesma mensagem
            }


        }
    }
}
