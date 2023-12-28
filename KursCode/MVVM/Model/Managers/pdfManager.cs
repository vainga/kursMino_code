using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using KursCode.Interfaces;

namespace KursCode.MVVM.Model.Managers
{
    public class pdfManager : IpdfManager
    {
        public byte[] SelectPDF()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*",
                Title = "Выберите PDF файл"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;

                try
                {
                    byte[] pdfBytes = File.ReadAllBytes(fileName);

                    return pdfBytes;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }
            return null;
        }

        public byte[] fromBase64toPdf(string pdfBase64)
        {
            try
            {
                byte[] pdfBytes = Convert.FromBase64String(pdfBase64);
                return pdfBytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string toBase64(byte[] pdfBytes)
        {
            return Convert.ToBase64String(pdfBytes);
        }

    }
}
