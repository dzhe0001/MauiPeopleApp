using MauiPeopleApp.Models;
using MauiPeopleApp.ViewModels;

namespace MauiPeopleApp.Views;

[QueryProperty(nameof(Person), nameof(Person))]
public partial class PersonDetailPage : ContentPage
{
    private Person? _person;

    public PersonDetailPage()
    {
        InitializeComponent();
    }

    public Person Person
    {
        get => _person;
        set
        {
            _person = value;
            if (value != null)
            {
                BindingContext = new PersonDetailViewModel(value);
            }
        }
    }
}
