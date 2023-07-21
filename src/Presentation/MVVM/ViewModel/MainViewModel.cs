using Presentation.Core;
using Presentation.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.MVVM.ViewModel;
internal class MainViewModel : ObservableObject
{
    public ObservableCollection<MessageModel>? Messages { get; set; }
    public ObservableCollection<ContactModel>? Contacts { get; set; }


    /* Commands */
    private ContactModel _selectedContact;

    public ContactModel SelectedContact
    {
        get { return _selectedContact; }
        set { _selectedContact = value; OnPropertyChanged(); }

    }

    public RelayCommand SendCommand { get; set; }
    private string _message;

    public string Message
    {
        get { return _message; }
        set { _message = value; OnPropertyChanged(); }
    }



    public MainViewModel()
    {
        Messages = new();
        Contacts = new();

        SendCommand = new(o =>
        {
            Messages.Add(new()
            {
                Message = Message,
                FirstMessage = false
            });
            Message = "";
        });


        Messages.Add(new()
        {
            Username = "Ali",
            UsernameColor = "#409aff",
            ImageSource = "https://thewowstyle.com/wp-content/uploads/2015/01/nature-images..jpg",
            Message = "Test",
            TimeStamp = DateTimeOffset.UtcNow,
            IsNativeOrigin = false,
            FirstMessage = true
        });

        for (int i = 0; i < 3; i++)
        {
            Messages.Add(new()
            {
                Username = "Ali",
                UsernameColor = "#409aff",
                ImageSource = "https://thewowstyle.com/wp-content/uploads/2015/01/nature-images..jpg",
                Message = "Test",
                TimeStamp = DateTimeOffset.UtcNow,
                IsNativeOrigin = false,
                FirstMessage = false
            });
        }

        for (int i = 0; i < 4; i++)
        {
            Messages.Add(new()
            {
                Username = "Dab",
                UsernameColor = "#409aff",
                ImageSource = "https://thewowstyle.com/wp-content/uploads/2015/01/nature-images..jpg",
                Message = "Test",
                TimeStamp = DateTimeOffset.UtcNow,
                IsNativeOrigin = true,
            });
        }
        Messages.Add(new()
        {
            Username = "Dab",
            UsernameColor = "#409aff",
            ImageSource = "https://thewowstyle.com/wp-content/uploads/2015/01/nature-images..jpg",
            Message = "Test",
            TimeStamp = DateTimeOffset.UtcNow,
            IsNativeOrigin = true,
        });


        for (int i = 0; i < 5; i++)
        {
            Contacts.Add(new()
            {
                Username = $"Ali {i}",
                ImageSource = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fwww.wallpapers13.com%2Fwp-content%2Fuploads%2F2015%2F12%2FNature-Lake-Bled.-Desktop-background-image.jpg&f=1&nofb=1&ipt=5e619333ede65da4a8b41683edee6b76d81f26536f1ee0642c0f2ae68db7adcb&ipo=images",
                Messages = Messages
            });
        }
    }

}
