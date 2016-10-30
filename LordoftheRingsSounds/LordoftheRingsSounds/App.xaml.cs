using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LordoftheRingsSounds.Resources;
using LordoftheRingsSounds.ViewModels;
using System.IO.IsolatedStorage;

namespace LordoftheRingsSounds
{
    public partial class App
    {
        private static Models _viewModel;

        public static Models ViewModel
        {
            get
            {
                if (_viewModel != null) return _viewModel;
                _viewModel = new Models();
                _viewModel.Load();
                return _viewModel;
            }
        }

        public static PhoneApplicationFrame RootFrame { get; private set; }

        public App()
        {
            UnhandledException += Application_UnhandledException;
            InitializeComponent();
            InitializePhoneApplication();
            InitializeLanguage();
            if (!Debugger.IsAttached) return;
            Current.Host.Settings.EnableFrameRateCounter = true;
            PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            CopyToIsolatedStorage();
        }

        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            if (!ViewModel.Loaded)
            {
                ViewModel.Load();
            }
        }

        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }

        #region Initialisation de l'application téléphonique

        private bool _phoneApplicationInitialized;

        private void InitializePhoneApplication()
        {
            if (_phoneApplicationInitialized)
                return;

            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;
            RootFrame.Navigated += CheckForResetNavigation;
            _phoneApplicationInitialized = true;
        }

        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Reset)
                RootFrame.Navigated += ClearBackStackAfterReset;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            RootFrame.Navigated -= ClearBackStackAfterReset;
            if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
                return;

            while (RootFrame.RemoveBackEntry() != null)
            {
            }
        }

        #endregion

        private static void InitializeLanguage()
        {
            try
            {
                RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);
                var flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                RootFrame.FlowDirection = flow;
            }
            catch
            {
                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }
                throw;
            }
        }

        public static void CopyToIsolatedStorage()
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                var files = new[] { "ConcerningHobbits.mp3" };

                foreach (var fileName in files)
                {
                    if (storage.FileExists(fileName)) continue;
                    var filePath = "Assets/Sounds/" + fileName;
                    var resource = GetResourceStream(new Uri(filePath, UriKind.Relative));

                    using (var file = storage.CreateFile(fileName))
                    {
                        const int chunkSize = 4096;
                        var bytes = new byte[chunkSize];
                        int byteCount;

                        while ((byteCount = resource.Stream.Read(bytes, 0, chunkSize)) > 0)
                        {
                            file.Write(bytes, 0, byteCount);
                        }
                    }
                }
            }
        }
    }
}