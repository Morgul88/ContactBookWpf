

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactBookWpf.Mvvm.Models;
using ContactBookWpf.Mvvm.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace ContactBookWpf.Mvvm.ViewModels;

public partial class ContactUpdateViewModel: ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactServices _contactService;


    [ObservableProperty]
    private Contacts _contactForm = new();
    public ContactUpdateViewModel(IServiceProvider sp,ContactServices contactServices)
    {
        _sp = sp;
        _contactService = contactServices;
        ContactForm = _contactService.CurrentContact;

    }


    [RelayCommand]
    public void GoToList()
    {
        _contactService.UpdateContact(ContactForm);
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }

    
}

