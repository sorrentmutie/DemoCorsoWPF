using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;

namespace DemoCorso.Models;

public class Customer: INotifyPropertyChanged, IEditableObject
{
    public Guid Id { get;  set; }
    private Customer? TempCustomer = null;

	//public string? Name { get; set; }
	private string name = string.Empty;
	public string Name
	{
		get { return name; }
		set {
			if(value != name)
			{
				name = value;
				NotifyPropertyChanged();
                NotifyPropertyChanged("FullName");
			}
		}
	}

    // public string? Surname { get; set; }
    private string surname = string.Empty;
    public string Surname
    {
        get { return surname; }
        set
        {
            if (value != surname)
            {
                surname = value;
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
            if (value != phoneNumber)
            {
                phoneNumber = value;
                NotifyPropertyChanged();
            }
        }
    }

    public string FullName
    {
        get {
            return $"{Name} - {Surname}";
        }
    }



    public Customer()
	{
		Id = Guid.NewGuid();
	}

    public event PropertyChangedEventHandler? PropertyChanged;

	private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

    public void BeginEdit()
    {
        TempCustomer = new Customer()
        {
            Id = Id,
            Name = Name,
            Surname = Surname
        };
    }

    public void CancelEdit()
    {
        if(TempCustomer!= null)
        {
            Id = TempCustomer.Id;
            Name = TempCustomer.Name;
            Surname= TempCustomer.Surname;
        }
    }

    public void EndEdit()
    {
        TempCustomer = null;
    }
}
