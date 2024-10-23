using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentSitek._7zipDownloader
{
    public class HttpDownloader
    {
        
        public static async Task DownloadLauncher(string FIAS_SourseLink)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(FIAS_SourseLink);
                        if (response.IsSuccessStatusCode)
                        {
                            using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                                    fileStream = new FileStream(config.TempFile_Sourse, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true)
                                    {

                                    })
                            {
                                await contentStream.CopyToAsync(fileStream);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Не удалось скачать файл.  Error: " + response.StatusCode);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошла ошибка при выполнении HTTP-запроса: " + e.Message);
                    }
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
