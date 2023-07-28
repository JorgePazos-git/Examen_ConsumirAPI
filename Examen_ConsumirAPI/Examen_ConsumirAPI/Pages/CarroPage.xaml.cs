using AppExamen.APIConsumer;
using Examen_ConsumirAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_ConsumirAPI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarroPage : ContentPage
    {
        private string url = "https://mondodbapi.azurewebsites.net/api/carro/";

        public CarroPage()
        {
            InitializeComponent();
            List<Carro> listaCarros = ReadAllCarros(); // Obtén la lista de deportistas desde tu proceso de obtención de datos

            carrosListView.ItemsSource = listaCarros;
        }

        private List<Carro> ReadAllCarros()
        {
            var carros = APIConsumer<Carro>.Select(url);
            var lista = carros.Select(f => new Carro
            {
                id = f.id,
                marca = f.marca,
                modelo = f.modelo,
                color = f.color,
                placa = f.placa,
                ano = f.ano,
                precio = f.precio,
                rutaimagen = f.rutaimagen

            }).ToList();

            return lista;

        }

        private void Label_Tapped(object sender, EventArgs e)
        {
            // Obtén el objeto o la información completa relacionada con el elemento seleccionado
            var selectedItem = ((Label)sender).BindingContext;

            Navigation.PushAsync(new DetalleCarro((Carro)selectedItem)); // Ejemplo en Xamarin.Forms
        }
        private void AgregarButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetalleCarro());
        }
    }
}