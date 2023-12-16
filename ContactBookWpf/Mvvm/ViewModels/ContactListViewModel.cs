

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
    private ObservableCollection<Contacts> _contactList = new ObservableCollection<Contacts>();

    public ContactListViewModel(IServiceProvider sp, ContactServices contactService)
    {
        _sp = sp;
        _contactService = contactService;

        ContactList = _contactService.GetAll();

    }
    //Försök att läggga denna i en ny vy
    [RelayCommand]
    public void ShowContact(string email)
    {
        if(email != null)
        {
            ContactList = new ObservableCollection<Contacts>(_contactService.ViewOneContact(email));
        }
    }

    [RelayCommand]
    public void SaveFileToFolder()
    {
        _contactService.SaveToFileOnComp(ContactList);
    }

    [RelayCommand]
    public void GetContactsFromFile()
    {
        _contactService.GetFileFromComp();
        ContactList = _contactService.GetAll();
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
        if (contact != null!)
        {
            ContactList.Remove(contact);
           
        }
        
    }
    
}
