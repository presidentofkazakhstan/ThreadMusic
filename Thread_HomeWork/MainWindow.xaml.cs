using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Thread_HomeWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread musicThread;

        public MainWindow()
        {
            InitializeComponent();

            musicThread = new Thread(Music)
            {
                IsBackground = true
            };
            musicThread.Start();

        }

        public void SaveText()
        {
            using (var streamFile = new StreamWriter("text.txt"))
            {
                streamFile.WriteLine(textBox.Text);
            }
        }

        public void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            SaveText();
            Process.Start("text.txt");
            Close();
        }

        public void Music()
        {
            var player = new MediaPlayer();
            player.Open(new Uri("music.mp3", UriKind.RelativeOrAbsolute));
            
            player.Play();

           
        }
    }
}
