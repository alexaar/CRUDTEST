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
                cmd.Parameters.Add("@id_actor", SqlDbType.BigInt).Value = (idActor);
                 
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
