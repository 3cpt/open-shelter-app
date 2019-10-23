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
            if (this.txtPassword.Text == DateTime.Now.ToString("yyyyMM"))
            {
                this.txtPassword.Text = string.Empty;

                await Navigation.PushAsync(new AdminMainPage());
            }
            else
            {
                await DisplayAlert("Aviso", "Palavra-chave errada", "Ok");
            }
        }
    }
}
