using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using LordoftheRingsSounds.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.BackgroundAudio;

namespace LordoftheRingsSounds
{
    public partial class MainPage
    {

        readonly SaveRingtoneTask _customRingtone;
        private bool _saveRingtone;
        readonly Popup _myPopup = new Popup();

        public MainPage()
        {
            InitializeComponent();
            _customRingtone = new SaveRingtoneTask();
            _customRingtone.Completed += (customRingtone_Completed);
            DataContext = App.ViewModel;
            BackgroundAudioPlayer.Instance.PlayStateChanged += new EventHandler(Instance_PlayStateChanged);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.Loaded)
            {
                App.ViewModel.Load();
            }
        }

        private void ApplicationBarIconButton_OnClick(object sender, EventArgs e)
        {
            var emailComposeTask = new EmailComposeTask
            {
                To = "haskkor@gmail.com",
                Subject = "LOTR SoundBoard Suggestions"
            };
            emailComposeTask.Show();
        }

        private void ApplicationBarReviewIconButton_OnClick(object sender, EventArgs e)
        {
            var marketPlaceReviewTask = new MarketplaceReviewTask();
            marketPlaceReviewTask.Show();
        }

        private void ApplicationBarSaveIconButton_OnClick(object sender, EventArgs e)
        {
            var border = new Border
            {
                BorderBrush = new SolidColorBrush(Colors.LightGray),
                BorderThickness = new Thickness(2),
                Margin = new Thickness(10, 10, 10, 10)
            };

            var sktPnlOutter = new StackPanel
            {
                Background = new SolidColorBrush(Colors.Black),
                Orientation = System.Windows.Controls.Orientation.Vertical
            };

            var txtBlk = new TextBlock
            {
                Text = "Choose a ringtone.",
                TextAlignment = TextAlignment.Center,
                FontSize = 32,
                Margin = new Thickness(10, 0, 10, 0),
                Foreground = new SolidColorBrush(Colors.LightGray)
            };

            sktPnlOutter.Children.Add(txtBlk);

            var sktPnlInner = new StackPanel { Orientation = System.Windows.Controls.Orientation.Horizontal };

            var btnContinue = new Image();
            var uriR = new Uri("Assets/Images/Check.png", UriKind.RelativeOrAbsolute);
            var imgSourceR = new BitmapImage(uriR);
            btnContinue.Source = imgSourceR;
            btnContinue.Stretch = Stretch.Fill;
            btnContinue.Width = 70;
            btnContinue.Height = 70;
            btnContinue.Margin = new Thickness(50, 0, 0, 0);
            btnContinue.Tap += (btn_continue_Click);

            var btnCancel = new Image();
            var uriR1 = new Uri("Assets/Images/Cancel.png", UriKind.RelativeOrAbsolute);
            var imgSourceR1 = new BitmapImage(uriR1);
            btnCancel.Source = imgSourceR1;
            btnCancel.Stretch = Stretch.Fill;
            btnCancel.Width = 70;
            btnCancel.Height = 70;
            btnCancel.Margin = new Thickness(30, 0, 0, 0);
            btnCancel.Tap += (btn_cancel_Click);

            sktPnlInner.Children.Add(btnContinue);
            sktPnlInner.Children.Add(btnCancel);

            sktPnlOutter.Children.Add(sktPnlInner);
            border.Child = sktPnlOutter;
            _myPopup.Child = border;

            _myPopup.VerticalOffset = 300;
            _myPopup.HorizontalOffset = 80;

            _myPopup.IsOpen = true;
        }

        private void LongListSelector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_saveRingtone)
            {
                var selector = sender as LongListSelector;

                if (selector == null)
                {
                    return;
                }
                var sound = selector.SelectedItem as Sounds;
                if (DataContext == null)
                {
                    return;
                }
                if (sound != null)
                {
                    AudioPlayer.Source = new Uri(sound.Path, UriKind.RelativeOrAbsolute);
                }
                selector.SelectedItem = null;
            }
            else
            {
                var selector = sender as LongListSelector;

                if (selector == null)
                {
                    return;
                }
                var sound = selector.SelectedItem as Sounds;
                if (DataContext == null)
                {
                    return;
                }
                if (sound == null) return;
                var uri = "appdata:/" + sound.Path;
                _saveRingtone = false;
                _customRingtone.Source = new Uri(uri);
                _customRingtone.DisplayName = sound.Title;
                _customRingtone.Show();
            }
        }

        static void customRingtone_Completed(object sender, TaskEventArgs e)
        {
            switch (e.TaskResult)
            {
                case TaskResult.OK:
                    MessageBox.Show("The ringtone was set successfully.");
                    break;
                case TaskResult.Cancel:
                    break;
                case TaskResult.None:
                    break;
            }
        }

        private void btn_continue_Click(object sender, RoutedEventArgs e)
        {
            if (!_myPopup.IsOpen) return;
            _myPopup.IsOpen = false;
            _saveRingtone = true;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (!_myPopup.IsOpen) return;
            _myPopup.IsOpen = false;
            _saveRingtone = false;
        }

        private void ApplicationBarPlayIconButton_OnClick(object sender, EventArgs e)
        {
            App.CopyToIsolatedStorage();
            BackgroundAudioPlayer.Instance.Play();
        }

        void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            switch (BackgroundAudioPlayer.Instance.PlayerState)
            {
                case PlayState.Playing:
                    if (PlayButton != null)
                    {
                        PlayButton.Text = "Pause";
                    }
                    break;

                case PlayState.Paused:
                case PlayState.Stopped:
                    if (PlayButton != null)
                    {
                        PlayButton.Text = "Play";                        
                    }
                    break;
            }
        }
    }
}