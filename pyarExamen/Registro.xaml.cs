using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pyarExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        

        public Registro(string usuario)
        {
            InitializeComponent();
            lblUsuario.Text= $"Usuario conectado: {usuario}";
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            double costoCurso = 4000;

            if (ValidarFormulario("Monto Inicial", txtMontoInicial.Text))
            {
                double montoInicial = Convert.ToDouble(txtMontoInicial.Text);
                double restaMI = costoCurso - montoInicial;
                double divideNumCuotas = restaMI / 5;
                double aumnetaPorcentaje = costoCurso * 0.05;
                double totalPagar = (aumnetaPorcentaje/5) + divideNumCuotas;   
                txtPagoMensual.Text = Convert.ToString(totalPagar);
            }
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Resumen(lblUsuario.Text ,txtNombre.Text, txtMontoInicial.Text, txtPagoMensual.Text));


        }

        private bool ValidarFormulario(string nombreCampo, string valor)
        {

            if (string.IsNullOrEmpty(valor))
            {
                DisplayAlert("Error", $"El campo {nombreCampo} es requerido", "Cerrar");
                return false;
            }

            double numero;
            try
            {
                numero = Convert.ToDouble(valor);
            }
            catch (Exception)
            {
                return false;
            }
            string mensaje;

            if (nombreCampo== "Monto Inicial"  && (numero <= 0 || numero > 3999))
            {
                mensaje = $"En el campo {nombreCampo} solo puede ingresar valores desde 0.1 hasta 3999";
                DisplayAlert("Error", mensaje, "Cerrar");
                return false;
            }
            return true;
        }
    }
}