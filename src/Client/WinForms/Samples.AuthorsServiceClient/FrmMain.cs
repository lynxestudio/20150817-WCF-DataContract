using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Samples.AuthorsService;
using System.ServiceModel;

namespace Samples.AuthorsServiceClient
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnAddClick(object sender, EventArgs e)
        {
            ClearForm();
            try
            {
                var proxy = Getproxy();
                Author a = new Author
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    BirthDate = calBirthDate.SelectionRange.Start,
                    Gender = chkGender.Checked
                };
                MessageBox.Show(proxy.CreateAuthor(a));
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("See the log.");
                Logger.LogWriteError(ex.Message);
            }
        }

        private void BtnRefreshClick(object sender, EventArgs e)
        {
            try
            {
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("See the log.");
                Logger.LogWriteError(ex.Message);
            }
        }

        void RefreshGrid()
        {
            var proxy = Getproxy();
            List<Author> authors = proxy.GetAuthors();
            authorsListStore.DataSource = authors;
        }

        void ClearForm()
        {
            txtFirstName.Text = txtLastName.Text = String.Empty;
            chkGender.Checked = false;
        }

        IAuthorServiceContract Getproxy()
        {
            EndpointAddress address = new EndpointAddress("http://localhost:9000/");
            BasicHttpBinding binding = new BasicHttpBinding();
            IAuthorServiceContract proxy = ChannelFactory<IAuthorServiceContract>.CreateChannel(binding, address);
            return proxy;
        }
    }
}
