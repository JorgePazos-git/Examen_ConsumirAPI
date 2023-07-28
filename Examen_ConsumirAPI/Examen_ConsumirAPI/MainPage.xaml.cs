using AppExamen.Models;
using AppExamen.ViewModels;
using Examen_ConsumirAPI.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Examen_ConsumirAPI
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private bool isMenuVisible;

        public bool IsMenuVisible
        {
            get { return isMenuVisible; }
            set
            {
                if (isMenuVisible != value)
                {
                    isMenuVisible = value;
                    OnPropertyChanged(nameof(IsMenuVisible));
                }
            }
        }

        public ICommand ToggleMenuCommand { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            var viewModel = new MainViewModel();
            BindingContext = viewModel;
            viewModel.MenuFrame = menuFrame;

            ToggleMenuCommand = new Command(() =>
            {
                viewModel.IsMenuVisible = !viewModel.IsMenuVisible;
            });

            NavigationPage.SetHasNavigationBar(this, false);
            // Establecer el valor inicial de IsMenuVisible en false
            viewModel.IsMenuVisible = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedOption = (MenuOption)e.SelectedItem;

            // Realizar la navegación a la página correspondiente según la opción seleccionada
            switch (selectedOption.Title)
            {
                case "Carro":
                    Navigation.PushAsync(new CarroPage());
                    break;
            }

            // Desactivar la selección del elemento
            ((ListView)sender).SelectedItem = null;
        }
    }
}
