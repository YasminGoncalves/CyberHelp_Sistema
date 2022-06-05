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
    public partial class CamposFinanceiro : Form
    {

        public CamposFinanceiro()
        {
            InitializeComponent();
            buttonAdicionar.Visible = false;
            buttonExcluir.Visible = false;
        }

        public string Empresa { get; set; }
        public string Adm { get; set; }
        public string acao { get; set; }
        public string financa { get; set; }

        private void Buscar()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
            string sql = $"select * from financas where id={this.financa}";
            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read())
                {
                    textBoxId.Text = linhas["id"].ToString();
                    textBoxData.Text = linhas["data"].ToString();
                    textBoxTipo.Text = linhas["tipo"].ToString();
                    textBoxDescricao.Text = linhas["descricao"].ToString();
                    textBoxValor.Text = linhas["valor"].ToString();
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

        private void CamposFinanceiro_Load(object sender, EventArgs e)
        {
            if (!this.acao.Equals("Incluir")) Buscar();

            if (this.acao.Equals("Incluir"))
            {
                labelAcao.Text = "Adicionar Entrada/Saída";
                buttonAdicionar.Visible = true;
            }
            else
            {
                labelAcao.Text = "Excluir Entrada/Saída";
                buttonExcluir.Visible = true;
            }
        }
        private void Finalizar()
        {
            Financeiro financeiro = new Financeiro();
            financeiro.Empresa = this.Empresa;
            financeiro.Administrador = this.Adm;
            financeiro.Show();
            this.Close();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"delete from financas where id={Convert.ToInt32(this.financa)}";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Entrada/Saída excluída com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao tentar excluir, tente novamente!");

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
            Finalizar();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            // Mudar
            string comandoSql = $"insert into financas (id, data, tipo, descricao, valor, idEmpresa, idAdm) values " +
               $"(NULL, '{textBoxData.Text}', '{textBoxTipo.Text}', '{textBoxDescricao.Text}', {textBoxValor.Text},{Convert.ToInt32(this.Empresa)}, {Convert.ToInt32(this.Adm)})";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Produto cadastrado com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao adicionar o produto, tente novamente!");

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
            Finalizar();
        }
    }
}
