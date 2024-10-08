using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculadoraIphone_LGLA
{
    public partial class MainPage : ContentPage
    {
        double primerNum = 0;
        double segundoNum = 0;
        string operador;
        bool clickOpe = false; // Presion de un operador 
        bool calculoRealizado = false; 

        public MainPage()
        {
            InitializeComponent();
        }

        // Evento para botones de números
        public void Numeros(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (Pantalla.Text == "0" || clickOpe || calculoRealizado)
            {
                Pantalla.Text = button.Text;
                calculoRealizado = false; 
            }
            else
            {
                Pantalla.Text += button.Text; 
            }

            clickOpe = false;
        }

        // Operadores
        public void Operadores(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            
            if (!clickOpe)
            {
                if (primerNum != 0)
                {
                    segundoNum = Convert.ToDouble(Pantalla.Text);
                    Calcular(); 
                }
                else
                {
                    primerNum = Convert.ToDouble(Pantalla.Text);
                }
            }

            operador = button.Text; 
            clickOpe = true; 
        }

        private void Calcular()
        {
            double resultado = 0;

            switch (operador)
            {
                case "+":
                    resultado = primerNum + segundoNum;
                    break;
                case "-":
                    resultado = primerNum - segundoNum;
                    break;
                case "×":
                    resultado = primerNum * segundoNum;
                    break;
                case "÷":
                    if (segundoNum != 0)
                        resultado = primerNum / segundoNum;
                    else
                    {
                        Pantalla.Text = "Error"; 
                        return;
                    }
                    break;
                case "%":
                    resultado = primerNum / 100;
                    break;
            }

            Pantalla.Text = resultado.ToString();
            primerNum = resultado; 
            calculoRealizado = true; 
        }

        
        public void Igual(object sender, EventArgs e)
        {
            segundoNum = Convert.ToDouble(Pantalla.Text); 
            Calcular(); 
        }

        // Borrar todo 
        public void Limpiar(object sender, EventArgs e)
        {
            primerNum = 0;
            segundoNum = 0;
            Pantalla.Text = "0";
            clickOpe = false;
            calculoRealizado = false;
        }

        // Agregar decimal
        public void Decimal(object sender, EventArgs e)
        {
            if (!Pantalla.Text.Contains(","))
            {
                Pantalla.Text += ",";
            }
        }

        // Borrar un solo número
        private void borrarUno(object sender, EventArgs e)
        {
            if (Pantalla.Text.Length > 1)
            {
                Pantalla.Text = Pantalla.Text.Substring(0, Pantalla.Text.Length - 1);
            }
            else
            {
                Pantalla.Text = "0";
            }
        }
    }
}
