
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiPeopleApp.Views;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace MauiPeopleApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task LoginWithFingerprint()
        {
            var isAvailable = false;
            try
            {
                isAvailable = await CrossFingerprint.Current.IsAvailableAsync(allowAlternativeAuthentication:true);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.ToString(), "OK");
            }
            
            if (!isAvailable)
            {
                await Shell.Current.DisplayAlert("Error", "Biometric authentication not available.", "OK");
                return;
            }

            var result = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Authentication", "Authenticate to continue")
            {
                CancelTitle = "Cancel",
                FallbackTitle = "Use PIN"
            });

            if (result.Authenticated)
            {
                await Shell.Current.GoToAsync(nameof(PersonListPage));
            }
            else
            {
                await Shell.Current.DisplayAlert("Failed", "Authentication failed.", "OK");
            }
        }
    }
}