using System;
using System.Collections.ObjectModel;
using OpenShelter.Models;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.RefreshList();
        }

        private void RefreshList()
        {
            var volunteers = this.volunterRepository.GetAll(v => v.Visible == true);

            this.lvVolunteers.ItemsSource = new ObservableCollection<Volunter>(volunteers);
        }

        async void OnAddVolunterPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminAddRemoveVolunterPage());
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myListView = (ListView)sender;
            var volunter = (Volunter)myListView.SelectedItem;

            await Navigation.PushAsync(new AdminAddRemoveVolunterPage(volunter), true);
        }
    }
}
