using PP.Maui.ViewModels;

namespace PP.Maui.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectView : ContentPage
{
    public int ClientId { get; set; }
    public ProjectView()
    {
        InitializeComponent();
        BindingContext = new ProjectViewModel();
    }

    private void cancelbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    private void OkButton(object sender, EventArgs e)
    {
        var binding = (BindingContext as ProjectViewModel);
        binding.addorupdate();

        Shell.Current.GoToAsync("//Clients");

    }
    private void onarrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewModel(ClientId);
    }
}