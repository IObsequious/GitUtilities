// -----------------------------------------------------------------------
// <copyright file="RepositoryInfo.cs" company="Ollon, LLC">
//     Copyright (c) 2017 Ollon, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using RepoGen.Properties;

namespace RepoGen
{
    public class RepositoryInfo
    {
        public RepositoryInfo()
        {
            RepositoryName = Settings.Default.RepositoryName;
            WorkingDirectory = Settings.Default.WorkingDirectory;
            Force = Settings.Default.Force;
            StartProgram = (StartProgram) Settings.Default.StartProgram;
        }

        ~RepositoryInfo()
        {
            
            Settings.Default.WorkingDirectory = WorkingDirectory;
            Settings.Default.Force = Force;
            Settings.Default.RepositoryName = RepositoryName;
            Settings.Default.StartProgram = (int) StartProgram;
        }

        public string RepositoryName { get; set; }

        public string WorkingDirectory { get; set; }

        public bool Force { get; set; }

        public StartProgram StartProgram { get; set; }
    }
}
