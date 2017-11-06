namespace SyncFolders
{
    partial class SyncFoldersForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncFoldersForm));
            this.txtTraces = new System.Windows.Forms.TextBox();
            this.lblTraces = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpFolders = new System.Windows.Forms.GroupBox();
            this.btnIntercambio = new System.Windows.Forms.Button();
            this.btnFindDstFolder = new System.Windows.Forms.Button();
            this.btnFindSrcFolder = new System.Windows.Forms.Button();
            this.txtDstFolder = new System.Windows.Forms.TextBox();
            this.lblDstFolder = new System.Windows.Forms.Label();
            this.txtSrcFolder = new System.Windows.Forms.TextBox();
            this.lblSrcFolder = new System.Windows.Forms.Label();
            this.grpFolders.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTraces
            // 
            this.txtTraces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTraces.Location = new System.Drawing.Point(15, 162);
            this.txtTraces.Multiline = true;
            this.txtTraces.Name = "txtTraces";
            this.txtTraces.ReadOnly = true;
            this.txtTraces.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTraces.Size = new System.Drawing.Size(681, 203);
            this.txtTraces.TabIndex = 7;
            // 
            // lblTraces
            // 
            this.lblTraces.AutoSize = true;
            this.lblTraces.Location = new System.Drawing.Point(12, 148);
            this.lblTraces.Name = "lblTraces";
            this.lblTraces.Size = new System.Drawing.Size(39, 13);
            this.lblTraces.TabIndex = 8;
            this.lblTraces.Text = "Trazas";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 115);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Sincronizar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(107, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpFolders
            // 
            this.grpFolders.Controls.Add(this.btnIntercambio);
            this.grpFolders.Controls.Add(this.btnFindDstFolder);
            this.grpFolders.Controls.Add(this.btnFindSrcFolder);
            this.grpFolders.Controls.Add(this.txtDstFolder);
            this.grpFolders.Controls.Add(this.lblDstFolder);
            this.grpFolders.Controls.Add(this.txtSrcFolder);
            this.grpFolders.Controls.Add(this.lblSrcFolder);
            this.grpFolders.Location = new System.Drawing.Point(15, 5);
            this.grpFolders.Name = "grpFolders";
            this.grpFolders.Size = new System.Drawing.Size(681, 104);
            this.grpFolders.TabIndex = 11;
            this.grpFolders.TabStop = false;
            this.grpFolders.Text = "Directorios";
            // 
            // btnIntercambio
            // 
            this.btnIntercambio.Image = ((System.Drawing.Image)(resources.GetObject("btnIntercambio.Image")));
            this.btnIntercambio.Location = new System.Drawing.Point(586, 18);
            this.btnIntercambio.Name = "btnIntercambio";
            this.btnIntercambio.Size = new System.Drawing.Size(76, 74);
            this.btnIntercambio.TabIndex = 13;
            this.btnIntercambio.UseVisualStyleBackColor = true;
            this.btnIntercambio.Click += new System.EventHandler(this.btnIntercambio_Click);
            // 
            // btnFindDstFolder
            // 
            this.btnFindDstFolder.Location = new System.Drawing.Point(531, 64);
            this.btnFindDstFolder.Name = "btnFindDstFolder";
            this.btnFindDstFolder.Size = new System.Drawing.Size(24, 23);
            this.btnFindDstFolder.TabIndex = 12;
            this.btnFindDstFolder.Text = "...";
            this.btnFindDstFolder.UseVisualStyleBackColor = true;
            this.btnFindDstFolder.Click += new System.EventHandler(this.btnFindDstFolder_Click);
            // 
            // btnFindSrcFolder
            // 
            this.btnFindSrcFolder.Location = new System.Drawing.Point(531, 21);
            this.btnFindSrcFolder.Name = "btnFindSrcFolder";
            this.btnFindSrcFolder.Size = new System.Drawing.Size(24, 23);
            this.btnFindSrcFolder.TabIndex = 11;
            this.btnFindSrcFolder.Text = "...";
            this.btnFindSrcFolder.UseVisualStyleBackColor = true;
            this.btnFindSrcFolder.Click += new System.EventHandler(this.btnFindSrcFolder_Click);
            // 
            // txtDstFolder
            // 
            this.txtDstFolder.Location = new System.Drawing.Point(120, 61);
            this.txtDstFolder.Multiline = true;
            this.txtDstFolder.Name = "txtDstFolder";
            this.txtDstFolder.Size = new System.Drawing.Size(405, 31);
            this.txtDstFolder.TabIndex = 10;
            // 
            // lblDstFolder
            // 
            this.lblDstFolder.AutoSize = true;
            this.lblDstFolder.Location = new System.Drawing.Point(15, 64);
            this.lblDstFolder.Name = "lblDstFolder";
            this.lblDstFolder.Size = new System.Drawing.Size(99, 13);
            this.lblDstFolder.TabIndex = 9;
            this.lblDstFolder.Text = "Directorio de origen";
            // 
            // txtSrcFolder
            // 
            this.txtSrcFolder.Location = new System.Drawing.Point(120, 18);
            this.txtSrcFolder.Multiline = true;
            this.txtSrcFolder.Name = "txtSrcFolder";
            this.txtSrcFolder.Size = new System.Drawing.Size(405, 31);
            this.txtSrcFolder.TabIndex = 8;
            // 
            // lblSrcFolder
            // 
            this.lblSrcFolder.AutoSize = true;
            this.lblSrcFolder.Location = new System.Drawing.Point(15, 21);
            this.lblSrcFolder.Name = "lblSrcFolder";
            this.lblSrcFolder.Size = new System.Drawing.Size(99, 13);
            this.lblSrcFolder.TabIndex = 7;
            this.lblSrcFolder.Text = "Directorio de origen";
            // 
            // SyncFoldersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 377);
            this.Controls.Add(this.grpFolders);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTraces);
            this.Controls.Add(this.txtTraces);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SyncFoldersForm";
            this.ShowIcon = false;
            this.Text = "SINCRONIZACIÓN DE DIRECTORIOS";
            this.grpFolders.ResumeLayout(false);
            this.grpFolders.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTraces;
        private System.Windows.Forms.Label lblTraces;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpFolders;
        private System.Windows.Forms.Button btnIntercambio;
        private System.Windows.Forms.Button btnFindDstFolder;
        private System.Windows.Forms.Button btnFindSrcFolder;
        private System.Windows.Forms.TextBox txtDstFolder;
        private System.Windows.Forms.Label lblDstFolder;
        private System.Windows.Forms.TextBox txtSrcFolder;
        private System.Windows.Forms.Label lblSrcFolder;
    }
}

