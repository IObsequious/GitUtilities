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
            get
            {
                return _model.WorkingDirectory;
            }
            set
            {
                if (value == _model.WorkingDirectory) return;
                _model.WorkingDirectory = value;
                OnPropertyChanged();
            }
        }

        public string RepositoryName
        {
            get
            {
                return _model.RepositoryName;
            }
            set
            {
                if (value == _model.RepositoryName) return;
                _model.RepositoryName = value;
                OnPropertyChanged();
            }
        }

        public bool Force
        {
            get
            {
                return _model.Force;
            }
            set
            {
                if (value == _model.Force) return;
                _model.Force = value;
                OnPropertyChanged();
            }
        }

        public StartProgram StartProgram
        {
            get
            {
                return _model.StartProgram;
            }
            set
            {
                if (value == _model.StartProgram) return;
                _model.StartProgram = value;
                OnPropertyChanged();
            }
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
