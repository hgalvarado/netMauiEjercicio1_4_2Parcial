using netMauiEjercicio1_4.Models;

namespace netMauiEjercicio1_4.Views;

public partial class PageListPerson : ContentPage
{
    ClassPerson itemSeleccionado = null;
    public static byte[] photoSelected;
    public PageListPerson()
	{
		InitializeComponent();
	}
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        list.ItemsSource = await App.Instancia.listPerson();
    }

    private async void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            itemSeleccionado = e.CurrentSelection.FirstOrDefault() as ClassPerson;
            photoSelected = itemSeleccionado.classFhoto;


            await Navigation.PushAsync(new Views.PageViewPhoto());
            list.SelectedItem = null;
        }
    }
}