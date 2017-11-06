using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SyncFolders
{
    public partial class SyncFoldersForm : Form
    {
        SyncFolders syncFolders = null;
        SyncConfig syncConfig = null;
        public SyncFoldersForm()
        {
            InitializeComponent();
            syncConfig = SyncConfig.ReadConfig();
            if (string.IsNullOrEmpty(syncConfig.SourceFolder))
                txtSrcFolder.Text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            else
                txtSrcFolder.Text = syncConfig.SourceFolder;

            txtDstFolder.Text = syncConfig.DestinationFolder;
        }

        private void btnIntercambio_Click(object sender, EventArgs e)
        {
            string src = txtSrcFolder.Text;
            txtSrcFolder.Text = txtDstFolder.Text;
            txtDstFolder.Text = src;
        }

        private void btnFindSrcFolder_Click(object sender, EventArgs e)
        {
            SearchFolder(true);
        }

        private void btnFindDstFolder_Click(object sender, EventArgs e)
        {
            SearchFolder(false);
        }
        void SearchFolder(bool sourceFolder)
        {
            using (FolderBrowserDialog f = new FolderBrowserDialog())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (sourceFolder)
                        txtSrcFolder.Text = f.SelectedPath;
                    else
                        txtDstFolder.Text = f.SelectedPath;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSrcFolder.Text) &&
                !string.IsNullOrEmpty(txtDstFolder.Text))
            {
                if (!Directory.Exists(txtSrcFolder.Text))
                    MessageBox.Show("EL DIRECTORIO ORIGEN NO EXISTE!");
                else if (!Directory.Exists(txtDstFolder.Text))
                    MessageBox.Show("EL DIRECTORIO DESTINO NO EXISTE!");
                else
                {
                    btnCancel.Visible = true;
                    btnStart.Enabled = false;
                    grpFolders.Enabled = false;

                    txtTraces.Text = "";

                    syncConfig.SourceFolder = txtSrcFolder.Text;
                    syncConfig.DestinationFolder = txtDstFolder.Text;
                    SyncConfig.WriteConfig(syncConfig);

                    syncFolders = new SyncFolders(txtSrcFolder.Text, txtDstFolder.Text, syncConfig.TraceLevel);
                    syncFolders.TraceFired += SyncFolders_TraceFired;
                    syncFolders.Finished += SyncFolders_Finished;
                    syncFolders.StartSyncFolders();
                }
            }
            else
                MessageBox.Show("HAY QUE RELLENAR EL DIRECTORIO ORIGEN Y DESTINO!");
        }

        private void SyncFolders_Finished(string msg)
        {
            AddTrace(msg);
            btnCancel.Visible = false;
            btnStart.Enabled = true;
            grpFolders.Enabled = true;
        }

        private void SyncFolders_TraceFired(string msg)
        {
            AddTrace(msg);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            syncFolders?.Cancel();
        }

        void AddTrace(string msg)
        {
            txtTraces.Text += $"{msg}{Environment.NewLine}";
        }
    }
}
