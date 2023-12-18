

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactBookWpf.Mvvm.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace ContactBookWpf.Mvvm.Services;

public class ContactServices
{
    private readonly FileService _fileService = new FileService(@"C:\Projects\ContactBookWpf\content.json");

    private List<Contacts> _contactList = [];
    

    public void AddContact(Contacts contacts)
    {
        
        if (!string.IsNullOrWhiteSpace(contacts.FirstName))
        {
            _contactList.Add(contacts);
            
        }
    }
    
    public void GetFileFromComp()
    {
        

        // Hämta info från filen på datorn
        var content = _fileService.GetContentFromFile();

        var settings = new JsonSerializerSettings
        {
            // Ställer in inställningar för type
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented,
        };
        // Om filen finns går jag in i if
        if (!string.IsNullOrEmpty(content))
        {
            // Deserialisera innehållet från filen och fyll contacts
            _contactList = JsonConvert.DeserializeObject<List<Contacts>>(content, settings)!;
        }

       
    }
    public void SaveToFileOnComp(ObservableCollection<Contacts> contacts)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

        _fileService.SaveContentToFile(JsonConvert.SerializeObject(contacts, settings));
    }
    public ObservableCollection<Contacts> GetAll()
    {
        ObservableCollection<Contacts> contacts = new();

        foreach (var contact in _contactList)
        {
            contacts.Add(contact);
        }

        return contacts;
    }
    



    public ObservableCollection<Contacts> ViewOneContact(string mail)
    {
        
        // Antagande: _contactList är en lista av Contact-objekt
        var findContacts = _contactList.FindAll(x => x.Email == mail.Trim());
        ObservableCollection<Contacts> contacts = new();
        if (findContacts.Count > 0) 
        {
            

            // Lägg till de hittade kontakterna i ObservableCollection
            foreach (var contact in findContacts)
            {
                contacts.Add(contact);

            }
        }
        return contacts;
    }
}
