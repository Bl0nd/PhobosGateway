<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultAdmin.Master" AutoEventWireup="true" CodeBehind="IndexAdminFilme.aspx.cs" Inherits="Phobos.UI.Pages.IndexAdminFlme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/styleP.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="base">
        <h1 id="movie">Movie</h1>
        <asp:GridView
            runat="server"
            ID="dgv2"
            GridLines="None"
            AutoGenerateColumns="false"
            ShowFooter="true"
            DataKeyNames="Id"

            OnRowCommand="dgv2_RowCommand"
            OnRowEditing="dgv2_RowEditing"
            OnRowCancelingEdit="dgv2_RowCancelingEdit"
            OnRowUpdating="dgv2_RowUpdating"
            OnRowDeleting="dgv2_RowDeleting">

          

            <Columns>

                <%--template Titulo--%>
                <asp:TemplateField HeaderText="Filme">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Titulo") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTituloFilme" runat="server" MaxLength="50" Text='<%#Eval("Titulo") %>' />
                        <br />
                        <asp:RequiredFieldValidator
                            ID="TituloFilme"
                            runat="server"
                            ErrorMessage="Digite o Titulo !!"
                            ForeColor="Red"
                            ControlToValidate="txtTituloFilme" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtTituloFilmeFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <%--template Genero--%>
                <asp:TemplateField HeaderText="Gênero">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Genero") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtGeneroFilme" runat="server" MaxLength="50" Text='<%#Eval("Genero") %>' />
                        <br />
                        <asp:RequiredFieldValidator
                            ID="GeneroFilme"
                            runat="server"
                            ErrorMessage="Digite o Genero !!"
                            ForeColor="Red"
                            ControlToValidate="txtGeneroFilme" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtGeneroFilmeFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <%--template Produtora--%>
                <asp:TemplateField HeaderText="Produtora">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Produtora") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProdutoraFilme" runat="server" MaxLength="50" Text='<%#Eval("Produtora") %>' />
                        <br />
                        <asp:RequiredFieldValidator
                            ID="ProdutoraFilme"
                            runat="server"
                            ErrorMessage="Digite a Produtora !!"
                            ForeColor="Red"
                            ControlToValidate="txtProdutoraFilme" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtProdutoraFilmeFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

               


                <%--radio buttons--%>
                <asp:TemplateField HeaderText="Classificação">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("FilmeClassif") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:RadioButtonList ID="rbl1" runat="server">
                            <asp:ListItem Value="1" Text=" Livre" />
                            <asp:ListItem Value="2" Text=" +18" />
                        </asp:RadioButtonList>
                        <br />
                        <asp:RequiredFieldValidator
                            ID="rblist"
                            runat="server"
                            ErrorMessage="Selecione uma opção !!"
                            ForeColor="Red"
                            ControlToValidate="rbl1" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:RadioButtonList ID="rbl1" runat="server">
                            <asp:ListItem Value="1" Text=" Livre" />
                            <asp:ListItem Value="2" Text=" +18" />
                        </asp:RadioButtonList>
                    </FooterTemplate>
                </asp:TemplateField>


                 <%--template Imagem--%>
              <asp:TemplateField HeaderText="Imagem">
                <ItemTemplate>
                    <asp:Image ImageUrl='<%#Eval("UrlImg")%>' Width="100" Height="100" runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="fUp1" runat="server" Text="Selecione a Imagem" />
                    <br />
                        <asp:RequiredFieldValidator
                            ID="fUpLoad"
                            runat="server"
                            ErrorMessage="Selecione uma imagem !!"
                            ForeColor="Red"
                            ControlToValidate="fUp1" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:FileUpload ID="fUp1" runat="server" Text="Selecione a Imagem" />
                </FooterTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>


                <%--buttons--%>
                <asp:TemplateField HeaderText="Opções">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/img/editB.png" ToolTip="Editar" Width="30" Height="30" CommandName="Edit" />
                        <asp:ImageButton ID="btnExcluir" runat="server" ImageUrl="~/img/deleteB.png" ToolTip="Excluir" Width="30" Height="30" CommandName="Delete" OnClientClick="if (!confirm('Deseja relmente eliminar este registro??'))return false" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ID="btnSalvar" runat="server" ImageUrl="~/img/saveB.png" ToolTip="Salvar" Width="30" Height="30" CommandName="Update" />
                        <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/img/cancel.png" ToolTip="Cancelar" Width="30" Height="30" CommandName="Cancel" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ID="btnAdicionar" runat="server" ImageUrl="~/img/addB.png" ToolTip="Adicionar" Width="30" Height="30" CommandName="Add" />
                    </FooterTemplate>
                </asp:TemplateField>

            </Columns>


        </asp:GridView>

        <br />
        <asp:Label ID="lblMessageF" runat="server" Text="Label" ForeColor="White"/>



        <%--        <asp:GridView runat="server" ID="dgv2" GridLines="None" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Titulo" HeaderText="Title" />
                <asp:BoundField DataField="Genero" HeaderText="Genre" />
                <asp:BoundField DataField="Produtora" HeaderText="Producer" />
                <asp:BoundField DataField="Descricao" HeaderText="Description" />
                <asp:ImageField DataImageUrlField="UrlImg" HeaderText="Image" ControlStyle-Width="150" ControlStyle-Height="150" />
            </Columns>


        </asp:GridView>--%>
    </div>

</asp:Content>
