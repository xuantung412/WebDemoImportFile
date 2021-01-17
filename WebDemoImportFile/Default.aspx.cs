using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebDemoImportFile
{
    public partial class _Default : Page
    {

        private static readonly HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ProcessRepositories()
        {
            client.BaseAddress = new Uri("https://localhost:44347/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "T1RLAQLKfTvA1vUF5Fw94XIaWcYfAkDLsBCyYiJeTIABe3u7aVna4ZXUAADQ8zxcMgEP2vck/pKU4kwMJE3g4FpxhGApsFj2qCra/0P//fIKtoNJMu6AV6GKIlU/J/kjpoOlEZ0OdCcE1zF46vjSgjiq7TpUQzwfRKvAS/AQEjsTTUH/lh0ClMFwT7/qnWgTp5d3+cZsUrvohCSM/IsgG2qSP7z7E6qUNyut+jd5k2xaXle0QoUciJBC//TYXMqZ3ASDkKAyJWaOmmnKKQZYOs87dQaZtsdrNnsyismECWuIfPbgN+0AkP03wPyrQBPK2eyfXmnn3givhouJIw**");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Task<String> stringTask = client.GetStringAsync("https://api-crt.cert.havail.sabre.com/v1/lists/supported/shop/themes");
            
            
            /*string data = await datatask;
            o = JObject.Parse(data);
            Debug.WriteLine("firstname:" + o["id"][0]);
            */
            var msg = stringTask;
            Console.Write(msg);
            TextBoxDisplay.Text = stringTask.Result;

            return stringTask.ToString();
            //throw new NotImplementedException();
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string inputContent;
            using (StreamReader inputStreamReader = new StreamReader(FileUpload1.PostedFile.InputStream))
            {
                inputContent = inputStreamReader.ReadToEnd();
            }
            this.FileUpload1.PostedFile.SaveAs(Server.MapPath("./") + this.FileUpload1.PostedFile.FileName);
            RequestDataAPIsButton.Text = Server.MapPath("./") + this.FileUpload1.PostedFile.FileName;

                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(Server.MapPath("./"), this.FileUpload1.PostedFile.FileName), true))
                {
                    outputFile.WriteLine(inputContent);
                }
            
            GridView2.DataSource = jsondatadisplay();
            GridView2.BorderStyle = BorderStyle.None;
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

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //TextBoxDisplay.Text =ProcessRepositories();
            ProcessRepositories();
        }

        //Connect external APIs



    }
}