using PP.Maui.ViewModels;

namespace PP.Maui.Views;

public partial class AddTimeView : ContentPage
{
    public AddTimeView()
    {
        InitializeComponent();
    }

    private void confirmbutton(object sender, EventArgs e)
    {
        var binding = (BindingContext as TimeViewModel);
        binding.AddTime();
        Shell.Current.GoToAsync("//timeentryview");
    }

    private void cancelbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//timeentryview");
    }

    private void onarriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewModel();
    }

}