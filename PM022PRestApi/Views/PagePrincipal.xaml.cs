using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM022PRestApi.Models;
using PM022PRestApi.Controllers;

namespace PM022PRestApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

       
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var InternetAccess = Connectivity.NetworkAccess;

            if (InternetAccess == NetworkAccess.Internet)
            {
                try
                {
                    listalumnos.ItemsSource = await Controllers.EmpleadosController.getEmple();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "Sin comunicacion", "OK");
                }   
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateAlumPage());
        }

        private void toolupdate_Clicked(object sender, EventArgs e)
        {

        }

        private void listalumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}