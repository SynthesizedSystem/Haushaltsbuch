using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.Extensions.DependencyInjection;
using Haushaltsbuch.ViewModel;
using Windows.UI;
using Microsoft.UI.Xaml.Controls.Primitives;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Haushaltsbuch.View;

public sealed partial class NewTransactionView : UserControl
{
    public NewTransactionView()
    {
        InitializeComponent();
        this.DataContext = App.Current.Services.GetService<NewTransactionViewModel>();
    }
}
