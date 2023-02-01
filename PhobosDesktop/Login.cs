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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //pegando a informacao digitada pelo usuario
                string objNome = txtNome.Text;
                string objSenha = txtSenha.Text;

                //instanciando objeto DTO
                UsuarioAutenticaDTO objModelo = new UsuarioAutenticaDTO();
                UsuarioBLL objValida = new UsuarioBLL();

                objModelo = objValida.AutenticaUsuario(objNome, objSenha);
                if (objModelo != null)
                {
                    switch (objModelo.UsuarioTp)
                    {
                        case 1:
                            CadastroUser obj = new CadastroUser();
                            obj.Show();
                            this.Visible = false;
                            break;
                        case 2:
                            MessageBox.Show("Usuario OTHERS!! ");

                            break;
                    }
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario não cadastrado!! " + ex.Message);

            }
        }
    }
}
