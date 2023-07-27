using PP.Maui.ViewModels;

namespace PP.Maui.Views;

public partial class ClientView : ContentPage
{
    public ClientView()
    {
        InitializeComponent();
        BindingContext = new ClientViewViewModel();
    }

    private void BackButton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void refresh()
    {
        var binding = (BindingContext as ClientViewViewModel);
        binding.RefreshClientList();
    }

    private void DeleteButton(object sender, EventArgs e)
    {
        refresh();
    }

    private void AddButton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientDetail");
    }

    private void onArrived(object sender, NavigatedToEventArgs e)
    {
        refresh();
    }

    private void EditButton(object sender, EventArgs e)
    {
        refresh();
    }
    private void ProjectButton(object sender, EventArgs e)
    {
        refresh();
    }

    private void SearchButton(object sender, EventArgs e)
    {
        refresh();
    }
}