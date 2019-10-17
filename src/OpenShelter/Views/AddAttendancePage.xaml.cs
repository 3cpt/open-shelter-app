using System;
using System.Collections.Generic;
using System.Linq;
using OpenShelter.Models;
using OpenShelter.Services;
using Xamarin.Forms;

namespace OpenShelter.Views
{
    public partial class AddAttendancePage : ContentPage
    {
        private readonly VolunterRepository volunterRepository;
        private readonly TaskTypeRepository taskTypeRepository;
        private readonly AttendanceRepository attendanceRepository;
        private readonly SettingsRepository settingsRepository;

        public AddAttendancePage()
        {
            InitializeComponent();

            var picker = new Picker
            {
                Title = "Selecione um tipo de tarefa",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };


            var taskTypes = this.taskTypeRepository.GetAll(t => true).Select(t => t.Description);

            foreach (var taskType in taskTypes)
            {
                picker.Items.Add(taskType);
            }

            picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;

            this.mainStackLayout.Children.Add(picker);

            this.volunterRepository = DependencyService.Get<VolunterRepository>();
            this.taskTypeRepository = DependencyService.Get<TaskTypeRepository>();
            this.attendanceRepository = DependencyService.Get<AttendanceRepository>();
            this.settingsRepository = DependencyService.Get<SettingsRepository>();
        }

        async void OnAddAttendanceClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtUsername.Text))
            {
                await DisplayAlert("Aviso", "Indique o utilizador", "Ok");
            }
            if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                await DisplayAlert("Aviso", "Indique a palavra-chave", "Ok");
            }
            if (string.IsNullOrWhiteSpace(this.txtSelectedTaskType.Text))
            {
                await DisplayAlert("Aviso", "Selecione o tipo de tarefa", "Ok");
            }

            var volunter = this.volunterRepository.Get(v => v.Username == this.txtUsername.Text.ToLower());

            if (volunter == null)
            {
                await DisplayAlert("Aviso", "Utilizador errado", "Ok");
            }

            if (volunter.AccessCode.ToString() == this.txtPassword.Text)
            {
                await DisplayAlert("Aviso", "Palavra-chave errada", "Ok");
            }


            var attendance = new Attendance
            {

            };

            await Navigation.PushAsync(new AddAttendancePage());
        }


        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                this.txtSelectedTaskType.Text = picker.Items[selectedIndex];
            }
        }
    }
}
