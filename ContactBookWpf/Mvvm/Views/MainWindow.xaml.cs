
using ContactBookWpf.Mvvm.Models;
using ContactBookWpf.Mvvm.Services;
using ContactBookWpf.Mvvm.ViewModels;
using System.Windows;


namespace ContactBookWpf.Mvvm.Views;


public partial class MainWindow : Window
{

   
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        
        DataContext = viewModel;
        
    }

}
    