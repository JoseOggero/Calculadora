using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora2
{
    public enum Operacion
    {
        NoDefinida = 0,
        Suma = 1,
        Resta = 2,
        Division = 3,
        Multiplicacion = 4,
        Porcentaje = 5
    }
    public partial class Form1 : Form
    {
        double valor1 = 0;
        double valor2 = 0;
        Operacion operador = Operacion.NoDefinida;
        public Form1()
        {
            InitializeComponent();
        }

        private void LeerNumero(string numero)
        {
            if (CajaTexto.Text == "0" && CajaTexto.Text != null)
            {
                CajaTexto.Text = numero;
            }
            else
            {
                CajaTexto.Text += numero;
            }
        }

        private double EjecutarOperacion()
        {
            double resultado = 0;
            switch (operador)
            {
                case Operacion.Suma:
                    resultado = valor1 + valor2;
                    break;
                case Operacion.Resta:
                    resultado = valor1 - valor2;
                    break;
                case Operacion.Division:
                    if (valor2 == 0)
                    {
                        MessageBox.Show("No se puede divir entre 0");
                        resultado = 0;
                    }
                    else
                    {
                        resultado = valor1 / valor2;
                    }
                    break;
                case Operacion.Multiplicacion:
                    resultado = valor1 * valor2;
                    break;
                case Operacion.Porcentaje:
                    resultado = valor1 % valor2;
                    break;
            }
            return resultado;
        }
        private void Btn0_Click(object sender, EventArgs e)
        {
            if (CajaTexto.Text == "0") 
            {
                return;
            }
            else
            {
                CajaTexto.Text += "0";
            }
            
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            LeerNumero("1");
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            LeerNumero("2");
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            LeerNumero("3");
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            LeerNumero("4");
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            LeerNumero("5");
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            LeerNumero("6");
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            LeerNumero("7");
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            LeerNumero("8");
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            LeerNumero("9");
        }

        private void ObtenerValor(string operador)
        {
            valor1 = Convert.ToDouble(CajaTexto.Text);
            LblHistorial.Text = CajaTexto.Text + operador;
            CajaTexto.Text = "0";
        }

        private void BtnSuma_Click(object sender, EventArgs e)
        {
            operador = Operacion.Suma;
            ObtenerValor("+");
        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {
            if(valor2 == 0)
            {
                valor2 = Convert.ToDouble(CajaTexto.Text);
                LblHistorial.Text += valor2 + "=";
                double resultado = EjecutarOperacion();
                valor1 = 0;
                valor2 = 0;
                CajaTexto.Text = Convert.ToString(resultado);
            }
        }

        private void BtnResta_Click(object sender, EventArgs e)
        {
            operador = Operacion.Resta;
            ObtenerValor("-");
        }

        private void BtnMultiplicacion_Click(object sender, EventArgs e)
        {
            operador = Operacion.Multiplicacion;
            ObtenerValor("x");
        }

        private void BtnDivision_Click(object sender, EventArgs e)
        {
            operador = Operacion.Division;
            ObtenerValor("/");
        }

        private void BtnPorcentaje_Click(object sender, EventArgs e)
        {
            operador = Operacion.Porcentaje;
            ObtenerValor("%");
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            CajaTexto.Text = "0";
            LblHistorial.Text = "";
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (CajaTexto.Text.Length > 1)
            {
                string txtResultado = CajaTexto.Text;
                txtResultado = txtResultado.Substring(0, txtResultado.Length - 1);

                if(txtResultado.Length == 1 && txtResultado.Contains("-"))
                {
                    CajaTexto.Text = "0";
                }
                else
                {
                    CajaTexto.Text = txtResultado;
                }

                CajaTexto.Text = txtResultado;
            }
            else
            {
                CajaTexto.Text = "0";
            }
        }

        private void BtnPunto_Click(object sender, EventArgs e)
        {
            if (CajaTexto.Text.Contains(","))
            {
                return;
            }
                CajaTexto.Text += ",";
        }
    }
}
