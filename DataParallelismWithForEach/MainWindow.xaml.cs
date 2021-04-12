using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // Код метода будет вскоре обновлен.
        }
        private void cmdProcess_Click(object sender, EventArgs e)
        {
            ProcessFiles();
        }
        private void ProcessFiles()
        {
            // Загрузить все файлы *.jpg и создать новый каталог 
            // для модифицированных данных.
            string[] files = Directory.GetFiles(@".\TestPictures", ".jpg",
            SearchOption.AllDirectories);
            string newDir = "ModifledPictures";
            Directory.CreateDirectory(newDir);
            // Обработать данные изображений в блокирующей манере.
            foreach (string currentFile in files)
            {
                string filename = System.IO.Path.GetFileName(currentFile);
                using (Bitmap bitmap = new Bitmap(currentFile))
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(System.IO.Path.Combine(newDir, filename));
                    // Вывести идентификатор потока, обрабатывающего текущее изображение, 
                    this.Title = $"Processing { filename } on thread { Thread.CurrentThread.ManagedThreadId}"; 
                }
            }
        }


    }
}
