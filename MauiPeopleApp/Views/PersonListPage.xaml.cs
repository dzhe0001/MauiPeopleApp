using MauiPeopleApp.Models;
using MauiPeopleApp.ViewModels;

namespace MauiPeopleApp.Views;

public partial class PersonListPage : ContentPage
{
    private PersonListViewModel ViewModel => BindingContext as PersonListViewModel;

    public PersonListPage()
    {
        InitializeComponent();
        BindingContext = new PersonListViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (ViewModel.People.Count == 0)
            ViewModel.LoadPeopleCommand.Execute(null);
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection?.FirstOrDefault() is Person person)
        {
            ((CollectionView)sender).SelectedItem = null; // de-select to allow re-tap
            await Shell.Current.GoToAsync(nameof(PersonDetailPage), new Dictionary<string, object>
            {
                { "Person", person }
            });
        }
    }
}
