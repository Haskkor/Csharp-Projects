using System;
using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.BackgroundAudio;

namespace AudioPlaybackAgent1
{
    public class AudioPlayer : AudioPlayerAgent
    {
         private void PlayTrack(BackgroundAudioPlayer player)
        {
            player.Track = new AudioTrack(new Uri("ConcerningHobbits.mp3", UriKind.RelativeOrAbsolute), "Concerning Hobbits", "Howard Shore", "he Lord of the Rings", null);

            player.Play();
            
        }
        
        static AudioPlayer()
        {
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });
        }

        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
            }
        }

        protected override void OnPlayStateChanged(BackgroundAudioPlayer player, AudioTrack track, PlayState playState)
        {
            switch (playState)
            {
                case PlayState.TrackEnded:
                    PlayTrack(player);
                    break;
                case PlayState.TrackReady:
                    PlayTrack(player);
                    break;
                case PlayState.Shutdown:
                    break;
                case PlayState.Unknown:
                    break;
                case PlayState.Stopped:
                    break;
                case PlayState.Paused:
                    break;
                case PlayState.Playing:
                    break;
                case PlayState.BufferingStarted:
                    break;
                case PlayState.BufferingStopped:
                    break;
                case PlayState.Rewinding:
                    break;
                case PlayState.FastForwarding:
                    break;
            }

            NotifyComplete();
        }

        protected override void OnUserAction(BackgroundAudioPlayer player, AudioTrack track, UserAction action, object param)
        {
            switch (action)
            {
                case UserAction.Play:
                    PlayTrack(player);
                    break;
                case UserAction.Stop:
                    player.Stop();
                    break;
                case UserAction.Pause:
                    player.Pause();
                    break;
                case UserAction.FastForward:
                    player.FastForward();
                    break;
                case UserAction.Rewind:
                    player.Rewind();
                    break;
                case UserAction.Seek:
                    player.Position = (TimeSpan)param;
                    break;
                case UserAction.SkipNext:
                    player.Track = GetNextTrack();
                    break;
                case UserAction.SkipPrevious:
                    AudioTrack previousTrack = GetPreviousTrack();
                    if (previousTrack != null)
                    {
                        player.Track = previousTrack;
                    }
                    break;
            }

            NotifyComplete();
        }

        private static AudioTrack GetNextTrack()
        {
            return null;
        }

        private static AudioTrack GetPreviousTrack()
        {
            return null;
        }
        protected override void OnError(BackgroundAudioPlayer player, AudioTrack track, Exception error, bool isFatal)
        {
            if (isFatal)
            {
                Abort();
            }
            else
            {
                NotifyComplete();
            }

        }

        protected override void OnCancel()
        {

        }
    }
}