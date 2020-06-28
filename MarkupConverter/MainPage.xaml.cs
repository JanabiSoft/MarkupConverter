using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MarkupConverter
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            //for small app window size
            ApplicationView.PreferredLaunchViewSize = new Size(480, 640);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        StorageFolder SourceFolder;
        StorageFolder DestinationFolder;

        private async void BT_Source_Click(object sender, RoutedEventArgs e)
        {
            //select source folder
            FolderPicker picker = new FolderPicker();
            picker.FileTypeFilter.Add(".xaml");
            SourceFolder = await picker.PickSingleFolderAsync();
        }

        private async void BT_Destination_Click(object sender, RoutedEventArgs e)
        {
            // select destination folder
            FolderPicker picker = new FolderPicker();
            picker.FileTypeFilter.Add(".xaml");
            DestinationFolder = await picker.PickSingleFolderAsync();
        }

        private async void BT_Convert_Click(object sender, RoutedEventArgs e)
        {
            //pcik a file from source folder
            PR_Ring.IsActive = true;


            IReadOnlyList<StorageFile> files = await SourceFolder.GetFilesAsync();
            StorageFile file = files.FirstOrDefault();


            string sourceString = await FileIO.ReadTextAsync(file);

            string desString = XamlToHtml.Convert(sourceString);

            string newName = file.Name.Replace(".xaml", ".html");
            StorageFile desFile = await DestinationFolder.CreateFileAsync(newName);
            await FileIO.WriteTextAsync(desFile, desString);
            //start the process
            PR_Ring.IsActive = false;

        }
    }
}
