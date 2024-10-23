using SharpCompress.Archives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentSitek._7zipDownloader
{
    public class Unzip
    {
        public static void ExtarctArchive(string archivePath, string extractPath)
        {
            try
            {
                using (var archive = ArchiveFactory.Open(archivePath))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            string filePath = Path.Combine(extractPath, entry.Key);
                            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                            using (var entryStream = entry.OpenEntryStream())
                            using (var fileStream = File.Create(filePath))
                            {
                                entryStream.CopyTo(fileStream);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
