using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace PM022PRestApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageBooks : ContentPage
    {
        public PageBooks()
        {
            InitializeComponent();
        }

        private async void btnconsumir_Clicked(object sender, EventArgs e)
        {
            var InternetAccess = Connectivity.NetworkAccess;
            if (InternetAccess == NetworkAccess.Internet)
            {
                List<Models.Books> listbooks = new List<Models.Books>();
                listbooks = await Controllers.BooksController.getBooks();
            }


        }
    }
}