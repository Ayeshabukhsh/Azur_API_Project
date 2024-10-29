using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly string url = "https://localhost:7186/api/StudentAPI/";
        private readonly HttpClient client = new HttpClient();

        // GET: Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            std.id = 0;
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                TempData["insert_message"] = "Student Added.......!";
                return RedirectToAction("Index");
            }
            else
            {
                string errorMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", $"Error: {errorMsg}");
            }
            return View();
        }

        // GET: Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(result);
                if (data != null)
                {
                    std = data;
                }
                return RedirectToAction("Index");

            }
            return View(std);
        }

            // POST: Edit
            [HttpPost]
        public IActionResult Edit(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url + std.id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["update_message"] = "Student Updated.......!";
                return RedirectToAction("Index");
            }
            else
            {
                string errorMsg =  response.Content.ReadAsStringAsync().Result;
                ModelState.AddModelError("", $"Error: {errorMsg}");
            }
            return View(std);
        }

        // GET: Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student std = new Student();
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {

                TempData["delete_message"] = "Student Deleted....";
                return RedirectToAction("Index");
            }
            return View(std);
        }

        // POST: DeleteConfirmed
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    HttpResponseMessage response = client.DeleteAsync(url + "/" + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
                 
        //        TempData["delete_message"] = "Student Deleted....";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
}
