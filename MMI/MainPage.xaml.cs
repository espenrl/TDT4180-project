using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;

namespace MMI
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void MapLoadingStatusChanged(MapControl map, object args)
        {
            if (map.LoadingStatus != MapLoadingStatus.Loaded) return;
            if (map.Tag != null) return;

            MapControl.SetLocation(map.Children.First(), new Geopoint(new BasicGeoposition { Latitude = 63.349129, Longitude = 10.484762 }));

            var mapPolyline = new MapPolyline
            {
                Path = new Geopath(new List<BasicGeoposition>
                {
                    new BasicGeoposition {Latitude = 63.418336, Longitude = 10.403534},
                    new BasicGeoposition {Latitude = 63.349129, Longitude = 10.484762}
                }),
                StrokeColor = Colors.Black,
                StrokeThickness = 3,
                StrokeDashed = true
            };

            var bbox = GeoboundingBox.TryCompute(mapPolyline.Path.Positions);

            map.MapElements.Add(mapPolyline);
            var r = await map.TrySetViewBoundsAsync(bbox, null, MapAnimationKind.Default);

            map.Tag = true;
        }

        private void ButtonClickGotoList(object sender, RoutedEventArgs e)
        {
            PivotControl.SelectedItem = PivotControl.Items[2];
        }

        private void ButtonClickGotoMap(object sender, RoutedEventArgs e)
        {
            PivotControl.SelectedItem = PivotControl.Items[1];
        }
    }
}