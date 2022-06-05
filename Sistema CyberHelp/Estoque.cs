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
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();
        }

        public string Empresa { get; set; }
        public string Administrador { get; set; }

        private void atualizarEstoque()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select * from produto where idEmpresa={this.Empresa}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                DataTable tabelaEstoque = new DataTable();

                tabelaEstoque.Columns.Add("Código").ReadOnly = true;
                tabelaEstoque.Columns.Add("Descricão");
                tabelaEstoque.Columns.Add("Quantidade");
                tabelaEstoque.Columns.Add("Valor");

                while (linhas.Read())
                {
                    DataRow linha = tabelaEstoque.NewRow();
                    linha[0] = linhas["codigoProduto"];
                    linha[1] = linhas["descricao"];
                    linha[2] = linhas["quantidade"];
                    linha[3] = linhas["valor"];

                    tabelaEstoque.Rows.Add(linha);
                }

                dataGridViewEstoque.DataSource = tabelaEstoque;
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

        private void BuscarEmpresa()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select empresa from usuario where idEmpresa={Convert.ToInt32(this.Empresa)}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read())
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

        private void BuscarAdm()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select nome from administrador where idAdm={Convert.ToInt32(this.Administrador)}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read())
                {
                    labelAdm.Text = linhas["nome"].ToString();
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

        private void Form4_Load(object sender, EventArgs e)
        {
            atualizarEstoque();
            BuscarAdm();
            BuscarEmpresa();
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            CamposEstoque camposEstoque = new CamposEstoque();
            camposEstoque.acao = "Alterar";
            camposEstoque.Empresa = this.Empresa;
            camposEstoque.Produto = dataGridViewEstoque.CurrentRow.Cells[0].Value.ToString();
            camposEstoque.Administrador = this.Administrador;
            camposEstoque.Show();
            this.Close();
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            CamposEstoque camposEstoque = new CamposEstoque();
            camposEstoque.acao = "Incluir";
            camposEstoque.Empresa = this.Empresa;
            camposEstoque.Administrador = this.Administrador;
            camposEstoque.Show();
            this.Close();
        }

        private void labelVoltar_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Administrador = this.Administrador;
            menu.Empresa = this.Empresa;
            menu.Show();
            this.Close();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            CamposEstoque camposEstoque = new CamposEstoque();
            camposEstoque.acao = "Excluir";
            camposEstoque.Empresa = this.Empresa;
            camposEstoque.Produto = dataGridViewEstoque.CurrentRow.Cells[0].Value.ToString();
            camposEstoque.Administrador = this.Administrador;
            camposEstoque.Show();
            this.Close();
        }

        private void textBoxBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Caso o usuário aperte enter
            if (e.KeyChar == 13)
            {
                if (textBoxBusca.Text.Equals(""))
                {
                    atualizarEstoque();
                }
                else
                {
                    MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

                    string sql = $"select * from produto where idEmpresa={this.Empresa} and descricao='{textBoxBusca.Text}'";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    try
                    {
                        conexao.Open();
                        MySqlDataReader linhas = comando.ExecuteReader();

                        DataTable tabelaEstoque = new DataTable();

                        tabelaEstoque.Columns.Add("Código").ReadOnly = true;
                        tabelaEstoque.Columns.Add("Descricão");
                        tabelaEstoque.Columns.Add("Quantidade");
                        tabelaEstoque.Columns.Add("Valor");

                        while (linhas.Read())
                        {
                            DataRow linha = tabelaEstoque.NewRow();
                            linha[0] = linhas["codigoProduto"];
                            linha[1] = linhas["descricao"];
                            linha[2] = linhas["quantidade"];
                            linha[3] = linhas["valor"];

                            tabelaEstoque.Rows.Add(linha);
                        }

                        dataGridViewEstoque.DataSource = tabelaEstoque;
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
    }
}
