

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactBookWpf.Mvvm.Models;
using ContactBookWpf.Mvvm.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace ContactBookWpf.Mvvm.ViewModels;

public partial class ContactAddViewModel: ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactServices _contactService;
    
    [ObservableProperty]
    private Contacts _contactForm = new();
    
    
    public ContactAddViewModel(IServiceProvider sp, ContactServices contactService)
    {
        _sp = sp;
        _contactService = contactService;
        
    }

    [RelayCommand]
    public void AddContactToList()
    {
        _contactService.AddContact(ContactForm);
        
    }
    [RelayCommand]
    public void NavigateToList()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetService<ContactListViewModel>();
    }
}
