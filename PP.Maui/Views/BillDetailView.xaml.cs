using PP.Library.Models;
using PP.Maui.ViewModels;
namespace PP.Maui.Views;
[QueryProperty(nameof(EmployeeId), "eid")]
[QueryProperty(nameof(projectId), "pid")]
public partial class BillDetailView : ContentPage
{
    public int projectId { get; set; }
    public int EmployeeId { get; set; }
    public BillDetailView()
	{
		InitializeComponent();
	}

    private void onarriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new BillingViewModel(projectId,EmployeeId);

    }

    private void backbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//timeentryview");
    }

    private void okbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//timeentryview");
    }

}