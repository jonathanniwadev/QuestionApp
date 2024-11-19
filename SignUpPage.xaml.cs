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
    public sealed partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            this.InitializeComponent();
        }

        // Handle Sign Up Button Click
        private async void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string username = newUsernameBox.Text;
            string password = newPasswordBox.Password;
            string confirmPassword = confirmPasswordBox.Password;

            if (password == confirmPassword)
            {
                // You would typically save the user credentials here in a real application
                // For now, we simply show a success message
                var dialog = new Windows.UI.Popups.MessageDialog("Signup successful!");
                await dialog.ShowAsync();

                // Navigate back to the Login page after successful signup
                this.Frame.Navigate(typeof(LoginPage));
            }
            else
            {
                var dialog = new Windows.UI.Popups.MessageDialog("Passwords do not match. Please try again.");
                await dialog.ShowAsync();
            }
        }

        // Navigate to Login page
        private void LoginLink_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }
    }
    }
