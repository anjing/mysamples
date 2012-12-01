using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;


namespace COMP212_Assignments07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int score = 0;
        private int speed = 2400;
        private int aWidth = 0;
        private int aHeight = 0;
        private Random random;

        private Timer timer;


        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            aWidth = (int)this.Width - 74;
            aHeight = (int)this.Height - 95;
            timer = new Timer(speed);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            btnRetScore_Click(this, null);
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MoveBug();
        }

        private void paintCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            DetectHit();
        }

        private void btnRetScore_Click(object sender, RoutedEventArgs e)
        {
            score = 0;
            this.lblScore.Content = score;
        }

        private void btnRestSpeed_Click(object sender, RoutedEventArgs e)
        {
            speed = 2400;
            timer.Interval = speed;            
        }

        private void MoveBug()
        {
            double x = random.Next(aWidth);
            double y = random.Next(aHeight);
            if (x < 10)
                x = 10;
            if (x > aWidth - 50)
                x = aWidth - 50;
            if (y < 10)
                y = 10;
            if (y > aHeight - 10)
                y = aHeight;
            Dispatcher.Invoke(new Action<double, double>(SetPos), x, y);
        }

        private void SetPos(double x, double y)
        {
            Canvas.SetTop(bug, y);
            Canvas.SetLeft(bug, x);
        }

        private void DetectHit()
        {
            score += 1;
            this.lblScore.Content = score;
            speed = speed - 200;
            if (speed <= 200)
                speed = 2400;
            timer.Interval = speed;
            MoveBug();
        }
    }
}
