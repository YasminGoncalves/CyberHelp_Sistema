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
    public partial class Vendas : Form
    {
        public Vendas()
        {
            InitializeComponent();
        }
        public string Empresa { get; set; }
        public string Administrador { get; set; }

        private void atualizar()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select * from venda where idEmpresa={this.Empresa}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                DataTable tabelaVendas = new DataTable();

                tabelaVendas.Columns.Add("Código").ReadOnly = true;
                tabelaVendas.Columns.Add("Data");
                tabelaVendas.Columns.Add("Valor");
                tabelaVendas.Columns.Add("Bandeira");
                tabelaVendas.Columns.Add("Parcelas");
                tabelaVendas.Columns.Add("Valor Líquido");
                tabelaVendas.Columns.Add("Taxa");

                while (linhas.Read())
                {
                    DataRow linha = tabelaVendas.NewRow();
                    linha[0] = linhas["idVenda"];
                    linha[1] = linhas["data"];
                    linha[2] = linhas["valor"];
                    linha[3] = linhas["bandeira"];
                    linha[4] = linhas["parcelas"];
                    linha[5] = linhas["valorLiq"];
                    linha[6] = linhas["taxa"];

                    tabelaVendas.Rows.Add(linha);
                }

                dataGridViewVendas.DataSource = tabelaVendas;
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

        private void Vendas_Load(object sender, EventArgs e)
        {
            atualizar();
            BuscarAdm();
            BuscarEmpresa();
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

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            CamposVendas camposVendas = new CamposVendas();
            camposVendas.acao = "Alterar";
            camposVendas.Empresa = this.Empresa;
            camposVendas.idAdm = this.Administrador;
            camposVendas.Venda = dataGridViewVendas.CurrentRow.Cells[0].Value.ToString();
            camposVendas.Show();
            this.Close();
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            CamposVendas camposVendas = new CamposVendas();
            camposVendas.acao = "Incluir";
            camposVendas.Empresa = this.Empresa;
            camposVendas.idAdm = this.Administrador;
            camposVendas.Show();
            this.Close();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            CamposVendas camposVendas = new CamposVendas();
            camposVendas.acao = "Excluir";
            camposVendas.Empresa = this.Empresa;
            camposVendas.idAdm = this.Administrador;
            camposVendas.Venda = dataGridViewVendas.CurrentRow.Cells[0].Value.ToString();
            camposVendas.Show();
            this.Close();
        }

        private void labelVoltar_Click(object sender, EventArgs e)
        {
            Financeiro financeiro = new Financeiro();
            financeiro.Administrador = this.Administrador;
            financeiro.Empresa = this.Empresa;
            financeiro.Show();
            this.Close();
        }

        private void textBoxBusca_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Caso o usuário aperte enter
            if (e.KeyChar == 13)
            {
                if (textBoxBusca.Text.Equals(""))
                {
                    atualizar();
                }
                else
                {
                    MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

                    string sql = $"select * from venda where idEmpresa={this.Empresa} and data='{textBoxBusca.Text}'";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    try
                    {
                        conexao.Open();
                        MySqlDataReader linhas = comando.ExecuteReader();

                        DataTable tabelaVendas = new DataTable();

                        tabelaVendas.Columns.Add("Código").ReadOnly = true;
                        tabelaVendas.Columns.Add("Data");
                        tabelaVendas.Columns.Add("Valor");
                        tabelaVendas.Columns.Add("Bandeira");
                        tabelaVendas.Columns.Add("Parcelas");
                        tabelaVendas.Columns.Add("Valor Líquido");
                        tabelaVendas.Columns.Add("Taxa");

                        while (linhas.Read())
                        {
                            DataRow linha = tabelaVendas.NewRow();
                            linha[0] = linhas["idVenda"];
                            linha[1] = linhas["data"];
                            linha[2] = linhas["valor"];
                            linha[3] = linhas["bandeira"];
                            linha[4] = linhas["parcelas"];
                            linha[5] = linhas["valorLiq"];
                            linha[6] = linhas["taxa"];
                            linha[7] = linhas["idEmpresa"];

                            tabelaVendas.Rows.Add(linha);
                        }

                        dataGridViewVendas.DataSource = tabelaVendas;
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
