using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WPFtest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void InputSubmit_Click(object sender, RoutedEventArgs e)
        {
            string characterName = sender == inputSubmit ? characterInput.Text : compareCharacterInput.Text;

            if (string.IsNullOrWhiteSpace(characterName))
            {
                MessageBox.Show("Please enter a character name.");
                return;
            }

            try
            {
                ApiService apiService = new();
                Mplus characterInfo = await apiService.GetMplusInfo(characterName);
                UpdateCharacterInfo(sender, characterInfo);
            }
            catch
            {
                MessageBox.Show($"Cannot find player: {characterName}");
            }
        }

        private void UpdateCharacterInfo(object sender, Mplus characterInfo)
        {
            try
            {
                if (sender == inputSubmit)
                {
                    characterName.Content = $"Name: {characterInfo.Name}";
                    characterScore.Content = $"Mplus Rating: {characterInfo.MplusRating}";
                    characterSpec.Content = $"Spec: {characterInfo.Spec}";
                    characterImage.Source = LoadImage(characterInfo.Photo);
                }
                else
                {
                    compareCharacterName.Content = $"Name: {characterInfo.Name}";
                    compareCharacterScore.Content = $"Mplus Rating: {characterInfo.MplusRating}";
                    compareCharacterSpec.Content = $"Spec: {characterInfo.Spec}";
                    compareCharacterImage.Source = LoadImage(characterInfo.Photo);
                }
            }
            catch
            {
                MessageBox.Show("Error occurred while updating the character information.");
            }
        }

        private static BitmapImage LoadImage(string imageUrl)
        {
            BitmapImage bitmap = new();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imageUrl, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            return bitmap;
        }
    }
}
