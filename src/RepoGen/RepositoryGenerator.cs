using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace RepoGen
{
    public static class RepositoryGenerator
    {
        public const string RootUrl = "https://raw.githubusercontent.com/IObsequious/dotnet-templates/master/templates/RepositorySolution";
        private static string RootDirectory;
        private static int _total;
        private static int _current;
        public static void Generate(RepositoryInfo info)
        {
            _total = 27;
            _current = 0;

            RootDirectory = Path.Combine(info.WorkingDirectory, info.RepositoryName);

            if (Directory.Exists(RootDirectory))
            {
                Directory.Delete(RootDirectory, true);
            }

            Thread.Sleep(1000);
            CreateDirectories(RootDirectory,
                ".github",
                "build\\strong name keys",
                "build\\rulesets",
                "docs",
                "src\\lib",
                "src\\ConsoleTester\\Properties",
                "tools");
            DownloadFile(".editorconfig");
            DownloadFile(".gitignore");
            DownloadFile(".tfignore");
            DownloadFile("build.cmd");
            DownloadFile("clean.cmd");
            DownloadFile("License.txt");
            DownloadFile("packages.cmd");
            DownloadFile("Packages.props");
            DownloadFile("readme.md");
            DownloadFile("rebuild.cmd");
            DownloadFile("restore.cmd");
            DownloadFile("shell.cmd");
            DownloadFile(@"build\rulesets\SolutionRules.ruleset");
            DownloadFile(@"build\strong name keys\35MSSharedLib1024.snk");
            DownloadFile(@"build\strong name keys\SolutionKey.snk");
            DownloadFile(@"docs\ContributorCovenant.md");
            DownloadFile(@"src\Directory.Build.props");
            DownloadFile(@"src\Directory.Build.targets");
            DownloadFile(@"src\nuget.config");
            DownloadFile(@"src\SolutionFile.sln", $"src\\{info.RepositoryName}.sln");
            DownloadFile(@"src\ConsoleTester\ConsoleTester.csproj");
            DownloadFile(@"src\ConsoleTester\Program.cs");
            DownloadFile(@"src\ConsoleTester\Properties\launchSettings.json");
            DownloadFile(@"tools\Microsoft.Extensions.CommandLineUtils.dll");
            DownloadFile(@"tools\Newtonsoft.Json.dll");
            DownloadFile(@"tools\Packages.props");
            DownloadFile(@"tools\RepositoryUtility.exe");
            if (info.StartProgram == StartProgram.VisualStudio)
            {
                Process.Start(Path.Combine(RootDirectory, $"src\\{info.RepositoryName}.sln"));
            }
            else if (info.StartProgram == StartProgram.Explorer)
            {
                ProcessStartInfo startInfo =
                    new ProcessStartInfo
                    {
                        FileName = "C:\\Windows\\Explorer.exe",
                        WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        Arguments = RootDirectory,
                        WindowStyle = ProcessWindowStyle.Normal
                    };
                Process p = new Process
                {
                    StartInfo = startInfo
                };
                p.Start();
            }

        }

        private static async Task DoWorkAsync(RepositoryInfo info)
        {
 
        }

        private static void DownloadFile(string relativePath)
        {
            DownloadFile(relativePath, relativePath);

        }

        private static void DownloadFile(string relativePath, string relativeDestination)
        {
            string downloadFileUrl = string.Format("{0}/{1}", RootUrl, relativePath);
            string downloadFilePath = Path.Combine(RootDirectory, relativeDestination);
            using (WebClient client = new WebClient())
            {
                
                _current++;
                client.DownloadFile(downloadFileUrl, downloadFilePath);
                
            }
        }

        private static void CreateDirectories(params string[] subDirectories)
        {
            Directory.CreateDirectory(RootDirectory);
            foreach (string subDiretory in subDirectories)
            {
                Directory.CreateDirectory(Path.Combine(RootDirectory, subDiretory));
            }
        }
    }

}
