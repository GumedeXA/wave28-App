using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Wave28Application.Models;

using ClientRegistration.Data.AccountModels;
using System.Web.Script.Serialization;

namespace Wave28Application.Controllers
{
    public class LoginController : Controller
    {
        HttpClient client;

        public LoginController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ApiAddresses.loginAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel lgModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //HTTP POST
                    var json = new JavaScriptSerializer().Serialize(lgModel);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                    var loginContent = new ByteArrayContent(buffer);
                    loginContent.Headers.Clear();
                    //Header details
                    loginContent.Headers.Add("Content-Type", "application/json");
                    var sendData = client.PostAsync(client.BaseAddress, loginContent).Result;
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
            return View(lgModel);

        }
    }
}