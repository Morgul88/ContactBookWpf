

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactBookWpf.Mvvm.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace ContactBookWpf.Mvvm.Services;

/// <summary>
/// ContactServices där alla mina metoder ligger:
/// </summary>
public class ContactServices
{
    private readonly FileService _fileService = new FileService(@"C:\Projects\ContactBookWpf\content.json");

    private List<Contacts> _contactList = [];

    public Contacts CurrentContact { get; set; } = null!;

    /// <summary>
    /// Stoppar in en kontakt. Om strängen inte har whitespaces eller inteär null så läggs kontakten till i listan.
    /// </summary>
    /// <param name="contact"></param>
    public bool AddContact(Contacts contact)
    {
        
        if (!string.IsNullOrWhiteSpace(contact.FirstName))
        {
            _contactList.Add(contact);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Hämtar information från en fil på datorn och fyller kontaktlistan med deserialiserade kontakter.
    /// </summary>
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
    /// <summary>
    /// Sparar min listas som en fil på datorn.
    /// </summary>
    /// <param name="contacts"></param>
    public void SaveToFileOnComp(ObservableCollection<Contacts> contacts)
    {
        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects
        };

        _fileService.SaveContentToFile(JsonConvert.SerializeObject(contacts, settings));
    }

    //public ObservableCollection<Contacts> GetAll()
    //{
    //    ObservableCollection<Contacts> contacts = new();

    //    foreach (var contact in _contactList)
    //    {
    //        contacts.Add(contact);
    //    }

    //    return contacts;
    //}

    /// <summary>
    /// Returnerar min lista _contactList
    /// </summary>
    /// <returns> returnerar listsan </returns>
    public IEnumerable<Contacts> GetAll()
    {
        return _contactList;
    }
    


    /// <summary>
    /// Letar upp en kontakt genom email. Sen lägger till de från listan i ett nytt objekt
    /// </summary>
    /// <param name="mail"></param>
    /// <returns>Returnerar den nya kontakten</returns>
    public ObservableCollection<Contacts> ViewOneContact(string mail)
    {
        
        
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

    /// <summary>
    /// Stoppar in en contact och letar i listan efter contakt med hjälp utav id.
    /// Om vi hittar en kontakt så ersätter vi den gamla kontakten med den nya
    /// </summary>
    /// <param name="contact"></param>
     public void UpdateContact(Contacts contact)
    {
        var myContact = _contactList.FirstOrDefault(x =>  x.Id == contact.Id);
        if (myContact != null) 
        {
            myContact = contact;
        }
    }

    /// <summary>
    /// Stoppar in en kontakt. letar upp ID. Tar kontakten från listan.
    /// </summary>
    /// <param name="contacts"></param>
    public void RemoveContact(Contacts contacts)
    {
        var contact = _contactList.FirstOrDefault(x => x.Id == contacts.Id);
        if (contact != null)
        {
            _contactList.Remove(contact);
        }
    }
}
