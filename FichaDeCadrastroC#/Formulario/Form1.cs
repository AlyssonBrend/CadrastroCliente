using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.OleDb;


namespace Formulario
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Validacoes() == true)
                return;
            SalvarClienteMysql();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                Funcoes.MsgErro("Salve os dados do cliente primeiro");
            }
            OpenFileDialog caixa = new OpenFileDialog();
            caixa.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            caixa.ShowDialog();
            if (caixa.ShowDialog() == DialogResult.OK)
            {
                ImgCliente.Image = Image.FromFile(caixa.FileName);
                File.Copy(caixa.FileName, AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + txtId.Text + ".png");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                Funcoes.MsgErro("Imagem não cadrastada");
                return;
            }
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + txtId.Text + ".png"))
            {
                Funcoes.MsgErro("Imagem não cadrastada");
                return;
            }
            if (Funcoes.Pergunta("Deseja remover a foto?") == false) return;
            ImgCliente.Image = Properties.Resources.avatar_1789663_640;
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + txtId.Text + ".png");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (txtId.Text == "")
                return;
            btSalvar.Text = "Atualizar";
            using (OleDbConnection Conexao = new OleDbConnection("Server=127.0.0.1,Port=3306;Database=pedidos;User=root;Password="))
            {
                Conexao.Open();
                using (OleDbCommand cmd = Conexao.CreateCommand())
                {
                    if (txtId.Text == "")
                    {
                        cmd.CommandText = "INSER INTO cliente(nome, documento, datacontrato, ncontrato, cep, endereco, numero, bairro, cidade, estado, celular, email, obs, situacao, valor)" +
                       "VALUES (@nome, @documento, @datacontrato, @ncontrato, @cep, @endereco, @numero, @bairro, @cidade, @estado, @celular, @email, @obs, @situacao, @valor)";
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE cliente SET nome = @nome , documento = @documento, datacontrato = @datacontrato, ncontrato = @ncontrato, cep = @cep, endereco = @endereco, numero = @numero, bairro = @bairro," +
                            " cidade = @cidade, estado = @estado, celular = @celular, email = @email, obs = @obs, situacao = @situacao, valor = @valor  WHERE id= " + txtId.Text;
                    }

                    DataTable dt = new DataTable();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        txtNome.Text = dt.Rows[0]["nome"].ToString();
                        maskCPF.Text = dt.Rows[0]["documento"].ToString();
                        // tem q fazer uma vez para cada campo do formulario é o mesmo de salvar, fazer um framwork para ele
                        // da para fazer por switch
                        if (dt.Rows[0]["documento"].ToString().Length == 11)
                        {
                            OpCpf.Checked = true;
                        }
                        else
                        {
                            OpCnpj.Checked = true;
                        }
                        maskCPF.Text = dt.Rows[0]["documento"].ToString();

                        if (dt.Rows[0]["situacao"].ToString() == "Em Andamento")
                        {
                            OpAndamendo.Checked = true;
                        }
                        else if (dt.Rows[0]["situacao"].ToString() == "Concluido")
                        {
                            OpConcluido.Checked = true;
                        }
                        else
                        {
                            OpCancelado.Checked = true;
                        }
                        if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + txtId.Text + ".png"))
                        {
                            ImgCliente.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Fotos/" + txtId.Text + ".png");
                        }
                        else
                        {
                            ImgCliente.Image = Properties.Resources.avatar_1789663_640;
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection Conexao = new MySqlConnection("Server=127.0.0.1,Port=3306;Database=pedidos;User=root;Password="))
            {

                Conexao.Open();
                using (MySqlCommand cmd = Conexao.CreateCommand())
                {
                    cmd.CommandText = "INSER INTO cliente(nome, documento, datacontrato, ncontrato, cep, endereco, numero, bairro, cidade, estado, celular, email, obs, situacao, valor)" +
                         "VALUES (@nome, @documento, @datacontrato, @ncontrato, @cep, @endereco, @numero, @bairro, @cidade, @estado, @celular, @email, @obs, @situacao, @valor)";
                    cmd.Parameters.AddWithValue("nome", txtNome);
                    cmd.Parameters.AddWithValue("documento", maskCPF);
                    cmd.Parameters.AddWithValue("datacontrato", maskDATA);
                    cmd.Parameters.AddWithValue("ncontrato", maskContrato);
                    cmd.Parameters.AddWithValue("cep", maskCEP);
                    cmd.Parameters.AddWithValue("endereco", txtEndereco);
                    cmd.Parameters.AddWithValue("numero", maskN);
                    cmd.Parameters.AddWithValue("bairro", cBoxBairro);
                    cmd.Parameters.AddWithValue("cidade", CboxCidade);
                    cmd.Parameters.AddWithValue("estado", cBoxEstado);
                    cmd.Parameters.AddWithValue("celular", maskCelular);
                    cmd.Parameters.AddWithValue("email", txtEmail);
                    cmd.Parameters.AddWithValue("obs", txtObs);
                    if (OpAndamendo.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("situacao", "Em andamento");
                    }

                    else if (OpConcluido.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("situacao", "Concluido");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("situacao", "Cancelado");
                    }

                    cmd.Parameters.AddWithValue("valor", txtValor);
                }

            }
        }
        private void SalvarClienteMysql()
        {

            using (MySqlConnection Conexao = new MySqlConnection("Server=127.0.0.1,Port=3306;Database=pedidos;User=root;Password="))
            {

                Conexao.Open();
                using (MySqlCommand cmd = Conexao.CreateCommand())
                {
                    cmd.CommandText = "INSER INTO cliente(nome, documento, datacontrato, ncontrato, cep, endereco, numero, bairro, cidade, estado, celular, email, obs, situacao, valor)" +
                        "VALUES (@nome, @documento, @datacontrato, @ncontrato, @cep, @endereco, @numero, @bairro, @cidade, @estado, @celular, @email, @obs, @situacao, @valor)";
                    cmd.Parameters.AddWithValue("nome", txtNome);
                    cmd.Parameters.AddWithValue("documento", maskCPF);
                    MySqlParameter mySqlParameter = cmd.Parameters.AddWithValue("datacontrato", Convert.ToDateTime(maskDATA));
                    cmd.Parameters.AddWithValue("ncontrato", maskContrato);
                    MySqlParameter mySqlParameter1 = cmd.Parameters.AddWithValue("cep", maskCEP);
                    cmd.Parameters.AddWithValue("endereco", txtEndereco);
                    cmd.Parameters.AddWithValue("numero", maskN);
                    cmd.Parameters.AddWithValue("bairro", cBoxBairro);
                    cmd.Parameters.AddWithValue("cidade", CboxCidade);
                    cmd.Parameters.AddWithValue("estado", cBoxEstado);
                    cmd.Parameters.AddWithValue("celular", maskCelular);
                    cmd.Parameters.AddWithValue("email", txtEmail);
                    cmd.Parameters.AddWithValue("obs", txtObs);
                    if (OpAndamendo.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("situacao", "Em andamento");
                    }

                    else if (OpConcluido.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("situacao", "Concluido");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("situacao", "Cancelado");
                    }

                    cmd.Parameters.AddWithValue("valor", txtValor);
                    cmd.ExecuteNonQuery();
                    if (txtId.Text != "")
                    {
                        cmd.CommandText = "SELECT @@IDENTITY";
                        txtId.Text = cmd.ExecuteScalar().ToString();
                    }
                }

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
        private bool Validacoes()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Campo nome obrigatorio");
                txtNome.Focus();
                return true;
            }
            if (maskCPF.Text == "")
            {
                MessageBox.Show("Campo Cpf obrigatorio");
                txtNome.Focus();
                return true;
            }
            if (OpAndamendo.Checked == false && OpCancelado.Checked == false && OpConcluido.Checked == false)
            {
                MessageBox.Show("Campo obrigatorio");
                return true;
            }
            if (maskCelular.Text == "")
            {
                MessageBox.Show("Campo Celular obrigatorio");
                txtNome.Focus();
                return true;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Campo email obrigatorio");
                txtNome.Focus();
                return true;
            }
            try
            {
                Convert.ToDateTime(maskDATA.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Data invalida");
                txtNome.Focus();
                return true;
            }
            return false;
        }

        private void OpCpf_CheckedChanged(object sender, EventArgs e)
        {
            if (OpCpf.Checked == true)
            {
                maskCPF.Mask = "000,000,000-00";
                maskCPF.Focus();
            }
            if (OpCnpj.Checked == true)
            {
                maskCPF.Mask = "00,000,000/0000-00";
                maskCPF.Focus();
            }
        }

        private void OpAndamendo_CheckedChanged(object sender, EventArgs e)
        {
            txtValor.Focus();
        }

        private void OpConcluido_CheckedChanged(object sender, EventArgs e)
        {
            txtValor.Focus();
        }

        private void OpCancelado_CheckedChanged(object sender, EventArgs e)
        {
            txtValor.Focus();
        }

        private void maskDATA_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (maskDATA.Text == "  /  /")
                return;
            try
            {
                maskDATA.Text = Convert.ToDateTime(maskDATA.Text).ToString();
            }
            catch
            {
                MessageBox.Show("Data invalida!");
                //  e.Cancel = true;
            }
        }

        private void cBoxEstado_Validating(object sender, CancelEventArgs e)
        {

            if (cBoxEstado.Text == "")
                return;
            else if (cBoxEstado.SelectedIndex == -1)
            {
                MessageBox.Show("EStado invalido");
                //   e.Cancel = true;
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            Funcoes.PriMaiuscula(txtNome);
        }

        private void maskCEP_Validating(object sender, CancelEventArgs e)
        {

            if (maskCEP.Text.Length == 0)
                return;
            if (maskCEP.Text.Length < 8)
            {
                MessageBox.Show("Cep invalido");
                //e.Cancel = true;
            }
        }

        private void maskCPF_Validating(object sender, CancelEventArgs e)
        {

            if (maskCPF.Text == "")
                return;
            if (OpCnpj.Checked == true && maskCPF.Text.Length < 14)
            {
                MessageBox.Show("Informação incompleta");
            }
            if (OpCpf.Checked == true && maskCPF.Text.Length < 11)
            {
                MessageBox.Show("Informação incompleta");
            }

        }
    }
}