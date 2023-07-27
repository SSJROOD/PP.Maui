namespace PP.Maui;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

    private void ClientsClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    private void EmployeeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//employees");
    }

    private void timeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//timeentryview");
    }
}

