using Rang_Out.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Rang_Out.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        RandomAccessStreamReference mapIconStreamReference;

        public MapPage()
        {
            this.InitializeComponent();

            this.Loaded += MapPage_Loaded;

            Sellers = new ObservableCollection<Seller>()
            {
                new Seller()
                {
                    Name = "João das Neves",
                    LastPosX = -23.482941,
                    LastPosY = -46.500748
                },

                new Seller()
                {
                    Name = "Maria das Dores",
                    LastPosX = -25.482941,
                    LastPosY = -50.500748
                },

                new Seller()
                {
                    Name = "Faustão Silva",
                    LastPosX = -15.482941,
                    LastPosY = -40.500748
                },

                new Seller()
                {
                    Name = "Oswaldo Pires Xícara",
                    LastPosX = -30.482941,
                    LastPosY = -10.500748
                },

            };

            mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/MapPin.png"));
        }

        private void MapPage_Loaded(object sender, RoutedEventArgs e)
        {
            
                myMap.Center =
               new Geopoint(new BasicGeoposition()
               {
                   //Geopoint for EACH 
                   Latitude = -23.482941,
                   Longitude = -46.500748
               });
            myMap.ZoomLevel = 17;

            foreach (var item in Sellers)
            {
                MapIcon mapIcon1 = new MapIcon();
                mapIcon1.Location = myMap.Center;
                mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                mapIcon1.Title = item.Name;
                mapIcon1.Image = mapIconStreamReference;
                mapIcon1.ZIndex = 0;
                myMap.MapElements.Add(mapIcon1);
            }
        }

        private ObservableCollection<Seller> _sellers;

        public ObservableCollection<Seller> Sellers
        {
            get { return _sellers; }
            set { _sellers = value; }
        }

        
    }
}
