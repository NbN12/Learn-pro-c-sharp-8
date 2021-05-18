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

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _cancelToken = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            _cancelToken.Cancel();
        }

        private void cmdProcess_Click(object sender, RoutedEventArgs e)
        {
            //ProcessFiles();
            // Start a new "task" to process the files.
            Task.Factory.StartNew(() => ProcessFiles());
            //Can also be written this way
            //Task.Factory.StartNew(ProcessFiles);            
            Title = "Processing Complete";
        }

        private void ProcessFiles()
        {
            // Load up all *.jpg files, and make a new folder for the
            // modified data.
            // Get the directory path where the file is executing
            // var basePath = Directory.GetCurrentDirectory();           
            var basePath = @"..\..\..\";
            var pictureDirectory = Path.Combine(basePath, "TestPictures");
            var outputDirectory = Path.Combine(basePath, "ModifiedPictures");
            Directory.CreateDirectory(outputDirectory);
            string[] files = Directory.GetFiles(pictureDirectory,"*.jpg", SearchOption.AllDirectories);

            // Process the image data in a blocking manner.
            //foreach (string currentFile in files)
            //{
            //    string filename = Path.GetFileName(currentFile);
            //    using (Bitmap bitmap = new Bitmap(currentFile))
            //    {
            //        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitmap.Save(Path.Combine(outputDirectory, filename));
            //        // Print out the ID of the thread processing the current image.
            //        this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
            //    }
            //}

            // Use ParallelOptions instance to store the CancellationToken.
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = _cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            //Parallel.ForEach(files, currentFile =>
            //{
            //    string filename = Path.GetFileName(currentFile);
            //    using (Bitmap bitmap = new Bitmap(currentFile))
            //    {
            //        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitmap.Save(Path.Combine(outputDirectory, filename));
            //        // Print out the ID of the thread processing the current image.
            //        //this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}"; // NOT WORKING !!!!!

            //        // Invoke on the Form object, to allow secondary threads to access controls
            //        // in a thread-safe manner.
            //        Dispatcher?.Invoke(() =>
            //        {
            //            Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
            //        });
            //    }
            //});
            try
            {
                Parallel.ForEach(files, parOpts, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();
                    Thread.Sleep(20000); 
                    string filename = Path.GetFileName(currentFile);
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(outputDirectory, filename));
                        // Print out the ID of the thread processing the current image.
                        //this.Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}"; // NOT WORKING !!!!!

                        // Invoke on the Form object, to allow secondary threads to access controls
                        // in a thread-safe manner.
                        Dispatcher?.Invoke(() =>
                        {
                            Title = $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
                        });
                    }
                });
                Dispatcher?.Invoke(() => Title = "Done!");
            }
            catch (OperationCanceledException ex)
            {
                Dispatcher?.Invoke(() => Title = ex.Message);
            }
        }
    }
}
