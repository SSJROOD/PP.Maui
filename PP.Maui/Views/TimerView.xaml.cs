using PP.Maui.ViewModels;

namespace PP.Maui.Views;

public partial class TimerView : ContentPage
{
    public TimerView(int projectId)
    {
        InitializeComponent();
        BindingContext = new TimerViewModel(projectId);
    }
}