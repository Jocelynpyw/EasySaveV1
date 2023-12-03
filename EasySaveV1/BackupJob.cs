using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveV1
{
    public class BackupJob
    {
        public string JobName { get; set; }
        public string SourceDirectory { get; set; }
        public string DestinationDirectory { get; set; }
        public BackupType BackupType { get; set; }
        public bool IsActive { get; set; }

        public BackupJob(string jobName , string sourceDirectory , string destinationDirectory )
        {
            this.JobName = jobName;
            this.SourceDirectory = sourceDirectory;
            this.DestinationDirectory = destinationDirectory;
        }

        private static void CopyDirectory(string source, string destination)
        {
            // Créez le répertoire de destination s'il n'existe pas
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            // Obtenez la liste des fichiers
            string[] files = Directory.GetFiles(source);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destPath = Path.Combine(destination, fileName);
                File.Copy(file, destPath, true);
                Console.WriteLine($"Copie du fichier : {fileName}");
            }

            // Obtenez la liste des sous-répertoires
            string[] directories = Directory.GetDirectories(source);
            foreach (string directory in directories)
            {
                string dirName = Path.GetFileName(directory);
                string destPath = Path.Combine(destination, dirName);
                CopyDirectory(directory, destPath);
            }
        }
        public  void Save()
        {
            CopyDirectory(this.SourceDirectory, this.DestinationDirectory);
        }

    }

    public enum BackupType
    {
        Full,
        Differential
    }
}
