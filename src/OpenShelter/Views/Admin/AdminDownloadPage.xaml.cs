using System;
using System.Collections.Generic;
using OpenShelter.Services;
using Xamarin.Forms;

namespace OpenShelter.Views.Admin
{
    public partial class AdminDownloadPage : ContentPage
    {
        private readonly IAttendanceRepository attendanceRepository;

        public AdminDownloadPage()
        {
            InitializeComponent();
            this.attendanceRepository = DependencyService.Get<IAttendanceRepository>();
        }
    }
}
