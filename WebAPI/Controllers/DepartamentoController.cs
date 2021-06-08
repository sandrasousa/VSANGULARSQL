using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DepartamentoController : ApiController
    {
        //GET DATA
        public HttpResponseMessage Get()
        {
            string query = @"select * from dbo.Departamento";

            //conexão à BD
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["AngularDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
                using(var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        //ADD (POST) DATA
        public string Post(Departamento dep)
        {
            try
            {
                string query = @"insert into dbo.Departamento values ('"+dep.DepartamentoName+ @"')";

                //conexão à BD
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["AngularDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Adicionado com sucesso";
            }
            catch (Exception)
            {
                return "Falha a adicionar";
            }
            
        }

        //UPDATE (PUT) DATA
        public string Put(Departamento dep)
        {
            try
            {
                string query = @"update dbo.Departamento 
                                 set DepartamentoName= '" + dep.DepartamentoName + @"'
                                 where DepartamentoID= " + dep.DepartamentoID + @"";

                //conexão à BD
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["AngularDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Atualizado com sucesso";
            }
            catch (Exception)
            {
                return "Falha ao atualizar";
            }

        }

        //DELETE DATA
        public string Delete(int id)
        {
            try
            {
                string query = @"delete from dbo.Departamento 
                                 where DepartamentoID= " + id + @"";

                //conexão à BD
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["AngularDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Apagado com sucesso";
            }
            catch (Exception)
            {
                return "Falha ao apagar";
            }

        }
    }
}
