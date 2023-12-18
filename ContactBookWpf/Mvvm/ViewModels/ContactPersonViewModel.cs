

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactBookWpf.Mvvm.Models;
using ContactBookWpf.Mvvm.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace ContactBookWpf.Mvvm.ViewModels;

public partial class ContactPersonViewModel: ObservableObject
{
    
    [ObservableProperty]
    private ObservableCollection<Contacts> _secondList = [];
    
    private readonly ContactServices _contactService;

    private readonly IServiceProvider _sp;

    public ContactPersonViewModel(IServiceProvider sp, ContactServices contactServices)
    {
        _sp = sp;
        _contactService = contactServices;
        


    }
    [RelayCommand]
    public void NavigateToList()
    {
        
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        
    }
    
    [RelayCommand]
    public void ShowContactOnViewList(Contacts contact)
    {
        SecondList.Clear(); // Rensa listan innan du lägger till den nya kontakten
        SecondList.Add(contact); // Lägg till den valda kontakten
    }













}
