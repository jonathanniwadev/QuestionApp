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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QuestionApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page

    {
        private List<questionbankDb> _questions;
        private int currentquestionindex = 0;
        private int score = 0;

        private DispatcherTimer timer;
        private int timeleft;
        public MainPage()
        {
            this.InitializeComponent();
            loadQuestions();
            SetQuestion();

        }

        private void SetQuestion()
        {
            // Reset RadioButton states
            option1.IsChecked = false;
            option2.IsChecked = false;
            option3.IsChecked = false;
            option4.IsChecked = false;

            if (currentquestionindex < _questions.Count)
            {
                var current = _questions[currentquestionindex];
                Qtntxt.Text = current.Question;
                option1.Content = current.Option1;
                option2.Content = current.Option2;
                option3.Content = current.Option3;
                option4.Content = current.Option4;

                timeleft = 20; // 20 seconds per question
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            else
            {
                Qtntxt.Text = "Quiz Completed!";
                option1.IsEnabled = false;
                option2.IsEnabled = false;
                option3.IsEnabled = false;
                option4.IsEnabled = false;
                txtscore.Text = $"{(score * 100) / _questions.Count}%";
            }
        }
        private void Timer_Tick(object sender, object e)
        {
            timeleft--;
            timerbx.Text = timeleft.ToString();

            if (timeleft <= 0)
            {
                timer.Stop();
                currentquestionindex++;
                SetQuestion();
            }
        }



        private void loadQuestions()
        {
            _questions = new List<questionbankDb>
            {
                new questionbankDb
                {
                    Question = "What is the capital of Uganda?",
                    Option1 = "Kampala",
                    Option2 = "Nairobi",
                    Option3 = "Dodoma",
                    Option4 = "Kigali",
                    CorrectAnswer = 0
                },
                new questionbankDb
                {
                    Question = "What is the cpital of Kenya?",
                    Option1 = "Kampala",
                    Option2 = "Nairobi",
                    Option3 = "Dodoma",
                    Option4 = "Kigali",
                    CorrectAnswer = 2

                },
                new questionbankDb
                {
                    Question = "What is the capital of Tanzania?",
                    Option1 = "Kampala",
                    Option2 = "Nairobi",
                    Option3 = "Dodoma",
                    Option4 = "Kigali",
                    CorrectAnswer = 3
                },
                new questionbankDb
                {
                    Question = "What is the capital of Rwanda?",
                    Option1 = "Kampala",
                    Option2 = "Nairobi",
                    Option3 = "Dodoma",
                    Option4 = "Kigali",
                    CorrectAnswer = 4
                },
                new questionbankDb
                {
                    Question = "What is the largest city in Africa?'",
                    Option1 = "Kampala",
                    Option2 = "Nairobi",
                    Option3 = "Ciro",
                    Option4 = "Kinshasa"

                },
                new questionbankDb
                {
                    Question = "What is the capital of South Africa?",
                    Option1 = "Kampala",
                    Option2 = "Nairobi",
                    Option3 = "Pretoria",
                    Option4 = "Kigali"
                },
                new questionbankDb
                {
                    Question = "What is the capital of Nigeria?",
                    Option1 = "Kampala",
                    Option2 = "Nairobi",
                    Option3 = "Abuja",
                    Option4 = "Kigali"
                },
                new questionbankDb
                {
                    Question = "What is the capital of Ghana?",
                    Option1 = "Kampala",
                    Option2 = "Nairobi",
                    Option3 = "Dodoma",
                    Option4 = "Accra"
                },
                new questionbankDb
                {
                    Question = "What is the capital of Egypt?",
                    Option1 = "Kampala",
                    Option2 = "Cairo",
                    Option3 = "Dodoma",
                    Option4 = "Kigali"
                },
           

            };
        }

        private void submitbtn_Click(object sender, RoutedEventArgs e)
        {
            if (!option1.IsChecked.HasValue && !option2.IsChecked.HasValue &&
                !option3.IsChecked.HasValue && !option4.IsChecked.HasValue)
            {
                txtresult.Text = "Please select an answer.";
                return;
            }

            if (currentquestionindex < 0 || currentquestionindex >= _questions.Count)
            {
                txtresult.Text = "No more questions available.";
                return;
            }

            var current = _questions[currentquestionindex];
            int selectedAnswer = option1.IsChecked == true ? 1 :
                                 option2.IsChecked == true ? 2 :
                                 option3.IsChecked == true ? 3 : 4;

            if (selectedAnswer == current.CorrectAnswer)
            {
                score++;
                txtresult.Text = "Correct!";
            }
            else
            {
                txtresult.Text = "Wrong!";
            }

            timer.Stop();
            currentquestionindex++;
            SetQuestion();
        }


    }
}
