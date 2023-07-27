using PP.Maui.ViewModels;

namespace PP.Maui.Views;


public partial class TimeEntryView : ContentPage
{
    public TimeEntryView()
    {
        InitializeComponent();
        BindingContext = new TimeViewViewModel();
    }

    private void onarrived(object sender, NavigatedToEventArgs e)
    {
        var binding = (BindingContext as TimeViewViewModel);
        binding.RefreshTimelist();
    }

    private void backbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void addbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//addtime");
    }

    private void deletebutton(object sender, EventArgs e)
    {
        var binding = (BindingContext as TimeViewViewModel);
        binding.RefreshTimelist();
    }
    private void editbutton(object sender, EventArgs e)
    {
        var binding = (BindingContext as TimeViewViewModel);
        binding.RefreshTimelist();
    }

}

