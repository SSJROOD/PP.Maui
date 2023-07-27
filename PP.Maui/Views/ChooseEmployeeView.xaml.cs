using PP.Library.Models;
using PP.Maui.ViewModels;
namespace PP.Maui.Views;


[QueryProperty(nameof(projectId), "projectid")]
public partial class ChooseEmployeeView : ContentPage
{
	public int projectId { get; set; }
	public ChooseEmployeeView()
	{
		InitializeComponent(); 
	}

    private void onarriving(object sender, NavigatedToEventArgs e)
    {
		BindingContext = new BillingViewModel(projectId);
    }
}

/*The name is misleading because this page was going to be used for something else
 * but i changed what it was going to be used for, but i didnt change the name
 */