using Plugin.Media;

namespace netMauiEjercicio1_4
{
    public partial class MainPage : ContentPage
    {

        Plugin.Media.Abstractions.MediaFile photo = null;
        public MainPage()
        {
            InitializeComponent();
        }

        public byte[] ImageToArrayByte()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();
                    return data;
                }
            }
            return null;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            
        }

        private async void btnCapture_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "ALBUM",
                Name = "Foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                imgPhoto.Source = ImageSource.FromStream(() => {
                    return photo.GetStream();
                });
            }
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtName.Text)||!String.IsNullOrEmpty(txtDescription.Text))
            {
                var person = new Models.ClassPerson
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    classFhoto = ImageToArrayByte()
                };
                if (await App.Instancia.addPerson(person) > 0)
                {
                    await DisplayAlert("Aviso", "Registro Agregado", "Ok");
                }
                else
                {
                    await DisplayAlert("Alerta", "Ocurrio un error, revise si no hay campos vacios", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Mensaje", "Llene por favor los campos vacios", "Ok");

            }
        }

        private async void btnList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageListPerson());
        }
    }
}