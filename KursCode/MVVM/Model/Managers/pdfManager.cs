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
        public void SelectPDF(string PDF_fileName,string pdfBase64)
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
                    string base64String = Convert.ToBase64String(pdfBytes);

                    fileName = Path.GetFileName(openFileDialog.FileName);
                    PDF_fileName = fileName;
                    pdfBase64 = base64String;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }
        }

    }
}
