using PP.Maui.ViewModels;

namespace PP.Maui.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientDetailView : ContentPage
{
    public int ClientId { get; set; }
    public ClientDetailView()
    {
        InitializeComponent();
    }

    private void OkButton(object sender, EventArgs e)
    {
        var binding = (BindingContext as ClientViewModel);
        binding.AddOrUpdate();
        Shell.Current.GoToAsync("//Clients");
    }

    private void onarriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel(ClientId);
    }

    private void cancelbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    private void addprojectbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//projectview");
    }

    private void ProjectDeleteButton(object sender, EventArgs e)
    {
        var binding = (BindingContext as ClientViewModel);
        binding.RefreshProjectList();
    }

    private void EditProjectbutton(object sender, EventArgs e)
    {
        var binding = (BindingContext as ClientViewModel);
        binding.RefreshProjectList();
    }
}