﻿using System;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicLibaryApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddMusicPage : Page
    {        
        public AddMusicPage()
        {
            this.InitializeComponent();
        }

        private Datastorage _storage;

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save music file path and cover image file path in txt format and show "saved"
            // collect data from controls to music entry here


            var entry = new MusicEntry
            {
                MusicTitle = EnterTitle.Text,
                Singer = EnterSinger.Text,
                Album = EnterAlbum.Text,
                ReleaseDate = EnteryDate.Text,
                ImageFilePath = ImagePathString.Text,
                MusicFilePath = MusicPathString.Text
            };
            if (string.IsNullOrEmpty(entry.MusicTitle) || string.IsNullOrEmpty(entry.ImageFilePath) || string.IsNullOrEmpty(entry.MusicFilePath))
            {
                var dialog = new MessageDialog("Music Title, Image File and Music File are required.");
                dialog.ShowAsync();
                return;
            }
            MusicEntry.WriteMusicEntry(entry);

            _storage.SaveMusic(entry);

            MainPage.MusicEntries.Add(entry);

            this.Frame.Navigate(typeof(MainPage), entry);   // passing parameter to the target page
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary
            };

            //picker.FileTypeFilter.Add(".jpg");

            //picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");
            Windows.Storage.StorageFile imgfile = await picker.PickSingleFileAsync();
            if (imgfile == null)
            {
                return;
            }

            // Get the app's local folder to use as the destination folder.

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            // Copy the file to the destination folder and rename it.


            // Replace the existing file if the file already exists.

            StorageFile copiedImgFile = await imgfile.CopyAsync
                 (localFolder, imgfile.Name, NameCollisionOption.ReplaceExisting);
            if (imgfile != null)
            {
                this.ImagePathString.Text = copiedImgFile.Path;
                this.image.Source = new BitmapImage(new Uri("ms-appx:///" + this.ImagePathString.Text));
            }
            else
            {
                this.ImagePathString.Text = "Operation cancelled";
            }
        }

        private async void AddMusicButton_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary
            };
            picker.FileTypeFilter.Add(".mp3");
            Windows.Storage.StorageFile musicfile = await picker.PickSingleFileAsync();
            // Get the app's local folder to use as the destination folder.
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            // Copy the file to the destination folder and rename it.
            // Replace the existing file if the file already exists.
            StorageFile copiedMusicFile = await musicfile.CopyAsync(localFolder, musicfile.Name, NameCollisionOption.ReplaceExisting);
            if (musicfile != null)
            {
                this.MusicPathString.Text = copiedMusicFile.Path;// Save musicfile path in the txt 
            }
            else
            {
                this.MusicPathString.Text = "Operation cancelled";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
