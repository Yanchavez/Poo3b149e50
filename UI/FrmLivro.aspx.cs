using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using poo3b149e50.BLL;
using poo3b149e50.DTO;

namespace poo3b149e50.UI
{
    public partial class FrmLivros : System.Web.UI.Page
    {

        readonly tblAutorBLL autorBLL = new tblAutorBLL();
        readonly tblEditoraBLL editoraBLL = new tblEditoraBLL();

        readonly tblLivroBLL livroBLL = new tblLivroBLL();
        readonly tblLivroDTO livroDTO = new tblLivroDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                drpAutor.DataSource = autorBLL.listarAutores();
                drpAutor.DataTextField = "nome";
                drpAutor.DataValueField = "idAutor";
                drpAutor.DataBind();

                drpEditora.DataSource = editoraBLL.listarEditoras();
                drpEditora.DataTextField = "nome";
                drpEditora.DataValueField = "idEditora";
                drpEditora.DataBind();

                renderizarGrid();
            }
        }

        public void renderizarGrid()
        {
            GridLivro.DataSource = livroBLL.listarLivros();
            GridLivro.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                livroDTO.Id_autor = int.Parse(drpAutor.SelectedValue.ToString());
                livroDTO.Id_editora = int.Parse(drpEditora.SelectedValue.ToString());
                livroDTO.Data_cadastro = Convert.ToDateTime(txtDataCadastro.Text);
                livroDTO.Titulo_livro = txtTitulo.Text;
                livroDTO.Num_paginas = int.Parse(txtNumPaginas.Text);
                livroDTO.Valor_livro = double.Parse(txtValor.Text);

                livroBLL.criarLivro(livroDTO);

                messageError.Visible = false;

                renderizarGrid();
                messageSuccess.Visible = true;
                messageSuccess.Text = "Livro salvo com sucesso!";
            }
            catch (Exception error)
            {
                messageSuccess.Text = string.Empty;
                messageSuccess.Visible = false;
                messageError.Visible = true;
                messageError.Text = error.Message;
            }
        }

        protected void GridLivro_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                livroDTO.Id_livro = Convert.ToInt32(e.Values[0]);
                livroBLL.deletarLivro(livroDTO);

                messageSuccess.Visible = true;
                messageSuccess.Text = "Livro deletado com sucesso!";

                renderizarGrid();
            }
            catch (Exception ex)
            {
                messageError.Visible = true;
                messageError.Text = ex.Message;
            }
        }

        protected void GridLivro_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridLivro.EditIndex = e.NewEditIndex;
            renderizarGrid();
        }

        protected void GridLivro_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                livroDTO.Id_livro = int.Parse(e.NewValues[0].ToString());
                livroDTO.Id_autor = int.Parse(e.NewValues[1].ToString());
                livroDTO.Id_editora = int.Parse(e.NewValues[2].ToString());
                livroDTO.Titulo_livro = e.NewValues[3].ToString();
                livroDTO.Data_cadastro = Convert.ToDateTime(e.NewValues[4]);
                livroDTO.Num_paginas = int.Parse(e.NewValues[5].ToString());
                livroDTO.Valor_livro = double.Parse(e.NewValues[6].ToString());

                livroBLL.atualizarLivro(livroDTO);

                GridLivro.EditIndex = -1;
                renderizarGrid();
            }
            catch (Exception ex)
            {
                messageError.Visible = true;
                messageError.Text = ex.Message;
            }
        }

        protected void GridLivro_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridLivro.EditIndex = -1;
            renderizarGrid();
        }
    }
}