using System;
using System.Collections.Generic;
using OpenShelter.Models;
using OpenShelter.Services;
using Xamarin.Forms;

namespace OpenShelter.Views.Admin
{
    public partial class AdminAddRemoveVolunterPage : ContentPage
    {
        private readonly IVolunterRepository volunterRepository;

        private readonly bool IsNewVolunter;

        public AdminAddRemoveVolunterPage(Volunter volunter = null)
        {
            InitializeComponent();

            this.IsNewVolunter = volunter == null;
            this.volunterRepository = DependencyService.Get<IVolunterRepository>();

            if (volunter != null)
            {
                this.txtName.Text = volunter.Name;
                this.txtPassword.Text = volunter.AccessCode.ToString();
                this.txtUsername.Text = volunter.Username;
                this.cbActive.IsChecked = volunter.Visible;

                this.txtUsername.IsEnabled = !this.IsNewVolunter;
                this.txtName.IsEnabled = !this.IsNewVolunter;
            }
            else
            {
                this.btnRemove.IsEnabled = !this.IsNewVolunter;
            }
        }

        async void OnRemoveVolunterClick(object sender, EventArgs e)
        {
            var volunter = this.volunterRepository.Get(v => v.Username == this.txtUsername.Text.ToLower());

            if (volunter != null)
            {
                volunter.Visible = false;

                this.volunterRepository.Update(volunter);
                await DisplayAlert("SUCESSO", $"Utilizador {volunter.Name} REMOVIDO!", "Ok");
            }

            await Navigation.PopAsync();
        }

        async void OnAddVolunterClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                await DisplayAlert("Aviso", "Indique o Nome", "Ok");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtUsername.Text))
            {
                await DisplayAlert("Aviso", "Indique o utilizador", "Ok");
                return;
            }
            if (this.txtUsername.Text.Contains(" "))
            {
                await DisplayAlert("Aviso", "O nome de utilizador não pode conter espaços", "Ok");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                await DisplayAlert("Aviso", "Indique a palavra-chave", "Ok");
                return;
            }
            if (!int.TryParse(this.txtPassword.Text, out var result))
            {
                await DisplayAlert("Aviso", "A palavra-chave apenas pode conter numeros", "Ok");
                return;
            }

            var newVolunter = new Volunter
            {
                Name = this.txtName.Text,
                AccessCode = Convert.ToInt32(this.txtPassword.Text),
                Username = this.txtUsername.Text.ToLower(),
            };

            try
            {
                var volunter = this.volunterRepository.Get(v => v.Username == this.txtUsername.Text.ToLower());

                if (volunter != null)
                {
                    this.volunterRepository.Update(newVolunter);
                    await DisplayAlert("SUCESSO", $"Utilizador {newVolunter.Name} ATUALIZADO!", "Ok");
                }
                else
                {
                    this.volunterRepository.Add(newVolunter);
                    await DisplayAlert("SUCESSO", $"Utilizador {newVolunter.Name} ADICIONADO!", "Ok");
                }

                await Navigation.PopAsync();
            }
            catch (Exception)
            {
                await DisplayAlert("Aviso", "Aconteceu algo inesperado. Contacta quem fez a aplicação.", "Ok");
            }
        }
    }
}