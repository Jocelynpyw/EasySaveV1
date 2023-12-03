using System;
using System.IO;

namespace EasySaveV1
{


    class Program
    {
        static void Main()
        {
            // Création d'un objet BackupJob
            BackupJob backupJob = new BackupJob("BackupJob1", @"D:\Mon CF", @"D:\Fichiers de copies");

            // Vérification de l'existence du répertoire source
            if (!Directory.Exists(backupJob.SourceDirectory))
            {
                Console.WriteLine($"Le répertoire source '{backupJob.SourceDirectory}' n'existe pas.");
                return;
            }

            // Vérification de l'existence du répertoire destination
            if (!Directory.Exists(backupJob.DestinationDirectory))
            {
                Console.WriteLine($"Le répertoire destination '{backupJob.DestinationDirectory}' n'existe pas.");
                return;
            }

            // Affichage des détails du job
            Console.WriteLine($"Backup Job: {backupJob.JobName}");
            Console.WriteLine($"Source Directory: {backupJob.SourceDirectory}");
            Console.WriteLine($"Destination Directory: {backupJob.DestinationDirectory}");
            Console.WriteLine($"Backup Type: {backupJob.BackupType}");
            Console.WriteLine($"Is Active: {backupJob.IsActive}");
            Console.WriteLine();

            // Copie des fichiers en fonction du type de sauvegarde
            try
            {
                if (backupJob.BackupType == BackupType.Full)

                {
                    backupJob.Save();
                    Console.WriteLine("Backup complet effectué avec succès.");
                }
                else if (backupJob.BackupType == BackupType.Differential)
                {
                    // Implémentez ici la logique pour une sauvegarde différentielle
                    Console.WriteLine("Backup différentiel non implémenté dans cet exemple.");
                }
                else
                {
                    Console.WriteLine("Type de sauvegarde non pris en charge.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la copie : {ex.Message}");
            }
        }

        
    }
}
