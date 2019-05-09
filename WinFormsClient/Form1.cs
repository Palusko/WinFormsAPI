using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class FormBooks : Form
    {
        public FormBooks()
        {
            InitializeComponent();
        }

        private void FormBooks_Load(object sender, EventArgs e)
        {
            GetAllBooks();
        }

        private async void GetAllBooks()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:60039/api/books"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var productJsonString = await response.Content.ReadAsStringAsync();

                            dataGridViewBooks.DataSource = JsonConvert.DeserializeObject<BookDto[]>(productJsonString).ToList();

                    }
                }
            }
        }
    }
}
