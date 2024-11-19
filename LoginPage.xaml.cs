using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QuestionApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
  
        public sealed partial class LoginPage : Page
        {
            // Hardcoded user data for simplicity
            private string registeredUsername = "user123";
            private string registeredPassword = "password123";

            public LoginPage()
            {
                this.InitializeComponent();
            }

            // Handle Login Button Click
            private void LoginButton_Click(object sender, RoutedEventArgs e)
            {
                string username = usernameBox.Text;
                string password = passwordBox.Password;

                if (username == registeredUsername && password == registeredPassword)
                {
                    // Navigate to MainPage (Quiz)
                    this.Frame.Navigate(typeof(MainPage));
                }
                else
                {
                    // Show an error message if the credentials are incorrect
                    var dialog = new Windows.UI.Popups.MessageDialog("Invalid credentials. Please try again.");
                IAsyncOperation<Windows.UI.Popups.IUICommand> asyncOperation = dialog.ShowAsync();

            }
            }

            // Navigate to Signup page
            private void SignUpLink_Click(object sender, RoutedEventArgs e)
            {
                this.Frame.Navigate(typeof(SignUpPage));
            }
        }
    }
