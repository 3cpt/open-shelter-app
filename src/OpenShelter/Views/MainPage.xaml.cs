using System;
using System.Collections.Generic;
using System.ComponentModel;
using OpenShelter.Models;
using OpenShelter.Services;
using OpenShelter.Views;
using Xamarin.Forms;

namespace OpenShelter
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private readonly IVolunterRepository volunterRepository;
        private readonly IAttendanceRepository attendanceRepository;

        public IList<Attendance> Attendances { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            this.volunterRepository = DependencyService.Get<IVolunterRepository>();
            this.attendanceRepository = DependencyService.Get<IAttendanceRepository>();

            this.CheckStart();
        }

        async void OnAddAttendancePageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAttendancePage());
        }

        async void OnAdminPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminLoginPage());
        }

        private void CheckStart()
        {
            Attendances = this.attendanceRepository.GetAll(a => a.ExitTime == default && a.EnterTime > DateTime.Now.AddHours(-12));

            EmployeeView.ItemsSource = Attendances;

            if (true)
            {
                volunterRepository.InsertDummyData();
            }
        }
    }
}
