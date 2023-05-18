// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

Console.WriteLine("Hello, World!");

UserVM u = new UserVM();

u.PropertyChanged += U_PropertyChanged;

void U_PropertyChanged(object? sender, PropertyChangedEventArgs e)
{
    Console.WriteLine(e.PropertyName + " was changed to " + ((UserVM)sender).Name);
}

u.Name = "Kevin";
u.Name = "Kevin";
u.Name = "Joe";


class UserVM : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    void handler(object o, PropertyChangedEventArgs a) { 
        //dynamic as event(s) may not be in place
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(a.PropertyName));
    }

    string name = "Hello";

    public string Name { 
        get { return name; }
        set
        {
            name = value;
            handler(this, new PropertyChangedEventArgs("Name"));
        }
        
    }

    public UserVM()
    {

    }

}
