using System;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Wmt
{
    public class StationDetailPage : ContentPage
    {
        private readonly Station _station;


        public StationDetailPage(Station station)
        {
            this._station = station;
            Title = "Details";

            var detailLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical

            };

   
            detailLayout.Children.Add(new Label{
                HeightRequest = 32,
                Text = string.Format("{0}",station.Name)
            });



            this.Content = detailLayout;
        }

        protected async override void OnAppearing()
        {
            var location = await GetDetails();

            _station.Location = location;

           
        }

        protected async Task<Location> GetDetails() {
            var response = await new MtaService().GetStationLocation(_station);

            return response;
        }


    }
}

