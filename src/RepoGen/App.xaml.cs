using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
            MainWindow = new MainWindow(manager.ViewModel);
            if (MainWindow.ShowDialog() == true)
            {
                RepositoryInfo info = manager.Model;
                RepositoryGenerator.Generate(info);
            }
        }
    }
}
