using System;
using System.Collections.Generic;
using OpenShelter.Services;
using Xamarin.Forms;

namespace OpenShelter.Views.Admin
{
    public partial class AdminVolunteersPage : ContentPage
    {
        private readonly IVolunterRepository volunterRepository;

        public AdminVolunteersPage()
        {
            InitializeComponent();

            this.volunterRepository = DependencyService.Get<IVolunterRepository>();
        }
    }
}
