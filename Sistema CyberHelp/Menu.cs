using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CyberHelp
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        public string Empresa { get; set; }
        public string Administrador { get; set; }
        public void FormMenu_Load(object sender, EventArgs e)
        {
            // Carregar as informações da Empresa
            if (!this.Empresa.Equals(""))
            {
                buscarLogin(Convert.ToInt32(this.Empresa));
            }

            if (!this.Administrador.Equals("Nenhum"))
            {
                buscarAdm(Convert.ToInt32(this.Administrador));
            }
        }
        private void buscarLogin(int id)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select empresa from usuario where idEmpresa={id}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read()) // Verificar se tem alguma linha com o dado fornecido (login)
                {
                    labelEmpresa.Text = linhas["empresa"].ToString();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();
            }
        }

        private void buscarAdm(int id)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select nome from administrador where idAdm={id} and idEmpresa={Convert.ToString(this.Empresa)}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read()) // Verificar se tem alguma linha com o dado fornecido
                {
                    labelNomeAdm.Text = linhas["nome"].ToString();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();
            }
        }


        private void AdicionarImagem(object sender, EventArgs e)
        {
            if (verificarAdm() == 0)
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|AllFiles(*.*)|*.*";

                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    string foto = dialog.FileName.ToString();
                    pictureBoxImagem.ImageLocation = foto;
                }
            }
        }

        private void abrirFinanceiro(object sender, EventArgs e)
        {
            if (verificarAdm() == 0)
            {
                Financeiro FormFinanceiro = new Financeiro();
                FormFinanceiro.Administrador = this.Administrador;
                FormFinanceiro.Empresa = this.Empresa;
                FormFinanceiro.Show();
                this.Close();
            }
        }

        private void abrirEstoque(object sender, EventArgs e)
        {
            if (verificarAdm() == 0)
            {
                Estoque FormEstoque = new Estoque();
                FormEstoque.Empresa = this.Empresa;
                FormEstoque.Administrador = this.Administrador;
                FormEstoque.Show();
                this.Close();
            }
        }

        private void abrirCadastroCliente(object sender, EventArgs e)
        {
            if (verificarAdm() == 0)
            {
                CadastroCliente FormClientes = new CadastroCliente();
                FormClientes.idEmpresa = this.Empresa;
                FormClientes.idAdministrador = this.Administrador;
                FormClientes.nomeEmpresa = labelEmpresa.Text;
                FormClientes.nomeAdministrador = labelNomeAdm.Text;
                FormClientes.Show();
                this.Close();
            }
        }

        private void abrirPedidos(object sender, EventArgs e)
        {
            if (verificarAdm() == 0)
            {
                Pedidos FormPedidos = new Pedidos();
                FormPedidos.Empresa = this.Empresa;
                FormPedidos.Administrador = this.Administrador;
                FormPedidos.Show();
                this.Close();
            }
        }

        private void mudarAdm(object sender, EventArgs e)
        {
            Administradores FormAdm = new Administradores(labelEmpresa.Text);
            FormAdm.Empresa = this.Empresa;
            FormAdm.Administrador = this.Administrador;
            FormAdm.Show();
            this.Dispose();
        }

        private void fazerLogout(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja sair?", "Realizar Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
        }
        
        private int verificarAdm()
        {
            if (labelNomeAdm.Text.Equals(""))
            { // Caso não tenha ADM
                MessageBox.Show("É necessário identificar o Administrador antes de realizar alguma ação!");
                return 1;
            }
            else return 0;
        }

    }
}
