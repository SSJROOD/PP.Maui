using PP.Maui.ViewModels;

namespace PP.Maui.Views;


public partial class ProjectListView : ContentPage
{
    public ProjectListView()
    {
        InitializeComponent();
        BindingContext = new ProjectViewViewModel();
    }

    private void backbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }


    private void onArrived(object sender, NavigatedToEventArgs e)
    {
        var binding = (BindingContext as ProjectViewViewModel);
        binding.RefreshProjectList();
    }
}