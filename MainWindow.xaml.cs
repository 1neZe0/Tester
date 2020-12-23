using System.Diagnostics;
using System.Windows;
using Microsoft.Win32;

namespace Tester_prog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repositiory rep;
        public MainWindow()
        {
            rep = new Repositiory();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfileddialog = new OpenFileDialog();

            if (openfileddialog.ShowDialog() == true)
                rep.Download(openfileddialog.FileName);
            Debug.WriteLine(openfileddialog.FileName.ToString());
            Refresh();
        }

        public void Refresh()
        {
            TotalQuestions.Text = rep.Questions_Rest();
            GoodAsks.Text = rep.Correct_Answers();

            Question.Text = rep.question;
            Answer1.Content = rep.answers[0];
            Answer2.Content = rep.answers[1];
            Answer3.Content = rep.answers[2];
            Answer4.Content = rep.answers[3];
        }

        private void Ask1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rep.Click(Answer1.Content.ToString());
                Refresh();
            }
            catch
            {
                MessageBox.Show("Upload new test");
            }
        }

        private void Ask2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rep.Click(Answer2.Content.ToString());
                Refresh();
            }
            catch
            {
                MessageBox.Show("Upload new test");
            }
        }

        private void Ask3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rep.Click(Answer3.Content.ToString());
                Refresh();
            }
            catch
            {
                MessageBox.Show("Upload new test");
            }
        }

        private void Ask4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rep.Click(Answer4.Content.ToString());
                Refresh();
            }
            catch
            {
                MessageBox.Show("Upload new test");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rep.Download("Words.txt");
            Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            rep.Download("Abbreviatures.txt");
            Refresh();
        }
    }
}
