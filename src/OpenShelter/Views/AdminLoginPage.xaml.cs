using System;
using OpenShelter.Views.Admin;
using Xamarin.Forms;

namespace OpenShelter.Views
{
    public partial class AdminLoginPage : ContentPage
    {
        public AdminLoginPage()
        {
            InitializeComponent();
        }

        async void OnAdminLoginPageButtonClicked(object sender, EventArgs e)
        {
            if (txtPassword.Text == DateTime.Now.ToString("yyyyMMdd"))
            {
                await Navigation.PushAsync(new AdminMainPage());

            }
            else
            {
                await DisplayAlert("Aviso", "Palavra-chave errada", "Ok");
            }
        }
    }
}
