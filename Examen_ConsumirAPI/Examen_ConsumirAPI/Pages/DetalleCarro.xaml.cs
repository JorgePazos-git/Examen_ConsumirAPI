using AppExamen.APIConsumer;
using Examen_ConsumirAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_ConsumirAPI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleCarro : ContentPage
    {
        public Carro carro;
        public CarroAux carroAux;
        public bool IsUpdateButtonVisible { get; set; }
        public bool IsAddButtonVisible { get; set; }
        public bool IsDeleteButtonVisible { get; set; }
        public bool IsPlacaEnabled { get; set; }

        public bool IsImageVisible { get; set; }

        public DetalleCarro()
        {
            InitializeComponent();
            IsUpdateButtonVisible = false;
            IsDeleteButtonVisible = false;
            IsAddButtonVisible = true;
            IsPlacaEnabled = true;
            IsImageVisible = true;
            // Establecer el contexto de enlace de datos
            BindingContext = this;
        }

        private string url = "https://mondodbapi.azurewebsites.net/api/carro/";

        public DetalleCarro(Carro carro)
        {
            InitializeComponent();

            IsUpdateButtonVisible = true;
            IsDeleteButtonVisible = true;
            IsAddButtonVisible = false;
            IsPlacaEnabled=false;
            IsImageVisible = true;

            // Establecer el contexto de enlace de datos
            BindingContext = this;

            this.carro = carro;
            if (carro != null)
            {
                txtmarca.Text = carro.marca;
                txtmodelo.Text = carro.modelo;
                txtcolor.Text = carro.color;
                txtplaca.Text = carro.placa;
                txtano.Text = carro.ano.ToString();
                txtprecio.Text = carro.precio.ToString();
                txtrutaimagen.Text = carro.rutaimagen;
                image.Source = carro.rutaimagen;
            }
        }

        private async void OnActualizarClicked(object sender, EventArgs e)
        {
            try
            {
                var datos = new CarroAux
                {
                    marca = txtmarca.Text,
                    modelo = txtmodelo.Text,
                    color = txtcolor.Text,
                    placa = txtplaca.Text,
                    ano = int.Parse(txtano.Text),
                    precio = int.Parse(txtprecio.Text),
                    rutaimagen = txtrutaimagen.Text
                };

                APIConsumer<CarroAux>.Update(url + "placa/"+ txtplaca.Text.ToString(), datos);

                await DisplayAlert("Éxito", "Los datos se han actualizado correctamente.", "Aceptar");
                await Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ha ocurrido un error al actualizar los datos: " + ex.Message, "Aceptar");
            }
        }

        private async void OnAgregarClicked(object sender, EventArgs e)
        {
            try
            {
                var datos = new CarroAux
                {
                    marca = txtmarca.Text,
                    modelo = txtmodelo.Text,
                    color = txtcolor.Text,
                    placa = txtplaca.Text,
                    ano = int.Parse(txtano.Text),
                    precio = int.Parse(txtprecio.Text),
                    rutaimagen = txtrutaimagen.Text
                };

                APIConsumer<CarroAux>.Insert(url, datos);

                await DisplayAlert("Éxito", "Los datos se han ingresado correctamente.", "Aceptar");
                await Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ha ocurrido un error al ingresar los datos: " + ex.Message, "Aceptar");
            }
        }

        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            try
            {
                APIConsumer<CarroAux>.Delete(url + txtplaca.Text.ToString());

                await DisplayAlert("Éxito", "Auto Eliminado.", "Aceptar");
                await Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ha ocurrido un error al ingresar los datos: " + ex.Message, "Aceptar");
            }
        }

        private async void OnSelectImageClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Seleccionar imagen"
                });

                if (result != null)
                {
                    // La ruta de la imagen seleccionada estará en result.FullPath
                    txtrutaimagen.Text = result.FullPath;
                    image.Source = result.FullPath;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Ha ocurrido un error al ingresar la imagen: " + ex.Message, "Aceptar");
            }
        }
    }
}

