using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace BasicWpfNotepad
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string filePath = "";

        public MainWindow()
        {
            InitializeComponent();
        }


        // 開啟檔案按鈕
        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 讀取檔案
                TextArea.Text = System.IO.File.ReadAllText(filePath);
            }
        }


        // 存檔檔案按鈕
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生開啟檔案視窗 OpenFileDialog 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 當按下開啟之後的反應 
            if (result == true)
            {
                // 取得檔案路徑 
                filePath = dlg.FileName;

                // 儲存檔案
                System.IO.File.WriteAllText(filePath, TextArea.Text);
            }

        }
        private void SaveAsBtn_Click(object sender, RoutedEventArgs e)
        {
            // 產生儲存檔案視窗 SaveFileDialog
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();


            dlg.Filter = "Text File (*.txt)|*.txt";

            // 顯示視窗
            Nullable<bool> result = dlg.ShowDialog();

            // 按下另存檔後的反應
            if (result == true)
            {
                filePath = dlg.FileName;
                System.IO.File.WriteAllText(dlg.FileName, TextArea.Text);

            }
        }

        // 調整字體大小
        private void Size1_Click(object sender, RoutedEventArgs e)
        {

            TextArea.FontSize = 12;
        }

        private void Size2_Click(object sender, RoutedEventArgs e)
        {

            TextArea.FontSize = 14;
        }

        private void Size3_Click(object sender, RoutedEventArgs e)
        {

            TextArea.FontSize = 20;
        }


        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            // 重置
            filePath = "";
            TextArea.Text = "";
        }
        private void BtnW_Checked(object sender, RoutedEventArgs e)
        {
            // 日間模式
            TextArea.Background = Brushes.White;
            TextArea.Foreground = Brushes.Black;
        }
        private void BtnG_Checked(object sender, RoutedEventArgs e)
        {

            // 夜間模式一
            TextArea.Background = Brushes.DimGray;
            TextArea.Foreground = Brushes.White;

        }

        private void BtnB_Checked(object sender, RoutedEventArgs e)
        {
            // 夜間模式二
            TextArea.Background = Brushes.Black;
            TextArea.Foreground = Brushes.White;
        }

    }
}