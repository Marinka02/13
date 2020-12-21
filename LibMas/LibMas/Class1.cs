using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LibMas
{
    public class WorkingWithArray
    {
        public static void Fill(DataGridView sourceTable, int maxValue)
        {
            Random random = new Random();

            // проверяем что максимальное значение больше нуля, иначе, предполагаю, будет косяк с генерацией
            if (maxValue > 0)
            {
                for (int i = 0; i < sourceTable.ColumnCount; i++)
                    for (int j = 0; j < sourceTable.RowCount; j++)
                        sourceTable[i, j].Value = random.Next(maxValue);
            }
            else
            {
                MessageBox.Show("Максимальное значение должно быть больше нуля!");
            }
        }

        public static void Fill(DataGridView sourceTable, int minValue, int maxValue)
        {
            Random random = new Random();

            if (maxValue > minValue)
            {
                for (int i = 0; i < sourceTable.ColumnCount; i++)
                    for (int j = 0; j < sourceTable.RowCount; j++)
                        sourceTable[i, j].Value = random.Next(minValue, maxValue);
            }
            else
            {
                MessageBox.Show("Максимальное значение должно быть больше минимального!");
            }
        }


        public static void Clear(DataGridView sourceTable)
        {
            for (int i = 0; i < sourceTable.ColumnCount; i++)
                for (int j = 0; j < sourceTable.RowCount; j++)
                    sourceTable[i, j].Value = "";
        }


        public static void SaveFile(DataGridView sourceTable)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if(save.ShowDialog()== DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(save.FileName);

                file.WriteLine(sourceTable.ColumnCount);
                file.WriteLine(sourceTable.RowCount);

                for (int i = 0; i < sourceTable.ColumnCount; i++)
                    for (int j = 0; j < sourceTable.RowCount; j++)
                        file.WriteLine(sourceTable[i, j].Value);

                file.Close();
            }
        }


        public static void OpenFile(DataGridView sourceTable)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            int columns = 0,
                    rows = 0;

            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(open.FileName);

                if (Int32.TryParse(file.ReadLine(), out  columns))
                    {
                        if (Int32.TryParse(file.ReadLine(), out rows))
                        {
                            sourceTable.ColumnCount = columns;
                            sourceTable.RowCount = rows;
                        }
                    else
                    {
                        MessageBox.Show("Ошибка конвертации при чтении!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка конвертации при чтении!");
                    return;
                }

                for (int i = 0; i < columns; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        sourceTable[i, j].Value = file.ReadLine();
                    }
                }
            }
        }
    }
}
