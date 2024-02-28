using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        bool buttonValue;
        private void Form1_Load(object sender, EventArgs e)
        {
            buttonValue = true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        double priceEuro, priceDollar;
        int day;

        const double k = 0.1; //коэффициент, задаём сами. нужен, чтобы на меньшее число после рандома менялось
        Random rnd = new Random(); //от 0 до 1
        private void btStart_Click(object sender, EventArgs e)
        {
            day = 0;
            buttonValue = true;
            priceEuro = (double)edPriceEuro.Value;
            priceDollar = (double)edPriceDollar.Value;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[0].Points.AddXY(0, priceEuro);
            chart1.Series[1].Points.AddXY(0, priceDollar);

            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(buttonValue)
            {
                day++;
                priceEuro = priceEuro * (1 + k * (rnd.NextDouble() - 0.5)); //рандом от -0.5 до 0.5
                priceDollar = priceDollar * (1 + k * (rnd.NextDouble() - 0.5));
                chart1.Series[0].Points.AddXY(day, priceEuro);
                chart1.Series[1].Points.AddXY(day, priceDollar);
            }

        }

        private void btStop_Click(object sender, EventArgs e)
        {
            buttonValue = false;
            timer1.Stop(); 
        }
    }
}
