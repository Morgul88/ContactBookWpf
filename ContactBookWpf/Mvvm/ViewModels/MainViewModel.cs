
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBookWpf.Mvvm.Services;
using ContactBookWpf.Mvvm.Views;
using Microsoft.Extensions.DependencyInjection;


namespace ContactBookWpf.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject? _currentViewModel;
    
    private readonly IServiceProvider _sp;
    public MainViewModel(IServiceProvider sp)
    {
        _sp = sp;
        CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        
        
    }
}
