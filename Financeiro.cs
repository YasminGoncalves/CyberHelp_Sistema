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
    public partial class Financeiro : Form
    {
        public Financeiro()
        {
            InitializeComponent();
        }
        public string Empresa { get; set; }
        public string Administrador { get; set; }

        private void atualizar()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select * from financas where idEmpresa={Convert.ToInt32(this.Empresa)}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();
                DataTable tabelaFinanceiro = new DataTable();

                tabelaFinanceiro.Columns.Add("Código").ReadOnly = true;
                tabelaFinanceiro.Columns.Add("Data");
                tabelaFinanceiro.Columns.Add("Tipo");
                tabelaFinanceiro.Columns.Add("Descricao");
                tabelaFinanceiro.Columns.Add("Valor");

                while (linhas.Read())
                {
                    DataRow linha = tabelaFinanceiro.NewRow();
                    linha[0] = linhas["id"];
                    linha[1] = linhas["data"];
                    linha[2] = linhas["tipo"];
                    linha[3] = linhas["descricao"];
                    linha[4] = linhas["valor"];

                    tabelaFinanceiro.Rows.Add(linha);
                }

                dataGridViewFinanceiro.DataSource = tabelaFinanceiro;
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

        private void buscarObs()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $"select * from observacaofinancas where idEmpresa={Convert.ToInt32(this.Empresa)}";

            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                while (linhas.Read())
                {
                    richTextBoxObs.Text = linhas["observacao"].ToString();
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

        private void abrirVendas(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Vendas formVendas = new Vendas();
            formVendas.Empresa = this.Empresa;
            formVendas.Administrador = this.Administrador;
            formVendas.Show();
            this.Visible = false;
        }

        private void Incluir(object sender, EventArgs e)
        {
            CamposFinanceiro cf = new CamposFinanceiro();
            cf.acao = "Incluir";
            cf.Empresa = this.Empresa;
            cf.Adm = this.Administrador;
            cf.Show();
            this.Close();
        }

        private void Excluir(object sender, EventArgs e)
        {
            CamposFinanceiro cf = new CamposFinanceiro();
            cf.acao = "Excluir";
            cf.Empresa = this.Empresa;
            cf.Adm = this.Administrador;
            cf.financa = dataGridViewFinanceiro.CurrentRow.Cells[0].Value.ToString();
            cf.Show();
            this.Close();
        }

        private void Financeiro_Load(object sender, EventArgs e)
        {
            atualizar();
            BuscarAdm();
            buscarObs();
            BuscarEmpresa();

            if (DateTime.Now.Day < 10)
            {
                string dia = DateTime.Now.Day.ToString();
                labelDia.Text = "0" + dia;
            }
            

            if(DateTime.Now.Month < 10)
            {
                string mes = DateTime.Now.Month.ToString();

                labelMes.Text = "0" + mes;
            }
            labelAno.Text = DateTime.Now.Year.ToString();

        }

        private void labelVoltar_Click(object sender, EventArgs e)
        {
            FormMenu menu = new FormMenu();
            menu.Administrador = this.Administrador;
            menu.Empresa = this.Empresa;
            menu.Show();
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

                    string sql = $"select * from financas where idEmpresa={Convert.ToInt32(this.Empresa)} and data='{textBoxBusca.Text}'";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);

                    try
                    {
                        conexao.Open();
                        MySqlDataReader linhas = comando.ExecuteReader();
                        DataTable tabelaFinanceiro = new DataTable();

                        tabelaFinanceiro.Columns.Add("Código").ReadOnly = true;
                        tabelaFinanceiro.Columns.Add("Data");
                        tabelaFinanceiro.Columns.Add("Tipo");
                        tabelaFinanceiro.Columns.Add("Descricao");
                        tabelaFinanceiro.Columns.Add("Valor");

                        while (linhas.Read())
                        {
                            DataRow linha = tabelaFinanceiro.NewRow();
                            linha[0] = linhas["id"];
                            linha[1] = linhas["data"];
                            linha[2] = linhas["tipo"];
                            linha[3] = linhas["descricao"];
                            linha[4] = linhas["valor"];

                            tabelaFinanceiro.Rows.Add(linha);
                        }

                        dataGridViewFinanceiro.DataSource = tabelaFinanceiro;
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

        private void atualizarObs()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
            string sql = $" UPDATE `observacaofinancas` SET `observacao` = '{richTextBoxObs.Text}' WHERE idEmpresa={Convert.ToInt32(this.Empresa)}";
            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Observação atualizada com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao atualizar a observação, tente novamente!");

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

        private void adicionarObs()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string sql = $" insert into `observacaofinancas` (`idObs`, `observacao`, `idEmpresa`) values (NULL, '{richTextBoxObs.Text}', {Convert.ToInt32(this.Empresa)})";
            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Observação criada com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao adicionar a observação, tente novamente!");
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

        private void richTextBoxObs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
                string sql = $"select * from observacaofinancas where idEmpresa={this.Empresa}";
                MySqlCommand comando = new MySqlCommand(sql, conexao);

                try
                {
                    conexao.Open();
                    MySqlDataReader linhas = comando.ExecuteReader();

                    if (linhas.Read())
                    {
                        atualizarObs();
                    }
                    else
                    {
                        adicionarObs();
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
        }
    }
}
