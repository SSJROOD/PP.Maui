using PP.Maui.ViewModels;

namespace PP.Maui.Views;

public partial class EmployeeView : ContentPage
{
    public EmployeeView()
    {
        InitializeComponent();
        BindingContext = new EmployeeViewViewModel();
    }

    private void backbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void addbutton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employeedetailview");

    }

    private void onArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployee();
    }

    private void DeleteButton(object sender, EventArgs e)
    {
        var binding = (BindingContext as EmployeeViewViewModel);
        binding.RefreshEmployee();
    }

    private void Searchbutton(object sender, EventArgs e)
    {
        var binding = (BindingContext as EmployeeViewViewModel);
        binding.ExecuteSearch();
    }

    private void EditButton(object sender, EventArgs e)
    {
        var binding = (BindingContext as EmployeeViewViewModel);
        binding.RefreshEmployee();
    }
}