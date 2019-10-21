using System;
using System.Collections.Generic;
using OpenShelter.Models;
using OpenShelter.Services;
using Xamarin.Forms;

namespace OpenShelter.Views
{
    public partial class ViewAttendancePage : ContentPage
    {
        private readonly IVolunterRepository volunterRepository;
        private readonly IAttendanceRepository attendanceRepository;

        public ViewAttendancePage(Attendance attendance)
        {

            this.volunterRepository = DependencyService.Get<IVolunterRepository>();
            this.attendanceRepository = DependencyService.Get<IAttendanceRepository>();

            InitializeComponent();

            this.lblName.Text = attendance.Name;
            this.lblTaskType.Text = attendance.TaskType;
            this.lblEnterTime.Text = attendance.EnterTime.ToString();
            this.lblId.Text = attendance.Id.ToString();
        }

        async void OnEndAttendanceClick(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(this.lblId.Text);

            var attendance = this.attendanceRepository.Get(a => a.Id == id);

            if (attendance != null)
            {
                attendance.ExitTime = DateTime.Now;
                this.attendanceRepository.Update(attendance);
            }

            await Navigation.PopAsync();
        }

        async void OnBackClick(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
