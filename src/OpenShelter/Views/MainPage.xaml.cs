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
        private readonly IVolunterRepository volunterRepository;
        private readonly IAttendanceRepository attendanceRepository;

        public ObservableCollection<Attendance> Attendances { get; set; }


        public MainPage()
        {
            this.volunterRepository = DependencyService.Get<IVolunterRepository>();
            this.attendanceRepository = DependencyService.Get<IAttendanceRepository>();
            InitializeComponent();

            //BindingContext = new AttendanceViewModel();

            this.RefreshList();
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
            base.OnAppearing(); //call your Refersh method

            this.RefreshList();
        }

        private void RefreshList()
        {
            var attendances = this.attendanceRepository.GetAll(v => true);

            Attendances = new ObservableCollection<Attendance>(attendances);

            EmployeeView.ItemsSource = new ObservableCollection<Attendance>(attendances);
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myListView = (ListView)sender;
            var attendance = (Attendance)myListView.SelectedItem;

            await Navigation.PushAsync(new ViewAttendancePage(attendance), true);

        }
    }
}
