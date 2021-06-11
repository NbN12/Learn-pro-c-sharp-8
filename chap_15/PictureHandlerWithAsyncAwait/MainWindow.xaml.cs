using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace PictureHandlerWithAsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CancellationTokenSource _cancelToken = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            _cancelToken.Cancel();
        }

        private async void cmdProcess_Click(object sender, RoutedEventArgs e)
        {
            _cancelToken = new CancellationTokenSource();
            var basePath = @"..\..\..\";
            var pictureDirectory = Path.Combine(@"..\..\..\..\DataParallelismWithForEach", "TestPictures");
            var outputDirectory = Path.Combine(basePath, "ModifiedPictures");
            Directory.CreateDirectory(outputDirectory);
            string[] files = Directory.GetFiles(pictureDirectory, "*.jpg", SearchOption.AllDirectories);
            try
            {
                foreach(string file in files)
                {
                    try
                    {
                        await ProcessFile(file, outputDirectory, _cancelToken);
                    }
                    catch (OperationCanceledException ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            Title = "Processing complete";

        }

        private async Task ProcessFile(string currentFile, string outputDirectory, CancellationTokenSource cancelToken)
        {
            string filename = Path.GetFileName(currentFile);
            using (Bitmap bitmap = new Bitmap(currentFile))
            {
                try
                {
                    await Task.Run(() => 
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(
                        Path.Combine(outputDirectory, filename));
                        Dispatcher?.Invoke(() =>
                        {
                            Title = $"Processing {filename}";
                        });
                    }, cancelToken.Token);
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }
    }
}
