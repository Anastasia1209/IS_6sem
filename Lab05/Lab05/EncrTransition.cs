using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class EncrTransition
    {
         const string fileNameOpen = "lab5.txt";
        const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        const string pathToFolder = "D:\\Univer\\6sem\\IS\\Lab05";
       
        public static char[,] EncryptMultiple(string keyColumns, string keyRows, string fileName = fileNameOpen)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var openText = ReadFromFile(fileName);
            (var indexesRows, var indexesColumns) = GetRowsAndColsIndexesArrays(keyColumns, keyRows, openText);
            var rows = indexesRows.Length;
            var cols = indexesColumns.Length;
            var table = ConvertToTwoDimentionalArray(openText, rows, cols);

            var tableWithSwappedRows = table.Clone() as char[,];
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < cols; j++)
                    tableWithSwappedRows[i, j] = table[indexesRows[i], j];

            var tableWithSwappedRowsAndColumns = tableWithSwappedRows.Clone() as char[,];
            for (var j = 0; j < cols; j++)
                for (var i = 0; i < rows; i++)
                    tableWithSwappedRowsAndColumns[i, j] = tableWithSwappedRows[i, indexesColumns[j]];

            var encryptedTableByColumns = GetTableByColumns(tableWithSwappedRowsAndColumns);

            stopWatch.Stop();
            Console.WriteLine($"\nВремя выполнения операции: {stopWatch.Elapsed}"); return encryptedTableByColumns;
        }

        public static char[,] DecryptMultiple(string keyColumns, string keyRows, char[,] tableEncrypted)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            (var indexesRows, var indexesColumns) = GetRowsAndColsIndexesArrays(keyColumns, keyRows, tableEncrypted);
            var rows = indexesRows.Length;
            var cols = indexesColumns.Length;

            var tableWithSwappedRows = tableEncrypted.Clone() as char[,];
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < cols; j++)
                    tableWithSwappedRows[indexesRows[i], j] = tableEncrypted[i, j];

            var tableWithSwappedRowsAndColumns = tableWithSwappedRows.Clone() as char[,];
            for (var j = 0; j < cols; j++)
                for (var i = 0; i < rows; i++)
                    tableWithSwappedRowsAndColumns[i, indexesColumns[j]] = tableWithSwappedRows[i, j];

            var encryptedTableByColumns = GetTableByColumns(tableWithSwappedRowsAndColumns);

            stopWatch.Stop();
            Console.WriteLine($"\nВремя выполнения операции: {stopWatch.Elapsed}"); return encryptedTableByColumns;
        }

        public static (int[], int[]) GetRowsAndColsIndexesArrays(string keyColumns, string keyRows, char[,] tableEncrypted)
        {
            var keyRowsInitial = keyRows.ToLowerInvariant();
            var keyColumnsInitial = keyColumns.ToLowerInvariant();

            var sbRows = new StringBuilder(keyRowsInitial);
            var sbCols = new StringBuilder(keyColumnsInitial);

            while (sbCols.Length * sbRows.Length < tableEncrypted.Length)
            {
                sbRows.Append(keyRowsInitial);
                sbCols.Append(keyColumnsInitial);
            }

            keyRows = sbRows.ToString();
            keyColumns = sbCols.ToString();

            var indexesRows = GetAlphabetIndexes(keyRows);
            var indexesColumns = GetAlphabetIndexes(keyColumns);

            return (indexesRows, indexesColumns);
        }

        public static (int[], int[]) GetRowsAndColsIndexesArrays(string keyColumns, string keyRows, char[] openText)
        {
            var keyRowsInitial = keyRows.ToLowerInvariant();
            var keyColumnsInitial = keyColumns.ToLowerInvariant();

            var sbRows = new StringBuilder(keyRowsInitial);
            var sbCols = new StringBuilder(keyColumnsInitial);

            while (sbCols.Length * sbRows.Length < openText.Length)
            {
                sbRows.Append(keyRowsInitial);
                sbCols.Append(keyColumnsInitial);
            }

            keyRows = sbRows.ToString();
            keyColumns = sbCols.ToString();

            var indexesRows = GetAlphabetIndexes(keyRows);
            var indexesColumns = GetAlphabetIndexes(keyColumns);

            return (indexesRows, indexesColumns);
        }

        public static int[] GetAlphabetIndexes(string str)
        {
            var index = 0;
            var arrayOfIndexes = new int[str.Length];

            for (var i = 0; i < alphabet.Length; ++i)
                for (var j = 0; j < str.Length; ++j)
                    if (alphabet[i] == str[j])
                    {
                        arrayOfIndexes[j] = index;
                        index++;
                    }

            return arrayOfIndexes;
        }

        public static char[] ReadFromFile(string fileName)
        {
            string path = "D:\\Univer\\6sem\\IS\\Lab05\\lab5.txt";
            var reader = new StreamReader(path);
            string text = reader.ReadToEnd().ToLower();

            return text.ToLower().ToCharArray();
        }



        public static bool WriteToFile(char[] text, string fileName)
        {
            var filePath = Path.Combine(pathToFolder, fileName);
            try
            {
                using (var sw = new StreamWriter(filePath))
                    sw.WriteLine(text);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static char[,] ConvertToTwoDimentionalArray(char[] array, int rows, int cols)
        {
            var length = array.Length;
            var result = new char[rows, cols];
            var index = 0;

            for (var i = 0; i < rows; ++i)
                for (var j = 0; j < cols && index < length; ++j)
                {
                    result[i, j] = array[index];
                    index++;
                }

            return result;
        }

        public static char[,] GetTableByColumns(char[,] inputArray)
        {
            var rows = inputArray.GetLength(0);
            var columns = inputArray.GetLength(1);
            var outputArray = new char[rows, columns];

            for (int j = columns - 1; j >= 0; j--)
                for (int i = 0; i < rows; i++)
                    outputArray[i, j] = inputArray[i, j];
            return outputArray;
        }


        public static char[] ConvertToOneDimentionalArray(char[,] array) => array.Cast<char>().ToArray();

        public static char[] GetOpenText() => ReadFromFile(fileNameOpen);

        public static bool WriteToFile(char[,] text, string fileName) => WriteToFile(ConvertToOneDimentionalArray(text), fileName);
    }
}
