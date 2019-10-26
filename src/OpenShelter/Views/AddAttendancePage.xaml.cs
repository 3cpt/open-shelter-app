using System;
using OpenShelter.Models;
using OpenShelter.Services;
using Xamarin.Forms;

namespace OpenShelter.Views
{
    public partial class AddAttendancePage : ContentPage
    {
        private readonly IVolunterRepository volunterRepository;
        private readonly IAttendanceRepository attendanceRepository;

        public AddAttendancePage()
        {
            InitializeComponent();

            this.volunterRepository = DependencyService.Get<IVolunterRepository>();
            this.attendanceRepository = DependencyService.Get<IAttendanceRepository>();
        }

        async void OnAddAttendanceClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtUsername.Text))
            {
                await DisplayAlert("Aviso", "Indique o utilizador", "Ok");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                await DisplayAlert("Aviso", "Indique a palavra-chave", "Ok");
                return;
            }

            var volunter = this.volunterRepository.Get(v => v.Username == this.txtUsername.Text.ToLower());

            if (volunter == null)
            {
                await DisplayAlert("Aviso", "Utilizador não encontrado", "Ok");
                return;
            }

            if (!volunter.Visible)
            {
                await DisplayAlert("Aviso", "Utilizador inativo", "Ok");
                return;
            }

            if (volunter.AccessCode.ToString() != this.txtPassword.Text)
            {
                await DisplayAlert("Aviso", "Palavra-chave errada", "Ok");
                return;
            }

            var taskTypePicker = pickerTaskType.SelectedItem;

            if (taskTypePicker == null)
            {
                await DisplayAlert("Aviso", "Selecione o tipo de tarefa", "Ok");
                return;
            }

            var attendance = new Attendance
            {
                EnterTime = DateTime.Now,
                Name = volunter.Name,
                TaskType = taskTypePicker.ToString(),
                VolunterId = volunter.Id,
            };

            try
            {
                this.attendanceRepository.Add(attendance);
                await DisplayAlert("SUCESSO", $"Olá {volunter.Name}. Entrada registada com sucesso, os gatinhos agradecem!", "Ok");
                await Navigation.PopAsync();
            }
            catch (Exception)
            {
                await DisplayAlert("Aviso", "Aconteceu algo inesperado. Contacta quem fez a aplicação.", "Ok");
            }
        }
    }
}
