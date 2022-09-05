using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opak3roc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int pocetRadku = textBox1.Lines.Count();
            string[] p= new string[pocetRadku];
            for(int i =0;i<textBox1.Lines.Count();i++)
            {
                string radek = textBox1.Lines[i];
                char[] separators = { ',', ' ', '.' };
                string[] slova = radek.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string nejkratsiSlovo = slova[0];
                for (int j = 0; j < slova.Length; j++)
                {
                    if(slova[j].Length<nejkratsiSlovo.Length)
                    {
                        nejkratsiSlovo = slova[j];
                    }
                }
                p[i] = nejkratsiSlovo;
                listBox1.Items.Add(p[i]);
            }
        }

        void ZpracujPole(string[] pole, string podretezec, out string prvnisCifrou, out string posledniKonci)
        {
            prvnisCifrou = "";
            posledniKonci = "";
            int delkaRetezce = podretezec.Length;
            bool nalezenaCifra = false;
            for(int i =0; i < pole.Length;i++)
            {
                string slovo = pole[i];
                int delkaSlova = slovo.Length;
                string konecSlova = slovo.Substring(delkaSlova - delkaRetezce);
                if(konecSlova==podretezec)
                {
                    posledniKonci = slovo;
                }
                for(int j = 0;j<slovo.Length&&!nalezenaCifra;j++)
                {
                    if (char.IsDigit(slovo[j]))
                    {
                        prvnisCifrou = slovo;
                        nalezenaCifra = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] pole = { "Václav", "Šimon", "M1atěj", "Pavel" };
            string podretezec = "on";
            string prvnisCifrou = "";
            string posledniKonci = "";
            ZpracujPole(pole, podretezec, out prvnisCifrou, out posledniKonci);
            MessageBox.Show("První slovo s cifrou je: " + prvnisCifrou + "\nPoslední slovo končící zadaným řetězcem je: " +posledniKonci);
        }
    }
}
