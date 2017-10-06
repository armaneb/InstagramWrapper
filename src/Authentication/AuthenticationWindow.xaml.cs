using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

namespace InstagramWrapper.Authentication
{
    /// <summary>
    /// Interaction logic for AuthenticationWindow.xaml
    /// </summary>
    partial class AuthenticationWindow : Window
    {
        public string AccessToken { get; private set; }

        private AuthenticationService _Authentication;

        public AuthenticationWindow(AuthenticationService authentication)
        {
            InitializeComponent();

            _Authentication = authentication;

            webBrowser.Source = _Authentication.AuthenticationApiUri();
        }

        private void WebBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            pbLoading.Visibility = Visibility.Visible;
        }

        private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            pbLoading.Visibility = Visibility.Hidden;

            if (_Authentication.IsRedirectedToMyRedirectUri(e.Uri))
            {
                try
                {
                    AccessToken = _Authentication.GetAccessTokenFromRedirectUri(e.Uri);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    this.CloseDialogWithEffect();
                }
            }
        }

        public void ShowDialogWithEffect()
        {
            var colorAnimation = new ColorAnimation(Colors.Gray, new Duration(TimeSpan.FromMilliseconds(600)));
            Owner.Background = new SolidColorBrush(Colors.White);
            Owner.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            this.ShowDialog();
        }
        public void CloseDialogWithEffect()
        {
            var colorAnimation = new ColorAnimation(Colors.White, new Duration(TimeSpan.FromMilliseconds(400)));
            Owner.Background = new SolidColorBrush(Colors.Gray);
            Owner.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            this.Close();
        }
    }
}
