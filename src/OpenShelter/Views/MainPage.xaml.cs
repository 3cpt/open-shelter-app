using System;
using System.Collections.Generic;
using System.ComponentModel;
using OpenShelter.Models;
using OpenShelter.Views;
using Xamarin.Forms;

namespace OpenShelter
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public IList<Attendance> Attendances { get; private set; }

        public MainPage()
        {
            InitializeComponent();

        }

        async void OnAddAttendancePageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddAttendancePage());
        }

        async void OnAdminPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminLoginPage());
        }
    }
}
