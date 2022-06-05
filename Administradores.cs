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
    public partial class Administradores : Form
    {
        public Administradores(string empresa)
        {
            InitializeComponent();
            labelEmpresa.Text = empresa;
            buscarInformacoes();
        }

        public string Empresa { get; set; }
        public string Administrador { get; set; }

        private void buscarInformacoes()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select * from administrador where idEmpresa={Convert.ToInt32(this.Empresa)}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                DataTable tabelaAdm = new DataTable();

                tabelaAdm.Columns.Add("Id").ReadOnly = true;
                tabelaAdm.Columns.Add("Nome");
                tabelaAdm.Columns.Add("Email");

                while (linhas.Read())
                {
                    DataRow linha = tabelaAdm.NewRow();
                    linha[0] = linhas["idAdm"];
                    linha[1] = linhas["nome"];
                    linha[2] = linhas["email"];

                    tabelaAdm.Rows.Add(linha);
                }

                dataGridViewAdm.DataSource = tabelaAdm;
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

        private void textBoxBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Caso o usuário aperte enter
            if(e.KeyChar == 13)
            {
                if (textBoxBusca.Text.Equals(""))
                {
                    buscarInformacoes();
                }
                else
                {
                    MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

                    string sql = $"select * from administrador where idEmpresa={Convert.ToInt32(this.Empresa)} and idAdm='{Convert.ToInt32(textBoxBusca.Text)}'";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    try
                    {
                        conexao.Open();
                        MySqlDataReader linhas = comando.ExecuteReader();

                        DataTable tabelaAdm = new DataTable();

                        tabelaAdm.Columns.Add("Id").ReadOnly = true;
                        tabelaAdm.Columns.Add("Nome");
                        tabelaAdm.Columns.Add("Email");

                        while (linhas.Read())
                        {
                            DataRow linha = tabelaAdm.NewRow();
                            linha[0] = linhas["idAdm"];
                            linha[1] = linhas["nome"];
                            linha[2] = linhas["email"];

                            tabelaAdm.Rows.Add(linha);
                        }

                        dataGridViewAdm.DataSource = tabelaAdm;
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

        private void Selecionar(object sender, EventArgs e)
        {
            LogarADM formLogarAdm = new LogarADM();
            formLogarAdm.Administrador = dataGridViewAdm.CurrentRow.Cells[0].Value.ToString();
            formLogarAdm.Empresa = this.Empresa;
            formLogarAdm.Show();
            this.Close();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            CamposCadastro camposCadastro = new CamposCadastro();
            camposCadastro.acao = "Adicionar 1";
            camposCadastro.idEmpresa = this.Empresa;
            camposCadastro.nomeEmpresa = labelEmpresa.Text;
            camposCadastro.Show();
            this.Close();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            CamposCadastro camposCadastro = new CamposCadastro();
            camposCadastro.acao = "Excluir 1";
            camposCadastro.idEmpresa = this.Empresa;
            camposCadastro.nomeEmpresa = labelEmpresa.Text;
            camposCadastro.idAdministrador = dataGridViewAdm.CurrentRow.Cells[0].Value.ToString();
            camposCadastro.Show();
            this.Close();
        }

        private void Administradores_Load(object sender, EventArgs e)
        {
            buscarInformacoes();
        }
    }
}
