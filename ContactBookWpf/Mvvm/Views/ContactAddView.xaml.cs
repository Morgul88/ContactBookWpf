
using System.Windows.Controls;


namespace ContactBookWpf.Mvvm.Views;


public partial class ContactAddView : UserControl
{
    public ContactAddView()
    {
        InitializeComponent();
        Input_Name.Focus();
    }
}
