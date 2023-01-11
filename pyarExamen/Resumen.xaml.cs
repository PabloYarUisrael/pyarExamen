using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pyarExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resumen : ContentPage
    {
        public Resumen(string usuario, string nombre, string pagoInicial, string pagoMensual)
        {
            double pagoTotal = (Convert.ToDouble(pagoMensual)*5) + Convert.ToDouble(pagoInicial);
            InitializeComponent();
            lblUsuario.Text = usuario;
            txtNombre.Text = nombre;
            txtTotal.Text = Convert.ToString(pagoTotal);
        }

        private void btnAcercaDe_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Información", "Esta aplicación fue desarrolada por Pablo Yar, Estudiante de la Universidad Israel", "Cerrar");
        }
    }
}