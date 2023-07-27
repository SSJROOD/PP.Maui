using PP.Maui.ViewModels;

namespace PP.Maui.Views;

[QueryProperty(nameof(EmpID), "empId")]

public partial class EmployeeDetailView : ContentPage
{
    public int EmpID { get; set; }

    public EmployeeDetailView()
	{
		InitializeComponent();
	}

    private void cancelbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//employees");
    }

    private void onarriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EmployeeViewModel(EmpID);
    }

    private void confirmbutton(object sender, EventArgs e)
    {
        var binding = (BindingContext as EmployeeViewModel);
        binding.AddOrUpdate();
        Shell.Current.GoToAsync("//employees");
    }

}