using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RepoGen
{
    public class RepositoryInfoViewModel : INotifyPropertyChanged
    {
        private readonly RepositoryInfo _model;

        public event PropertyChangedEventHandler PropertyChanged;

        public RepositoryInfoViewModel(RepositoryInfo model)
        {
            _model = model;
        }

        public string WorkingDirectory
        {
            get => _model.WorkingDirectory;
            set
            {
                if (value == _model.WorkingDirectory) return;
                _model.WorkingDirectory = value;
                OnPropertyChanged();
            }
        }

        public string RepositoryName
        {
            get => _model.RepositoryName;
            set
            {
                if (value == _model.RepositoryName) return;
                _model.RepositoryName = value;
                OnPropertyChanged();
            }
        }

        public bool Force
        {
            get => _model.Force;
            set
            {
                if (value == _model.Force) return;
                _model.Force = value;
                OnPropertyChanged();
            }
        }

        public bool OpenInVisualStudio
        {
            get => _model.OpenInVisualStudio;
            set
            {
                if (value == _model.OpenInVisualStudio) return;
                _model.OpenInVisualStudio = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
