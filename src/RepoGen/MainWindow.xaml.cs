using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using TextBox = System.Windows.Controls.TextBox;

namespace RepoGen
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RepositoryInfoViewModel _viewModel;

        public MainWindow() : this(new RepositoryInfoViewModel(new RepositoryInfo()))
        {
        }

        public MainWindow(RepositoryInfoViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            DataContext = _viewModel;
            RepositoryNameTextBox.Focus();
        }

        /// <summary>
        ///     Invoked when an unhandled <see cref="E:System.Windows.Input.Keyboard.PreviewKeyDown" /> attached event reaches
        ///     an element in its route that is derived from this class. Implement this method to add class handling for this
        ///     event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.Input.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                DialogResult = false;
                Close();
            }
        }

        private void OnOKButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void OnExecuteCommandOpen(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void OnExecutedCommandClose(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void OnExecutedCommandNew(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void OnExecutedCommandSaveAs(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void OnExecutedCommandCopy(object sender, ExecutedRoutedEventArgs e)
        {
        }

        private void OnSearchButtonClick(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.Personal;
                dialog.ShowNewFolderButton = true;
                dialog.Description = "Choose a working directory for the new repository.";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    WorkingDirectoryTextBox.SetValue(TextBox.TextProperty, dialog.SelectedPath);
                }
            }
        }
    }
}
