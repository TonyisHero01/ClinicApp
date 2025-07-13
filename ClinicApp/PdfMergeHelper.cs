using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System.Collections.Generic;
using System.IO;

public static class PdfMergeHelper
{
    public static void MergePdfs(string outputPath, IEnumerable<string> inputPaths)
    {
        using var outputDocument = new PdfDocument();

        foreach (var path in inputPaths)
        {
            if (!File.Exists(path)) continue;

            using var inputDocument = PdfReader.Open(path, PdfDocumentOpenMode.Import);
            for (int i = 0; i < inputDocument.PageCount; i++)
            {
                outputDocument.AddPage(inputDocument.Pages[i]);
            }
        }

        outputDocument.Save(outputPath);
    }
}
