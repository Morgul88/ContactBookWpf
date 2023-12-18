

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
    private readonly ContactUpdateViewModel _contactUpdateViewModel;
    [ObservableProperty]
    private ObservableCollection<Contacts> _contactList = [];
    
    private readonly ContactPersonViewModel _contactPersonViewModel;

    public ContactListViewModel(IServiceProvider sp, ContactServices contactService, ContactUpdateViewModel contactUpdateViewModel, ContactPersonViewModel contactPersonViewModel)
    {
        _sp = sp;
        _contactService = contactService;
        _contactPersonViewModel = contactPersonViewModel;
        ContactList = _contactService.GetAll();
        _contactUpdateViewModel = contactUpdateViewModel;
    }
    //Försök att läggga denna i en ny vy
    [RelayCommand]
    public void ShowContact(Contacts contact)
    {
        // Visa detaljer om den valda kontakten i ContactPersonViewModel
        _contactPersonViewModel.ShowContactOnViewList(contact);

        // Byt vyn till ContactPersonViewModel
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _contactPersonViewModel;
    }

    [RelayCommand]
    public void SaveFileToFolder()
    {
        _contactService.SaveToFileOnComp(ContactList);
        GetContactsFromFile();
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
    [RelayCommand]
    public void UpdateContact(Contacts contact)
    {
        if (contact != null)
        {
            var mainViewModel = _sp.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _contactUpdateViewModel;

            // Överför befintliga uppgifter till ContactUpdateViewModel
            _contactUpdateViewModel.Initialize(contact);

            // Uppdatera CurrentViewModel i MainViewModel
            mainViewModel.CurrentViewModel = _contactUpdateViewModel;
        }
    }

}
