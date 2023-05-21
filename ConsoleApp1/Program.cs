// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

Console.WriteLine("Hello, World!");

UserViewModel u = new UserViewModel();

u.PropertyChanged += U_PropertyChanged; // add as many events as you need
u.PropertyChanged += U_Celebrate;

//
//NB: We have not discussed how the Model fits in yet. Only View Model and View.
//In XAML MVVM = Extensible Application Markup Language using a Model-View-ViewModel paramdign
//Binding syntax is used to propagate events
//

void U_PropertyChanged(object? sender, PropertyChangedEventArgs e)
{
    Console.WriteLine(e.PropertyName + " was changed to " + ((UserViewModel)sender).Age);
}

void U_Celebrate(object? sender, PropertyChangedEventArgs e)
{
    Console.WriteLine("Hurrah!");
}

u.Age = "45";
u.Age = "46";
u.Age = "46.1";

Console.WriteLine("Finished");
Console.ReadLine();

class UserViewModel : INotifyPropertyChanged // standardization -- once we have it, can be in MVVM apps.
{
    public event PropertyChangedEventHandler? PropertyChanged;

    void handler(object o, PropertyChangedEventArgs a) { 
        //
        // dynamic as event(s) may not be in place - that's why we need question mark
        // do more in depth on events if needed
        //
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(a.PropertyName));
    }

    string age = "0";

    public string Age { 
        get { return age; }
        set
        {
            age = value;
            handler(this, new PropertyChangedEventArgs("Age"));
        }
        
    }

    public UserViewModel()
    {

    }

}
