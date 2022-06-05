
namespace CyberHelp
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonImagem = new System.Windows.Forms.Button();
            this.buttonAdm = new System.Windows.Forms.Button();
            this.buttonSair = new System.Windows.Forms.Button();
            this.labelFinanceiro = new System.Windows.Forms.Label();
            this.labelPedidos = new System.Windows.Forms.Label();
            this.labelEstoque = new System.Windows.Forms.Label();
            this.labelCadastroCliente = new System.Windows.Forms.Label();
            this.labelNomeAdm = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxCadastroCliente = new System.Windows.Forms.PictureBox();
            this.pictureBoxEstoque = new System.Windows.Forms.PictureBox();
            this.pictureBoxPedidos = new System.Windows.Forms.PictureBox();
            this.pictureBoxFinanceiro = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxImagem = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelEmpresa = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCadastroCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFinanceiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImagem
            // 
            this.buttonImagem.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImagem.Location = new System.Drawing.Point(29, 226);
            this.buttonImagem.Name = "buttonImagem";
            this.buttonImagem.Size = new System.Drawing.Size(279, 40);
            this.buttonImagem.TabIndex = 2;
            this.buttonImagem.Text = "Mudar imagem";
            this.buttonImagem.UseVisualStyleBackColor = true;
            this.buttonImagem.Click += new System.EventHandler(this.AdicionarImagem);
            // 
            // buttonAdm
            // 
            this.buttonAdm.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdm.Location = new System.Drawing.Point(29, 272);
            this.buttonAdm.Name = "buttonAdm";
            this.buttonAdm.Size = new System.Drawing.Size(279, 40);
            this.buttonAdm.TabIndex = 3;
            this.buttonAdm.Text = "Adicionar/Mudar Administrador";
            this.buttonAdm.UseVisualStyleBackColor = true;
            this.buttonAdm.Click += new System.EventHandler(this.mudarAdm);
            // 
            // buttonSair
            // 
            this.buttonSair.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSair.Location = new System.Drawing.Point(29, 318);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(279, 40);
            this.buttonSair.TabIndex = 4;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = true;
            this.buttonSair.Click += new System.EventHandler(this.fazerLogout);
            // 
            // labelFinanceiro
            // 
            this.labelFinanceiro.AutoSize = true;
            this.labelFinanceiro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelFinanceiro.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFinanceiro.Location = new System.Drawing.Point(536, 52);
            this.labelFinanceiro.Name = "labelFinanceiro";
            this.labelFinanceiro.Size = new System.Drawing.Size(72, 16);
            this.labelFinanceiro.TabIndex = 6;
            this.labelFinanceiro.Text = "Financeiro";
            this.labelFinanceiro.Click += new System.EventHandler(this.abrirFinanceiro);
            // 
            // labelPedidos
            // 
            this.labelPedidos.AutoSize = true;
            this.labelPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelPedidos.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPedidos.Location = new System.Drawing.Point(786, 52);
            this.labelPedidos.Name = "labelPedidos";
            this.labelPedidos.Size = new System.Drawing.Size(57, 16);
            this.labelPedidos.TabIndex = 7;
            this.labelPedidos.Text = "Pedidos";
            this.labelPedidos.Click += new System.EventHandler(this.abrirPedidos);
            // 
            // labelEstoque
            // 
            this.labelEstoque.AutoSize = true;
            this.labelEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEstoque.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstoque.Location = new System.Drawing.Point(536, 272);
            this.labelEstoque.Name = "labelEstoque";
            this.labelEstoque.Size = new System.Drawing.Size(57, 16);
            this.labelEstoque.TabIndex = 8;
            this.labelEstoque.Text = "Estoque";
            this.labelEstoque.Click += new System.EventHandler(this.abrirEstoque);
            // 
            // labelCadastroCliente
            // 
            this.labelCadastroCliente.AutoSize = true;
            this.labelCadastroCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCadastroCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCadastroCliente.Location = new System.Drawing.Point(752, 276);
            this.labelCadastroCliente.Name = "labelCadastroCliente";
            this.labelCadastroCliente.Size = new System.Drawing.Size(128, 16);
            this.labelCadastroCliente.TabIndex = 9;
            this.labelCadastroCliente.Text = "Cadastro de Cliente";
            this.labelCadastroCliente.Click += new System.EventHandler(this.abrirCadastroCliente);
            // 
            // labelNomeAdm
            // 
            this.labelNomeAdm.AutoSize = true;
            this.labelNomeAdm.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelNomeAdm.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomeAdm.Location = new System.Drawing.Point(144, 181);
            this.labelNomeAdm.Name = "labelNomeAdm";
            this.labelNomeAdm.Size = new System.Drawing.Size(0, 16);
            this.labelNomeAdm.TabIndex = 14;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBoxCadastroCliente
            // 
            this.pictureBoxCadastroCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCadastroCliente.Image = global::CyberHelp.Properties.Resources.Cliente;
            this.pictureBoxCadastroCliente.Location = new System.Drawing.Point(745, 303);
            this.pictureBoxCadastroCliente.Name = "pictureBoxCadastroCliente";
            this.pictureBoxCadastroCliente.Size = new System.Drawing.Size(140, 128);
            this.pictureBoxCadastroCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCadastroCliente.TabIndex = 13;
            this.pictureBoxCadastroCliente.TabStop = false;
            this.pictureBoxCadastroCliente.Click += new System.EventHandler(this.abrirCadastroCliente);
            // 
            // pictureBoxEstoque
            // 
            this.pictureBoxEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxEstoque.Image = global::CyberHelp.Properties.Resources.Estoque;
            this.pictureBoxEstoque.Location = new System.Drawing.Point(508, 302);
            this.pictureBoxEstoque.Name = "pictureBoxEstoque";
            this.pictureBoxEstoque.Size = new System.Drawing.Size(140, 128);
            this.pictureBoxEstoque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEstoque.TabIndex = 12;
            this.pictureBoxEstoque.TabStop = false;
            this.pictureBoxEstoque.Click += new System.EventHandler(this.abrirEstoque);
            // 
            // pictureBoxPedidos
            // 
            this.pictureBoxPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPedidos.Image = global::CyberHelp.Properties.Resources.Pedido;
            this.pictureBoxPedidos.Location = new System.Drawing.Point(745, 92);
            this.pictureBoxPedidos.Name = "pictureBoxPedidos";
            this.pictureBoxPedidos.Size = new System.Drawing.Size(140, 128);
            this.pictureBoxPedidos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxPedidos.TabIndex = 11;
            this.pictureBoxPedidos.TabStop = false;
            this.pictureBoxPedidos.Click += new System.EventHandler(this.abrirPedidos);
            // 
            // pictureBoxFinanceiro
            // 
            this.pictureBoxFinanceiro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxFinanceiro.Image = global::CyberHelp.Properties.Resources.Financeiro;
            this.pictureBoxFinanceiro.Location = new System.Drawing.Point(508, 92);
            this.pictureBoxFinanceiro.Name = "pictureBoxFinanceiro";
            this.pictureBoxFinanceiro.Size = new System.Drawing.Size(140, 128);
            this.pictureBoxFinanceiro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFinanceiro.TabIndex = 10;
            this.pictureBoxFinanceiro.TabStop = false;
            this.pictureBoxFinanceiro.Click += new System.EventHandler(this.abrirFinanceiro);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureBox3.Image = global::CyberHelp.Properties.Resources.Logo_cyberhelp;
            this.pictureBox3.Location = new System.Drawing.Point(120, 407);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 71);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBoxImagem
            // 
            this.pictureBoxImagem.Location = new System.Drawing.Point(89, 35);
            this.pictureBoxImagem.Name = "pictureBoxImagem";
            this.pictureBoxImagem.Size = new System.Drawing.Size(154, 133);
            this.pictureBoxImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImagem.TabIndex = 1;
            this.pictureBoxImagem.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 491);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.AutoSize = true;
            this.labelEmpresa.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelEmpresa.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmpresa.Location = new System.Drawing.Point(128, 11);
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(60, 16);
            this.labelEmpresa.TabIndex = 15;
            this.labelEmpresa.Text = "Empresa";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelID.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.Location = new System.Drawing.Point(12, 11);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(20, 16);
            this.labelID.TabIndex = 16;
            this.labelID.Text = "id";
            this.labelID.Visible = false;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 490);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelEmpresa);
            this.Controls.Add(this.labelNomeAdm);
            this.Controls.Add(this.pictureBoxCadastroCliente);
            this.Controls.Add(this.pictureBoxEstoque);
            this.Controls.Add(this.pictureBoxPedidos);
            this.Controls.Add(this.pictureBoxFinanceiro);
            this.Controls.Add(this.labelCadastroCliente);
            this.Controls.Add(this.labelEstoque);
            this.Controls.Add(this.labelPedidos);
            this.Controls.Add(this.labelFinanceiro);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.buttonAdm);
            this.Controls.Add(this.buttonImagem);
            this.Controls.Add(this.pictureBoxImagem);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCadastroCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFinanceiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxImagem;
        private System.Windows.Forms.Button buttonImagem;
        private System.Windows.Forms.Button buttonAdm;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelFinanceiro;
        private System.Windows.Forms.Label labelPedidos;
        private System.Windows.Forms.Label labelEstoque;
        private System.Windows.Forms.Label labelCadastroCliente;
        private System.Windows.Forms.PictureBox pictureBoxFinanceiro;
        private System.Windows.Forms.PictureBox pictureBoxPedidos;
        private System.Windows.Forms.PictureBox pictureBoxEstoque;
        private System.Windows.Forms.PictureBox pictureBoxCadastroCliente;
        private System.Windows.Forms.Label labelNomeAdm;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelEmpresa;
        private System.Windows.Forms.Label labelID;
    }
}