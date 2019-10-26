using System;
using System.Collections.ObjectModel;
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
        private readonly IAttendanceRepository attendanceRepository;

        public MainPage()
        {
            InitializeComponent();

            this.attendanceRepository = DependencyService.Get<IAttendanceRepository>();
        }

        async void OnAddAttendancePageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAttendancePage());
        }

        async void OnAdminPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminLoginPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.RefreshList();

            this.RefreshListExit();
        }

        private void RefreshList()
        {
            var dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 59, 59);

            var attendances = this.attendanceRepository.GetAll(v => v.EnterTime >= dt && v.ExitTime == default);

            this.lvAttendances.ItemsSource = new ObservableCollection<Attendance>(attendances);
        }

        private void RefreshListExit()
        {
            var dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 59, 59);

            var exits = this.attendanceRepository.GetAll(v => v.ExitTime != default && v.ExitTime >= dt);

            this.lvAttendancesExit.ItemsSource = new ObservableCollection<Attendance>(exits);
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myListView = (ListView)sender;
            var attendance = (Attendance)myListView.SelectedItem;

            await Navigation.PushAsync(new ViewAttendancePage(attendance), true);
        }
    }
}
