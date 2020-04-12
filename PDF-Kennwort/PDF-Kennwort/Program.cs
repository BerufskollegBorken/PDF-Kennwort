using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Kennwort
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileGroup = Directory.GetFiles(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\", "*.pdf"
                );

            foreach (string fileName in (from f in fileGroup
                                         where !f.Contains("-Kennwort")
                                         select f).ToList())
            {                
                PdfDocument document = PdfReader.Open(fileName);
                PdfSecuritySettings securitySettings = document.SecuritySettings;
                securitySettings.UserPassword = "!7765Neun";
                securitySettings.OwnerPassword = "!7765Neun";
                securitySettings.PermitAccessibilityExtractContent = false;
                securitySettings.PermitAnnotations = false;
                securitySettings.PermitAssembleDocument = false;
                securitySettings.PermitExtractContent = false;
                securitySettings.PermitFormsFill = true;
                securitySettings.PermitFullQualityPrint = false;
                securitySettings.PermitModifyDocument = true;
                securitySettings.PermitPrint = false;
                document.Save(fileName.Replace(".pdf","-Kennwort.pdf"));
            }
        }
    }
}
