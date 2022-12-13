using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DemoCorso.Models;

public class DemoCustomer : INotifyPropertyChanged, IEditableObject
{
    private DemoCustomer? tempCustomer = null;
    private Guid idValue = Guid.NewGuid();
    public Guid Id { get { return idValue; } set { } }

    private string name = string.Empty;
    public string Name { 
        get {
            return name; } 
        set
        {
            if (value != name )
            {
                name = value;
                // Qui dobbiamo notificare il cambio del valore
                NotifyPropertyChanged();
                NotifyPropertyChanged("FullName");
            }
        }
    }

    private string phoneNumber = string.Empty;
    public string PhoneNumber
    {
        get { return phoneNumber; }

        set
        {
            if( value != phoneNumber )
            {
                phoneNumber = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("FullName");
            }
        }
    }

    public string FullName
    {
        get
        {
            return $"{Name} - {PhoneNumber}";
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    // This method is called by the Set accessor of each property.  
    // The CallerMemberName attribute that is applied to the optional
    // propertyName parameter causes the property name of the caller
    // to be substituted as an argument. 
    private void NotifyPropertyChanged([CallerMemberName] 
    string propertyName = "")
    {
        PropertyChanged?.Invoke( this, 
            new PropertyChangedEventArgs( propertyName ) );
    }

    public void BeginEdit()
    {
        tempCustomer = new DemoCustomer
        {
            Id = Id,
            Name = Name,
            PhoneNumber = PhoneNumber
        };
    }

    public void CancelEdit()
    {
        if(tempCustomer != null)
        {
            Id = tempCustomer.Id;
            Name = tempCustomer.Name;
            PhoneNumber = tempCustomer.PhoneNumber;
        }

    }

    public void EndEdit()
    {
        tempCustomer = null;
    }
}
