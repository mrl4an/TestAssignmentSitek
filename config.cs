using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentSitek
{
    internal class config
    {
        public static string CurrentDirecory = Directory.GetCurrentDirectory();
        public static string TempFile_Sourse = CurrentDirecory + @"\1.7z";
        public static string ResultFile_Sourse = CurrentDirecory + @"\result.docx";
        public static string DateLastFile {  get; set; }
    }
}
