using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;

namespace PM022PRestApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAlumPage : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        
        public CreateAlumPage()
        {
            InitializeComponent();
        }

        private Byte[] traeImagenByteArray()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    return memory.ToArray();
                }
            }
            return null;
        }


        private String traeImagenToBase64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte =  memory.ToArray();

                    string Base64String = Convert.ToBase64String(fotobyte);
                    return Base64String;
                }
            }
            return null;
        }

        private async void btncreate_Clicked(object sender, EventArgs e)
        {
            var alum = new Models.Alumno
            {
                nombres = nombres.Text,
                apellidos = apelllidos.Text,
                edad =45,
                direccion = direccion.Text,
                sexo = sexo.SelectedItem.ToString(),
                idcarrera = idcarrera.SelectedItem.ToString(),
                foto = traeImagenToBase64()
            };

            await Controllers.EmpleadosController.CreateAlumno(alum);
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "FotoApp",
                Name = "PhotoAlumn.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                Foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }
    }
}