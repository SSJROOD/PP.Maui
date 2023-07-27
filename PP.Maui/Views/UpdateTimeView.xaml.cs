using PP.Maui.ViewModels;

namespace PP.Maui.Views;

[QueryProperty(nameof(projectid), "pID")]
[QueryProperty(nameof(emmpid), "eID")]
public partial class UpdateTimeView : ContentPage
{
    public int projectid { get; set; }
    public int emmpid { get; set; }
    public UpdateTimeView()
    {
        InitializeComponent();
    }

    private void confirmbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//timeentryview");
    }

    private void cancelbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//timeentryview");
    }
    private void onarriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewModel(projectid, emmpid);
    }

}