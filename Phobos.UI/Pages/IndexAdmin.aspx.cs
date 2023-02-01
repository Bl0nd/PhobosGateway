using Phobos.BLL;
using Phobos.DTO;
using System.Drawing;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phobos.UI.Pages
{
    public partial class IndexAdmin : System.Web.UI.Page
    {
        //instanciando objetos Usuario
        UsuarioDTO objModeloUser = new UsuarioDTO();
        UsuarioBLL objBLLUser = new UsuarioBLL();
      
        //metodo PopularGVUsuario
        public void PopularGVUser()
        {
            dgv1.DataSource = objBLLUser.ListarUserAdmin();
            dgv1.DataBind();
        }

        //messageBox
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        //MsgBox("! your message !", this.Page, this);


        //validacao User
        private bool ValidaPage()
        {
            bool PageValido;

            if (string.IsNullOrEmpty((dgv1.FooterRow.FindControl("txtNomeUsuarioFooter") as TextBox).Text.Trim()))
            {
                //(dgv1.FooterRow.FindControl("txtNomeUsuarioFooter") as TextBox).BackColor= Color.Red;
                MsgBox("Digite o nome!", Page, this);
                //(dgv1.FooterRow.FindControl("txtNomeUsuarioFooter") as TextBox).BackColor = Color.White;
                (dgv1.FooterRow.FindControl("txtNomeUsuarioFooter") as TextBox).Focus();
                PageValido = false;
            }

            else if (string.IsNullOrEmpty((dgv1.FooterRow.FindControl("txtEmailUsuarioFooter") as TextBox).Text.Trim()))
            {
                MsgBox("Digite o email!", this.Page, this);
                (dgv1.FooterRow.FindControl("txtEmailUsuarioFooter") as TextBox).Focus();
                PageValido = false;
            }
            else if (string.IsNullOrEmpty((dgv1.FooterRow.FindControl("txtSenhaUsuarioFooter") as TextBox).Text.Trim()))
            {
                MsgBox("Digite a senha!", this.Page, this);
                (dgv1.FooterRow.FindControl("txtSenhaUsuarioFooter") as TextBox).Focus();
                PageValido = false;
            }
            else if (string.IsNullOrEmpty((dgv1.FooterRow.FindControl("txtDataNascUsuarioFooter") as TextBox).Text.Trim()) || (dgv1.FooterRow.FindControl("txtDataNascUsuarioFooter") as TextBox).Text.Trim().Length < 10)
            {
                MsgBox("Digita a data!", this.Page, this);
                (dgv1.FooterRow.FindControl("txtDataNascUsuarioFooter") as TextBox).Focus();
                PageValido = false;
            }
            else if ((dgv1.FooterRow.FindControl("rbl1") as RadioButtonList).SelectedIndex < 0)
            {
                MsgBox("Escolha uma das opções!", this.Page, this);
                (dgv1.FooterRow.FindControl("rbl1") as RadioButtonList).Focus();
                PageValido = false;

            }
            else
            {
                PageValido = true;
            }
            return PageValido;

        }


      



        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                PopularGVUser();
                lblMessage.Text = String.Empty;
            }

            //iniciando session
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }


        }

        protected void dgv1_RowCommand(object sender, GridViewCommandEventArgs e)
        {




            if (e.CommandName.Equals("Add"))
            {



                if (ValidaPage())
                {
                    objModeloUser.Nome = (dgv1.FooterRow.FindControl("txtNomeUsuarioFooter") as TextBox).Text.Trim();
                    objModeloUser.Senha = (dgv1.FooterRow.FindControl("txtSenhaUsuarioFooter") as TextBox).Text.Trim();
                    objModeloUser.Email = (dgv1.FooterRow.FindControl("txtEmailUsuarioFooter") as TextBox).Text.Trim();

                    //ajustando a data

                    DateTime dt = DateTime.Parse((dgv1.FooterRow.FindControl("txtDataNascUsuarioFooter") as TextBox).Text.Trim());
                    objModeloUser.DataNascUsuario = dt.ToString("yyyy/MM/dd");



                    objModeloUser.UsuarioTp = (dgv1.FooterRow.FindControl("rbl1") as RadioButtonList).Text.Trim();

                    objBLLUser.CadastrarUser(objModeloUser);
                    PopularGVUser();
                    (dgv1.FooterRow.FindControl("txtNomeUsuarioFooter") as TextBox).Focus();
                    lblMessage.Text = "Usuário " + objModeloUser.Nome + " cadastrado com Sucesso !!";


                }
            }

        }

        protected void dgv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            
                objModeloUser.Nome = (dgv1.Rows[e.RowIndex].FindControl("txtNomeUsuario") as TextBox).Text.Trim();
                objModeloUser.Email = (dgv1.Rows[e.RowIndex].FindControl("txtEmailUsuario") as TextBox).Text.Trim();
                objModeloUser.Senha = (dgv1.Rows[e.RowIndex].FindControl("txtSenhaUsuario") as TextBox).Text.Trim();
                objModeloUser.DataNascUsuario = (dgv1.Rows[e.RowIndex].FindControl("txtDataNascUsuario") as TextBox).Text.Trim();

                objModeloUser.UsuarioTp = (dgv1.Rows[e.RowIndex].FindControl("rbl1") as RadioButtonList).Text.Trim();
                objModeloUser.Id = Convert.ToInt32(dgv1.DataKeys[e.RowIndex].Value.ToString());

                objBLLUser.EditUser(objModeloUser);
                dgv1.EditIndex = -1;

                PopularGVUser();

                lblMessage.Text = "Usuário " + objModeloUser.Nome + " editado com sucesso !!";
           

        }

        protected void dgv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objModeloUser.Id = Convert.ToInt32(dgv1.DataKeys[e.RowIndex].Value.ToString());
            objBLLUser.DeleteUser(objModeloUser.Id);
            PopularGVUser();
            lblMessage.Text = "Usuário " + objModeloUser.Nome + " eliminado com Sucesso !!";
        }

        protected void dgv1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgv1.EditIndex = e.NewEditIndex;
            PopularGVUser();
        }

        protected void dgv1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgv1.EditIndex = -1;
            PopularGVUser();
        }

      
    }
}