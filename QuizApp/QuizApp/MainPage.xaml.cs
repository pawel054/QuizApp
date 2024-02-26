using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void FinishQuiz()
        {
            double totalTime = times.Sum();
            SaveResult(userNameEntry.Text, totalTime, currentScore);
            DisplayFinalResults(totalTime);
        }

        private async void ViewScoresClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScoresPage());
        }

        private void DisplayFinalResults(double totalTime)
        {
            finishGameView.IsVisible = true;
            gameView.IsVisible = false;
            questionLabel.IsVisible = false;
            answerEntry.IsVisible = false;
            submitAnswerButton.IsVisible = false;
            resultPoints.Text = currentScore.ToString();
            resultTime.Text = totalTime.ToString("F2");
        }

        private void SaveResult(string userName, double totalTime, int score)
        {
            App.Database.SaveResultAsync(new UserResult(userName, totalTime, score));
        }
    }
}
