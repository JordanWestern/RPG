using System;
using Terminal.Gui;
using System.Collections.Generic;

namespace RPG.Console.Windows
{
    public class MapWindow : FrameView
    {
        private readonly Map map;
        private ListView listView;

        public MapWindow(Map map) : base("Map")
        {
            this.map = map;

            // Generate the map visualization
            GenerateMapVisualization();
        }

        private void GenerateMapVisualization()
        {
            // Clear existing content
            Clear();

            // Create a ListView with columns
            listView = new ListView(new List<string> { "Location", "Description", "Connections" })
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };

            // Add each location in the map to the ListView
            foreach (var location in map.Locations)
            {
                // Create a list view item for the location
                var locationItem = new ListViewItem(location.Name, location.Description);

                // Add connections as sub-items to the location item
                foreach (var connectionId in location.Connections)
                {
                    var connectedLocation = map.Locations.Find(loc => loc.Id == connectionId);
                    if (connectedLocation != null)
                    {
                        // Add a sub-item for the connected location
                        locationItem.SubItems.Add($"{connectedLocation.Name} - {connectedLocation.Description}");
                    }
                }

                // Add the location item to the ListView
                listView.AddItem(locationItem);
            }

            // Add the ListView to the map frame view
            Add(listView);
        }

        private void Clear()
        {
            // Remove the ListView from the map frame view
            if (listView != null)
            {
                Remove(listView);
                listView = null;
            }
        }
    }
}
