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
    public partial class CamposEstoque : Form
    {
        public CamposEstoque()
        {
            InitializeComponent();
        }

        public string Empresa { get; set; }

        public string Produto { get; set; }

        public string acao { get; set; }

        public string Administrador { get; set; }
        private void BuscarProduto()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
            string sql = $"select * from produto where codigoProduto={this.Produto}";
            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read())
                {
                    textBoxId.Text = linhas["codigoProduto"].ToString();
                    textBoxProduto.Text = linhas["descricao"].ToString();
                    textBoxQuant.Text = linhas["quantidade"].ToString();
                    textBoxValorUni.Text = linhas["valor"].ToString();
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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"insert into produto (codigoProduto, descricao, quantidade, valor, idEmpresa) values " +
               $"(NULL, '{textBoxProduto.Text}', '{textBoxQuant.Text}', {textBoxValorUni.Text}, {Convert.ToInt32(this.Empresa)})";

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
                Finalizar();
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"delete from produto where codigoProduto={Convert.ToInt32(this.Produto)}";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Produto excluído com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao tentar excluir o produto, tente novamente!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();
                Finalizar();
            }
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"UPDATE produto SET descricao= '{textBoxProduto.Text}', quantidade = {textBoxQuant.Text}, valor = {textBoxValorUni.Text} WHERE codigoProduto = {Convert.ToInt32(this.Produto)}";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Produto atualizado com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao atualizar o produto, tente novamente!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Ocorreu o seguinte erro: " + erro);
            }
            finally
            {
                comando.Dispose();
                conexao.Close();
                Finalizar();
            }
        }

        private void Finalizar()
        {
            Estoque estoque = new Estoque();
            estoque.Administrador = this.Administrador;
            estoque.Empresa = this.Empresa;
            estoque.Show();
            this.Close();
        }

        private void CamposEstoque_Load(object sender, EventArgs e)
        {
            if (!this.acao.Equals("Incluir")) BuscarProduto();

            if (this.acao.Equals("Incluir"))
            {
                labelAcao.Text = "Incluir produto/item";
                buttonAdicionar.Visible = true;
            }
            else if (this.acao.Equals("Excluir"))
            {
                labelAcao.Text = "Excluir produto/item";
                buttonExcluir.Visible = true;
            }
            else if(this.acao.Equals("Alterar"))
            {
                labelAcao.Text = "Alterar produto/item";
                buttonAlterar.Visible = true;
            }
        }
    }
}
