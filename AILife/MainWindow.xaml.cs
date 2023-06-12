using AILife.LIfes;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using OpenCvSharp.WpfExtensions;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AILife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        WriteableBitmap screen = new WriteableBitmap(World.横幅, World.縦幅, 96, 96, PixelFormats.Bgr24, null);
        Mat mat = new Mat(World.横幅, World.縦幅, MatType.CV_8UC3);

        Thread thread;

        public MainWindow()
        {
            InitializeComponent();
            Screen.Source = screen;
            World.instance.初期化();

        }

        

        private void DrawImage(Mat mat)
        {
           WriteableBitmapConverter.ToWriteableBitmap(mat, screen);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            thread = new Thread(() =>
            {
                while (true)
                {

                    World.instance.時間();
                    World.instance.描画(mat);
                    this.Dispatcher.Invoke(() => DrawImage(mat));
                    World.instance.後時間();

                    Thread.Sleep(100);

                }
            });
            thread.Start();
            
        }
    }
}
