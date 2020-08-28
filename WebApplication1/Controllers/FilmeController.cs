using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FilmeController : Controller
    {
        // GET: FilmeController
        public ActionResult Index()
        {
            var filmes = new List<Filme>();
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InfnetFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using var connection = new SqlConnection(connectionString);
            var sp = "ListarFilmes";
            var sqlCommand = new SqlCommand(sp, connection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var filme = new Filme
                    {
                        FilmeId = (int)reader["FilmeId"],
                        Titulo = reader["Titulo"].ToString(),
                        TituloOriginal = reader["TituloOriginal"].ToString()
                    };

                    filmes.Add(filme);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } finally
            {
                connection.Close();
            }

            return View(filmes);
        }

        // GET: FilmeController/Details/5
        public ActionResult Details(int id)
        {
            var filme = new Filme();
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InfnetFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using var connection = new SqlConnection(connectionString);
            var sp = "DetalharFilme";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@FilmeId", id);

            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    filme.FilmeId = (int)reader["FilmeId"];
                    filme.Titulo = reader["Titulo"].ToString();
                    filme.TituloOriginal = reader["TituloOriginal"].ToString();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            
            return View(filme);
        }

        // GET: FilmeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilmeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
