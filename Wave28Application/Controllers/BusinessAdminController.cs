using ClientRegistration.ViewModels.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Wave28Application.Models;

namespace Wave28Application.Controllers
{
    public class BusinessAdminController : Controller
    {
     
        HttpClient client;

        public BusinessAdminController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ApiAddresses.busAdminaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
        
        }
        // GET: BusinessAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: BusinessAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusinessAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessAdmin/Create
        [HttpPost]
        public ActionResult Create(RegisterViewModel registerView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                        //HTTP POST
                        var json = new JavaScriptSerializer().Serialize(registerView);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                        var registerContent = new ByteArrayContent(buffer);

                        var sendData = client.PostAsync(client.BaseAddress, registerContent).Result;
                        if (sendData.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    else
                    {
                        return View(sendData.IsSuccessStatusCode);
                    }
                  
                }
            }
            catch (Exception e)
            {
                throw e.InnerException;

            }
            return View(registerView);

        }
        // GET: BusinessAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BusinessAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusinessAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
