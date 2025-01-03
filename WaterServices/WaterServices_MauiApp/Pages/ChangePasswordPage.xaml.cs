using WaterServices_MauiApp.Services;
using WaterServices_MauiApp.Validations;

namespace WaterServices_MauiApp.Pages;

public partial class ChangePasswordPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly IValidator _validator;
    private bool _loginPageDisplayed = false;

    public ChangePasswordPage(ApiService apiService, IValidator validator)
    {
        InitializeComponent();
        _apiService = apiService;
        _validator = validator;
    }

    private async void changePassword_button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(oldPassword_entry.Text))
        {
            await DisplayAlert("Error", "Old password is required.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(newPassword_entry.Text))
        {
            await DisplayAlert("Error", "New password is required.", "OK");
            return;
        }

        if (string.IsNullOrEmpty(confirmNewPassword_entry.Text))
        {
            await DisplayAlert("Error", "Confirm new password is required.", "OK");
            return;
        }

        var response = await _apiService.ChangePassword(oldPassword_entry.Text, newPassword_entry.Text, confirmNewPassword_entry.Text);
        if (!response.HasError)
        {
            await DisplayAlert("Success", "Password successfully updated.", "OK");
            oldPassword_entry.Text = null;
            newPassword_entry.Text = null;
            confirmNewPassword_entry.Text = null;
        }
        else
        {
            await DisplayAlert("Error", "Could not update password.", "OK");
            oldPassword_entry.Text = null;
            newPassword_entry.Text = null;
            confirmNewPassword_entry.Text = null;
        }
    }
}