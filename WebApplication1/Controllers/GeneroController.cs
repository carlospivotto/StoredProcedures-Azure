using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoredProcedures.Models;

namespace StoredProcedures.Controllers
{
    public class GeneroController : Controller
    {
        // GET: GeneroController
        public ActionResult Index()
        {
            var generos = new List<Genero>();
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InfnetFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using var connection = new SqlConnection(connectionString);
            var sp = "ListarGeneros";
            var sqlCommand = new SqlCommand(sp, connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                connection.Open();
                using var reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var genero = new Genero
                    {
                        GeneroId = (int)reader["GeneroId"],
                        Nome = reader["Nome"].ToString(),
                        Descricao = reader["Descricao"].ToString()
                    };

                    generos.Add(genero);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } finally
            {
                connection.Close();
            }

            return View(generos);
        }

        // GET: GeneroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GeneroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneroController/Create
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

        // GET: GeneroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GeneroController/Edit/5
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

        // GET: GeneroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GeneroController/Delete/5
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
