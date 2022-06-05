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
    public partial class CamposVendas : Form
    {
        public CamposVendas()
        {
            InitializeComponent();
            buttonAdicionar.Visible = false;
            buttonExcluir.Visible = false;
            buttonAlterar.Visible = false;
        }

        public string Empresa { get; set;}
        public string idAdm { get; set;}
        public string Venda { get; set;}
        public string acao { get; set;}



        private void Buscar()
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");
            string sql = $"select * from venda where idVenda={this.Venda}";
            MySqlCommand comando = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader linhas = comando.ExecuteReader();

                if (linhas.Read())
                {
                    textBoxId.Text = linhas["idVenda"].ToString();
                    textBoxData.Text = linhas["data"].ToString();
                    textBoxValor.Text = linhas["valor"].ToString();
                    textBoxBandeira.Text = linhas["bandeira"].ToString();
                    textBoxParcelas.Text = linhas["parcelas"].ToString();
                    textBoxValorL.Text = linhas["valorLiq"].ToString();
                    textBoxTaxa.Text = linhas["taxa"].ToString();
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
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"UPDATE venda SET data='{textBoxData.Text}', valor= {textBoxValor.Text}, bandeira ='{textBoxBandeira.Text}', parcelas= {textBoxParcelas.Text} , valorLiq= {textBoxValorL.Text}, taxa = {textBoxTaxa.Text} WHERE idVenda={Convert.ToInt32(textBoxId.Text)}";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Venda atualizada com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao atualizar a venda, tente novamente!");

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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=cyberhelp;SslMode=none");

            string comandoSql = $"insert into venda (idVenda, data, valor, bandeira, parcelas, valorLiq, taxa, idEmpresa) values " +
               $"(NULL, '{textBoxData.Text}', {textBoxValor.Text}, '{textBoxBandeira.Text}', {textBoxParcelas.Text}, {textBoxValorL.Text}, {textBoxTaxa.Text}, {Convert.ToInt32(this.Empresa)})";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Venda cadastrada com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao adicionar o venda, tente novamente!");

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

            string comandoSql = $"delete from venda where idVenda={this.Venda}";

            MySqlCommand comando = new MySqlCommand(comandoSql, conexao);

            try
            {
                conexao.Open();

                int linhaAfetada = comando.ExecuteNonQuery();

                if (linhaAfetada == 1)
                    MessageBox.Show("Venda excluída com sucesso!");
                else
                    MessageBox.Show("Ocorreu um erro ao tentar excluir a venda, tente novamente!");

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

        private void CamposVendas_Load(object sender, EventArgs e)
        {
            if (!this.acao.Equals("Incluir")) Buscar();

            if (this.acao.Equals("Incluir"))
            {
                labelAcao.Text = "Adicionar Venda";
                buttonAdicionar.Visible = true;
            }
            else if (this.acao.Equals("Excluir"))
            {
                labelAcao.Text = "Excluir Venda";
                buttonExcluir.Visible = true;
            }
            else if (this.acao.Equals("Alterar"))
            {
                labelAcao.Text = "Alterar Venda";
                buttonAlterar.Visible = true;
            }
        }

        private void Finalizar()
        {
            Vendas vendas = new Vendas();
            vendas.Empresa = this.Empresa;
            vendas.Administrador = this.idAdm;
            vendas.Show();
            this.Close();
        }
    }
}
