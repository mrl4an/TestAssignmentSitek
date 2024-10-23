using DocumentFormat.OpenXml.Office2013.Word;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAssignmentSitek.DataModel;

namespace TestAssignmentSitek.View
{
    public class FinalTextDocument
    {
        public static void CreateTextFile(List<ObjectInfo> objectInfos)
        {
            // Создаем новый документ Word
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(config.ResultFile_Sourse, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                // Добавляем основной документ
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = new Body();

                // Добавляем текст в документ
                Paragraph para = new Paragraph();
                Run run = new Run();

                // Устанавливаем размер шрифта
                RunProperties runProperties = new RunProperties();
                runProperties.FontSize = new FontSize() { Val = "32" };
                runProperties.Color = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = "1f497d" };
                run.PrependChild(runProperties); // Добавляем свойства к Run

                run.Append(new Text("Отчет по добавленным адресным объектам за \n" + config.DateLastFile));
                para.Append(run);


                Paragraph para_level1 = new Paragraph();
                Run run_level1 = new Run();

                RunProperties runProperties_level1 = new RunProperties();
                runProperties_level1.FontSize = new FontSize() { Val = "24" };
                runProperties_level1.Color = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = "1f497d" };
                run_level1.PrependChild(runProperties_level1); 

                run_level1.Append(new Text("Город/Округ \n"));
                para_level1.Append(run_level1);


                var Level1ToFilter = new List<string> { "АО", "г", "г.о.", "м.р-н", "р-н", "тер", "у", "вн.тер. г." };

                // Получаем список согласно уровням объектов от ФИАС
                List<ObjectInfo> filteredLevel1 = objectInfos
                    .Where(item => Level1ToFilter.Contains(item.name_type))
                    .ToList();


                // Создаем таблицу
                Table table = new Table();

                // Устанавливаем ширину таблицы
                TableProperties tblProperties = new TableProperties(
                    new TableWidth() { Type = TableWidthUnitValues.Pct, Width = "10000" }
                );
                table.AppendChild(tblProperties);

                // Создаем строки и ячейки
                for (int i = 0; i < filteredLevel1.Count; i++) // 3 строки
                {
                    TableRow tableRow = new TableRow();

                    TableCell tableCell = new TableCell(new Paragraph(new Run(new Text(filteredLevel1[i].name_type))));
                    tableRow.Append(tableCell);

                    TableCell tableCell2 = new TableCell(new Paragraph(new Run(new Text(filteredLevel1[i].name))));
                    tableRow.Append(tableCell2);


                    table.Append(tableRow);
                }



                Paragraph para_level2 = new Paragraph();
                Run run_level2 = new Run();

                RunProperties runProperties_level2 = new RunProperties();
                runProperties_level2.FontSize = new FontSize() { Val = "24" };
                runProperties_level2.Color = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = "1f497d" };
                run_level2.PrependChild(runProperties_level2);

                run_level2.Append(new Text("Село/Городское поселение \n"));
                para_level2.Append(run_level2);

                var Level2ToFilter = new List<string> { "волость","дп","кп","массив","п","пгт","п/о","рп","рп.","с","с.","с/а","с/о","с/мо","с/п","с/с"};

                // Получаем список согласно уровням объектов от ФИАС
                List<ObjectInfo> filteredLevel2 = objectInfos
                    .Where(item => Level1ToFilter.Contains(item.name_type))
                    .ToList();


                // Создаем таблицу
                Table table2 = new Table();

                // Устанавливаем ширину таблицы
                TableProperties tblProperties2 = new TableProperties(
                    new TableWidth() { Type = TableWidthUnitValues.Pct, Width = "10000" }
                );
                table2.AppendChild(tblProperties2);

                // Создаем строки и ячейки
                for (int i = 0; i < filteredLevel2.Count; i++) // 3 строки
                {
                    TableRow tableRow = new TableRow();

                    TableCell tableCell = new TableCell(new Paragraph(new Run(new Text(filteredLevel2[i].name_type))));
                    tableRow.Append(tableCell);

                    TableCell tableCell2 = new TableCell(new Paragraph(new Run(new Text(filteredLevel2[i].name))));
                    tableRow.Append(tableCell2);


                    table2.Append(tableRow);
                }

                Paragraph para_level3 = new Paragraph();
                Run run_level3 = new Run();

                RunProperties runProperties_level3 = new RunProperties();
                runProperties_level3.FontSize = new FontSize() { Val = "24" };
                runProperties_level3.Color = new DocumentFormat.OpenXml.Wordprocessing.Color() { Val = "1f497d" };
                run_level3.PrependChild(runProperties_level3);

                run_level3.Append(new Text("Элемент улично-дорожной сети \n"));
                para_level3.Append(run_level3);

                var Level3ToFilter = new List<string> { "аал", "автодорога", "арбан", "аул", "волость", "в-ки", "высел", "г-к", "гп", "гп.", "дп", "дп.", "д", "д.", "ж/д_оп", "ж/д_будка", "ж/д в-ка", "ж/д_казарм", "ж/д_платф", "ж/д пл-ка", "ж/д ст", "ж/д_ст", "ж/д бл-ст", "ж/д к-т", "ж/д о.п.", "ж/д_пост", "ж/д п.п.", "ж/д рзд", "ж/д_рзд", "жилзона", "жилрайон", "з-ка", "заимка", "зим.", "казарма", "кв-л", "киш.", "кордон", "кп", "кп.", "лпх", "массив", "м", "м-ко", "мкр", "нп", "нп.", "остров", "пл.р-н", "погост", "п", "п.", "пгт", "п/ст", "п. ж/д ст.", "п. ст.", "пос.рзд", "пос.рзд.", "п-к", "починок", "п/о", "промзона", "рп", "рп.", "рзд", "рзд.", "снт", "с", "с.", "сп", "сп.", "сл", "сл.", "ст-ца", "ст", "ст.", "у", "у.", "х", "х." };

                // Получаем список согласно уровням объектов от ФИАС
                List<ObjectInfo> filteredLevel3 = objectInfos
                    .Where(item => Level3ToFilter.Contains(item.name_type))
                    .ToList();


                // Создаем таблицу
                Table table3 = new Table();

                // Устанавливаем ширину таблицы
                TableProperties tblProperties3 = new TableProperties(
                    new TableWidth() { Type = TableWidthUnitValues.Pct, Width = "10000" }
                );
                table3.AppendChild(tblProperties3);

                // Создаем строки и ячейки
                for (int i = 0; i < filteredLevel3.Count; i++) // 3 строки
                {
                    TableRow tableRow = new TableRow();

                    TableCell tableCell = new TableCell(new Paragraph(new Run(new Text(filteredLevel3[i].name_type))));
                    tableRow.Append(tableCell);

                    TableCell tableCell2 = new TableCell(new Paragraph(new Run(new Text(filteredLevel3[i].name))));
                    tableRow.Append(tableCell2);


                    table3.Append(tableRow);
                }



                body.Append(para);
                body.Append(para_level1);
                body.Append(table);
                body.Append(para_level2);
                body.Append(table2);
                body.Append(para_level3);
                body.Append(table3);


                // Сохраняем изменения
                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }
        }
    }
}
