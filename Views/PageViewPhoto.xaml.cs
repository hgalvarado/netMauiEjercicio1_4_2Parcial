namespace netMauiEjercicio1_4.Views;

public partial class PageViewPhoto : ContentPage
{
	public PageViewPhoto()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        image.Source = ImageSource.FromStream(() => new MemoryStream(PageListPerson.photoSelected));
    }
}