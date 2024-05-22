using System;

namespace KMZI_Lab14
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileNameOpen = @"D:\Univer\6sem\IS\KMZI_Lab14\Lab13\Images\sample.bmp";
            var fileNameEncryptByRows = @"D:\Univer\6sem\IS\KMZI_Lab14\Lab13\Images\ecnrypted_by_rows.bmp";
            var fileNameEncryptByColumns = @"D:\Univer\6sem\IS\KMZI_Lab14\Lab13\Images\ecnrypted_by_columns.bmp";
            var fileNameMatrixSample = @"D:\Univer\6sem\IS\KMZI_Lab14\Lab13\Images\matrix_sample.bmp";
            var fileNameMatrixEncryptByRows = @"D:\Univer\6sem\IS\KMZI_Lab14\Lab13\Images\matrix_encrypt_rows.bmp";
            var fileNameMatrixEncryptByColumns = @"D:\Univer\6sem\IS\KMZI_Lab14\Lab13\Images\matrix_encrypt_columns.bmp";

            var openTextByRows = "GolodokAnastasiya";
            var openTextByColumns = "Golodok";


            Steganography.HideMessageByRows(fileNameOpen, openTextByRows, fileNameEncryptByRows);
            Steganography.HideMessageByColumns(fileNameOpen, openTextByColumns, fileNameEncryptByColumns);
            var resultByRows = Steganography.ExtractMessageByRows(fileNameEncryptByRows);
            var resultByColumns = Steganography.ExtractMessageByColumns(fileNameEncryptByColumns);
           
            Console.WriteLine($"Text by rows: {resultByRows}");
            Console.WriteLine($"Text by columns: {resultByColumns}");

            Steganography.GetColorMatrix(fileNameOpen, fileNameMatrixSample);
            Steganography.GetColorMatrix(fileNameEncryptByRows, fileNameMatrixEncryptByRows);
            Steganography.GetColorMatrix(fileNameEncryptByColumns, fileNameMatrixEncryptByColumns);
        }
    }
}
