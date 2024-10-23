using TestAssignmentSitek._7zipDownloader;
using TestAssignmentSitek.FIAS_API;
using TestAssignmentSitek.View;

namespace TestAssignmentSitek
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*
            GetLastDownloadFileInfo getLastDownloadFileInfo = new GetLastDownloadFileInfo();
            string LastDownloadFile = await getLastDownloadFileInfo.GetSourseLink();//получаем ссылку на сегодняшний файл
            await HttpDownloader.DownloadLauncher(LastDownloadFile);//скачиваем архив
            Unzip.ExtarctArchive(config.TempFile_Sourse, config.CurrentDirecory);//распаковываем
            */
            FinalTextDocument.CreateTextFile(DataBaseProcessing.ObjectInfos());
        }
    }
}
