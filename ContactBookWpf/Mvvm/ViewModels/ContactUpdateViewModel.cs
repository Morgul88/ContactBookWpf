

using CommunityToolkit.Mvvm.ComponentModel;

namespace ContactBookWpf.Mvvm.ViewModels;

public partial class ContactUpdateViewModel: ObservableObject
{
    private readonly IServiceProvider _sp;

    public ContactUpdateViewModel(IServiceProvider sp)
    {
        _sp = sp;
    }
}
