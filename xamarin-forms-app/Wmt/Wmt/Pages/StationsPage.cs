using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Wmt
{
    public class StationsPage : ContentPage
    {
        private readonly ObservableCollection<Station> stationList = new ObservableCollection<Station>();


        private Command fetchCommand;

        /// <summary>
        /// Command to load/refresh items
        /// </summary>
        public Command FetchCommand
        {
            get { return fetchCommand ?? (fetchCommand = new Command(async () => await FetchStations())); }
        }

        public StationsPage()
        {

            Title = "Stations";

            var mainLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };


            var stationListView = new ListView();

            stationListView.ItemsSource = stationList;


            stationListView.ItemSelected += (s, e) =>
            {
                var station = ((Station)stationListView.SelectedItem);
                Navigation.PushAsync(new StationDetailPage(station));
            };

            mainLayout.Children.Add(stationListView);

            this.Content = mainLayout;

        }

        protected  async override void OnAppearing()
        {
            base.OnAppearing();

            await FetchStations();
        }

        private async Task FetchStations()
        {
            var result = await new MtaService().GetStations();

            stationList.Clear();

            foreach (var r in result)
            {
                stationList.Add(r);
            }
        }
    }
}

