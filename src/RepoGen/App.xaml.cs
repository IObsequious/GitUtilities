using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RepoGen
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            RepositoryInfoManager manager = new RepositoryInfoManager();
            MainWindow = new MainWindow(manager);
            if (MainWindow.ShowDialog() == true)
            {

            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        private void TextBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }
    }
}
