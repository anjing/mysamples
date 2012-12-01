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
using System.Threading.Tasks;


namespace COMP212_Assignments07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int speed = 2400;
        private int aWidth = 0;
        private int aHeight = 0;
        private Random random;

        private Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            aWidth = (int)this.Width;
            aHeight = (int)this.Height;
            timer = new Timer(speed);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MoveBug();
        }

        private void paintCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void btnRestScore_Click(object sender, RoutedEventArgs e)
        {
            this.lblScore.Content = 0;
        }

        private void btnRestSpeed_Click(object sender, RoutedEventArgs e)
        {
            speed = 0;
        }

        private void MoveBug()
        {
            double x = random.Next(aWidth);
            double y = random.Next(aHeight);
            if (x < 10)
                x = 10;
            if (y < 10)
                y = 10;

            paintCanvas.Dispatcher.Invoke((delegate()
            {
                Canvas.SetTop(bug, y);
                Canvas.SetLeft(bug, x);
            });
        }
    }
}
