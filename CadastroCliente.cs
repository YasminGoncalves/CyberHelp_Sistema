using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CyberHelp
{
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
        {
            InitializeComponent();

        }

        public string idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public string idAdministrador { get; set; }
        public string nomeAdministrador { get; set; }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {
            BuscarClientes();
            labelEmpresa.Text = this.nomeEmpresa;
            labelAdm.Text = this.nomeAdministrador;
        }

        public void BuscarClientes()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
            string sql = $"select * from cliente where empresa={this.idEmpresa}";
            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                DataTable tabelaCliente = new DataTable();

                tabelaCliente.Columns.Add("Número Cliente").ReadOnly = true;
                tabelaCliente.Columns.Add("Nome");
                tabelaCliente.Columns.Add("Telefone");
                tabelaCliente.Columns.Add("Endereço");

                while (linhas.Read())
                {
                    DataRow linha = tabelaCliente.NewRow();
                    linha[0] = linhas["idCliente"];
                    linha[1] = linhas["nome"];
                    linha[2] = linhas["telefone"];
                    linha[3] = linhas["endereco"];

                    tabelaCliente.Rows.Add(linha);
                }

                dataGridViewClientes.DataSource = tabelaCliente;
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

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            CamposCadastro cadastro = new CamposCadastro();
            cadastro.acao = "Adicionar 2";
            cadastro.idEmpresa = this.idEmpresa;
            cadastro.nomeEmpresa = this.labelEmpresa.Text;
            cadastro.nomeAdministrador = this.nomeAdministrador;
            cadastro.idAdministrador = this.idAdministrador;
            cadastro.Show();
            this.Close();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            CamposCadastro cadastro = new CamposCadastro();
            cadastro.acao = "Excluir 2";
            cadastro.idEmpresa = this.idEmpresa;
            cadastro.idAdministrador = this.idAdministrador;
            cadastro.nomeEmpresa = labelEmpresa.Text;
            cadastro.nomeAdministrador = labelAdm.Text;
            cadastro.cliente = dataGridViewClientes.CurrentRow.Cells[0].Value.ToString();
            cadastro.Show();
            this.Close();
        }

        private void textBoxBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Caso o usuário aperte enter
            if (e.KeyChar == 13)
            {
                if (textBoxBusca.Text.Equals(""))
                {
                    BuscarClientes();
                }
                else
                {
                    MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
                    string sql = $"select * from cliente where empresa={this.idEmpresa} and nome='{textBoxBusca.Text}'";
                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    try
                    {
                        conexao.Open();
                        MySqlDataReader linhas = comando.ExecuteReader();

                        DataTable tabelaCliente = new DataTable();

                        tabelaCliente.Columns.Add("Número Cliente").ReadOnly = true;
                        tabelaCliente.Columns.Add("Nome");
                        tabelaCliente.Columns.Add("Telefone");
                        tabelaCliente.Columns.Add("Endereço");

                        while (linhas.Read())
                        {
                            DataRow linha = tabelaCliente.NewRow();
                            linha[0] = linhas["idCliente"];
                            linha[1] = linhas["nome"];
                            linha[2] = linhas["telefone"];
                            linha[3] = linhas["endereco"];

                            tabelaCliente.Rows.Add(linha);
                        }

                        dataGridViewClientes.DataSource = tabelaCliente;
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
            }
        }

        private void labelVoltar_Click(object sender, EventArgs e)
        {
            // Rever
            FormMenu menu = new FormMenu();
            menu.Administrador = this.idAdministrador;
            menu.Empresa = this.idEmpresa;
            menu.Show();
            this.Close();
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            CamposCadastro cadastro = new CamposCadastro();
            cadastro.acao = "Alterar 2";
            cadastro.idEmpresa = this.idEmpresa;
            cadastro.idAdministrador = this.idAdministrador;
            cadastro.nomeEmpresa = labelEmpresa.Text;
            cadastro.nomeAdministrador = labelAdm.Text;
            cadastro.cliente = dataGridViewClientes.CurrentRow.Cells[0].Value.ToString();
            cadastro.Show();
            this.Close();
        }
    }
}
