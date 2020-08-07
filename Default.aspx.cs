using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services.Description;
using Microsoft.Ajax.Utilities;

namespace CRUDTEST
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaDatosActor();
            }
        }

        public void CargaDatosActor()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Muestra_Actor";
                cmd.Connection = conn;
                conn.Open();
                gvdActor.DataSource = cmd.ExecuteReader();
                gvdActor.DataBind();

            }
        }

        public void GuardaActor()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_insert_Actor";
                cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = txtNombre.Text.Trim();
                cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = txtApellidos.Text.Trim();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void LimpiaDatos()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
        }

        public void ValidaDatos()
        {
            
            if (txtNombre.Text == "")
            {
               
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlDatosActor.Visible = false;
            pnlAltasActor.Visible = true;
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            pnlAltasActor.Visible = false;
            pnlDatosActor.Visible = true;
            GuardaActor();
            CargaDatosActor();
            LimpiaDatos();

        }

        protected void gvdActor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvdActor.Rows[e.RowIndex];
         //   EliminarActor(gvdActor.DataKeys[e.RowIndex].Value.ToString);
            CargaDatosActor();
        }

        public void EliminarActor(int idActor)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_delete_actor";
                cmd.Parameters.Add("@id_actor", SqlDbType.Int).Value = lblID_Actor.Text;
                 
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarActor()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_update_actor";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = lblID_Actor.Text;
                cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = txtNombre.Text.Trim();
                cmd.Parameters.Add("@apellidos", SqlDbType.VarChar).Value = txtApellidos.Text.Trim();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                CargaDatosActor();
            }
        }

        protected void lblActualizar_Click(object sender, EventArgs e)
        {
            pnlAltasActor.Visible = true;
            btnGuardar.Visible = false;
            btnNuevo.Visible = false;
            btnActualizar.Visible = true;
            GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent;
            gvdActor.SelectedIndex = row.RowIndex;
            lblID_Actor.Text = row.Cells[0].Text;
            txtNombre.Text = row.Cells[1].Text;
            txtApellidos.Text = row.Cells[2].Text;

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            pnlAltasActor.Visible = false;
            pnlDatosActor.Visible = true;
            ActualizarActor();
            lblID_Actor.Text = "";
            btnActualizar.Visible = false;
            btnGuardar.Visible = true;
            btnNuevo.Visible = true;
            CargaDatosActor();
        }
    }
}
