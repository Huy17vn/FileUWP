using FileUWP.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FileUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Member currentMenber;

        public MainPage()
        {
            this.currentMenber = new Member();
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            this.currentMenber.useName = this.UseName.Text;
            this.currentMenber.email = this.Email.Text;
            this.currentMenber.phone = this.Phone.Text;

            string jsonMember = JsonConvert.SerializeObject(this.currentMenber);
            
            string useName = UseName.Text;
            string email = Email.Text;
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = "New Document";
            StorageFile File = await savePicker.PickSaveFileAsync();

            await FileIO.WriteTextAsync(File, jsonMember);


        }

        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".txt");
            StorageFile file = await openPicker.PickSingleFileAsync();

            string content = await Windows.Storage.FileIO.ReadTextAsync(file);
            currentMenber = JsonConvert.DeserializeObject<Member>(content);
            UseName.Text = currentMenber.useName;
            Email.Text = currentMenber.email;
            Phone.Text = currentMenber.phone;
        }
    }
}
