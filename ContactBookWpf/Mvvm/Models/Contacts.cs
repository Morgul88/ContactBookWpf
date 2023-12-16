﻿

namespace ContactBookWpf.Mvvm.Models;

public class Contacts
{
    

    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string HomeAdress { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public Guid Id { get; set; } = Guid.NewGuid();
}
