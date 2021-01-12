using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;

namespace WebDemoImportFile
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string inputContent;
            using (StreamReader inputStreamReader = new StreamReader(FileUpload1.PostedFile.InputStream))
            {
                inputContent = inputStreamReader.ReadToEnd();
            }
            TextBoxDisplay.Text = inputContent;
            this.FileUpload1.PostedFile.SaveAs(Server.MapPath("./") + this.FileUpload1.PostedFile.FileName);
            Label1.Text = Server.MapPath("./") + this.FileUpload1.PostedFile.FileName;

                // Set a variable to the Documents path.
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Append text to an existing file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Server.MapPath("./"), this.FileUpload1.PostedFile.FileName), true))
                {
                    outputFile.WriteLine(inputContent);
                }
            
            GridView2.DataSource = jsondatadisplay();
            GridView2.DataBind();

        }


        public DataTable jsondatadisplay()
        {
            StreamReader sr = new StreamReader(Server.MapPath("./") + this.FileUpload1.PostedFile.FileName);
            string json = sr.ReadToEnd();
            var dataSet = JsonConvert.DeserializeObject<DataSet>(json);
            var table = dataSet.Tables[0];
            return table;

        }
    }
}