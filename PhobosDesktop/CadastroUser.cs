using Canoppus.UI.Utilitarios;
using Phobos.BLL;
using Phobos.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhobosDesktop
{
    public partial class CadastroUser : Form
    {
        public CadastroUser()
        {
            InitializeComponent();
        }

        private void CadastroUser_Load(object sender, EventArgs e)
        {
            Limpar.ClearControl(this);
        }

        //validacao

        private bool ValidaForm()
        {
            bool FrmValido;

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                txtNome.BackColor = Color.Red;
                MessageBox.Show("Digita a porra do nome", "Se liga", MessageBoxButtons.OK);
                txtNome.BackColor = DefaultBackColor;
                txtNome.Focus();
                FrmValido = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.BackColor = Color.Red;
                MessageBox.Show("Digita a porra do email", "Se liga", MessageBoxButtons.OK);
                txtEmail.BackColor = DefaultBackColor;
                txtEmail.Focus();
                FrmValido = false;
            }
            else if (string.IsNullOrEmpty(txtSenha.Text))
            {
                txtSenha.BackColor = Color.Red;
                MessageBox.Show("Digita a porra da senha", "Se liga", MessageBoxButtons.OK);
                txtSenha.BackColor = DefaultBackColor;
                txtSenha.Focus();
                FrmValido = false;
            }
            
            else if (string.IsNullOrEmpty(txtData.Text) || txtData.Text.Length < 10)
            {
                txtData.BackColor = Color.Red;
                MessageBox.Show("Digita a porra da data", "Se liga", MessageBoxButtons.OK);
                txtData.BackColor = DefaultBackColor;
                txtData.Focus();
                FrmValido = false;
            }
            else if (!rb1.Checked && !rb2.Checked)
            {
                gb1.BackColor = Color.Red;
                MessageBox.Show("Escolhe a porra do tipo do usuário", "Se liga", MessageBoxButtons.OK);
                gb1.BackColor = DefaultBackColor;
                gb1.Focus();
                FrmValido = false;

            }
            else
            {
                FrmValido = true;
            }
            return FrmValido;

        }



        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidaForm())
            {

                UsuarioDTO objCad = new UsuarioDTO();

                objCad.Nome = txtNome.Text;
                objCad.Senha = txtSenha.Text;
                objCad.Email = txtEmail.Text;





                //ajustando a data
                DateTime dt = DateTime.Parse(txtData.Text);
                objCad.DataNascUsuario = dt.ToString("yyyy/MM/dd");



                //checando tipo de usuario
                if (rb1.Checked)
                {
                    objCad.UsuarioTp = "1";
                }
                else if (rb2.Checked)
                {
                    objCad.UsuarioTp = "2";
                }

                UsuarioBLL objCadastra = new UsuarioBLL();
                objCadastra.CadastrarUser(objCad);
                Limpar.ClearControl(this);

                MessageBox.Show("Usuário " + objCad.Nome + " cadastrado com sucesso!!");
            }
        }

        
    }
}
