

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactBookWpf.Mvvm.Models;
using ContactBookWpf.Mvvm.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace ContactBookWpf.Mvvm.ViewModels;

public partial class ContactPersonViewModel: ObservableObject
{
    
    
    private readonly ContactServices _contactService;

    private readonly IServiceProvider _sp;

    [ObservableProperty]
    private Contacts _contactForm = new();
    public ContactPersonViewModel(IServiceProvider sp, ContactServices contactServices)
    {
        _sp = sp;
        _contactService = contactServices;
        ContactForm = _contactService.CurrentContact;
        
    }

    [RelayCommand]
    public void NavigateToList()
    {
        
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
        
    }
    
    













}
