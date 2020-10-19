using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;


namespace FotoCek.Business.Concrete
{
    public static class ExcelExport
    {


        public static void startExport(RadGridView grdView)
        {
            MemoryStream ms = new MemoryStream();
            GridViewSpreadExport exporter = new GridViewSpreadExport(grdView);
            SpreadExportRenderer renderer = new SpreadExportRenderer();
            exporter.AsyncExportCompleted += exporter_AsyncExportCompleted;
            exporter.RunExportAsync(ms, renderer);
        }

        private static void exporter_AsyncExportCompleted(object sender, AsyncCompletedEventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            if (result== DialogResult.OK)
            {
                RunWorkerCompletedEventArgs args = e as RunWorkerCompletedEventArgs;
                string exportFile = fd.SelectedPath + @"\HareketDokumu.xlsx";
                using (System.IO.FileStream fileStream = new System.IO.FileStream(exportFile, FileMode.Create, FileAccess.Write))
                {
                    MemoryStream ms = args.Result as MemoryStream;
                    ms.WriteTo(fileStream);
                    ms.Close();
                }

                MessageBox.Show("Liste başarıyla yedeklendi.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

    }
}
