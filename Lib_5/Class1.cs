using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_5
{
    public class Class1
    {
        public static void Odd(DataGridView table, out int column)
        {
            bool isOdd;
            column = 0; // столбец
            for (int i = 0; i < table.ColumnCount; i++)
            {
                isOdd = true;
                for (int j = 0; j < table.RowCount; j++)
                {
                    if (Int32.TryParse(Convert.ToString(table[i, j].Value), out int dop) == true)
                    {
                        if (dop % 2 == 0)
                        {
                            isOdd = false;
                            break;
                        }
                    }
                    
                    else
                    {
                        MessageBox.Show("Некорректный ввод");
                        return;
                    }
                }
                if (isOdd)
                {
                    // запоминаем столбец 
                    column = i + 1;
                    return;
                }
            }
        }
    }
}
