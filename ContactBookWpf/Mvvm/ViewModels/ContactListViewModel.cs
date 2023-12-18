

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactBookWpf.Mvvm.Models;
using ContactBookWpf.Mvvm.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace ContactBookWpf.Mvvm.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;
    private readonly ContactServices _contactService;


    [ObservableProperty]
    private Contacts _contactForm = new();

    public ContactListViewModel(IServiceProvider sp, ContactServices contactService)
    {
        _sp = sp;
        _contactService = contactService;
        
        ContactList = new ObservableCollection<Contacts>(_contactService.GetAll());
        
    }

    [RelayCommand]
    public void ShowContact(Contacts contact)
    {
        _contactService.CurrentContact = contact;
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactPersonViewModel>();
    }
    [ObservableProperty]
    private ObservableCollection<Contacts> contactList = [];

    [RelayCommand]
    public void SaveFileToFolder()
    {
        _contactService.SaveToFileOnComp(ContactList);
        ContactList = new ObservableCollection<Contacts>(_contactService.GetAll());
    }

    [RelayCommand]
    public void GetContactsFromFile()
    {
        _contactService.GetFileFromComp();
        ContactList = new ObservableCollection<Contacts>(_contactService.GetAll());
    }

    [RelayCommand]
    public void NavigateToAdd()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactAddViewModel>();
    }
    [RelayCommand]
    public void RemoveContact(Contacts contact)
    {
        _contactService.RemoveContact(contact);
        ContactList = new ObservableCollection<Contacts>(_contactService.GetAll());
    }
    [RelayCommand]
    public void UpdateContact(Contacts contact)
    {
        
        _contactService.CurrentContact = contact;

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactUpdateViewModel>();

    }

}
