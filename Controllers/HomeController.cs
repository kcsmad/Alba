using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ALBA.Models;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace ALBA.Controllers
{

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult Index(IndexModel resposta)
        {
            
            BinaryReader b = new BinaryReader(resposta.file.InputStream);
            byte[] binData = b.ReadBytes((int)resposta.file.InputStream.Length);
            List<String> Lista = new List<String>();
            List<String> Data = new List<String>();

            string result = System.Text.Encoding.UTF8.GetString(binData);
            
            char[] delimitadores = new char[] { '\n' };
            string[] strings = result.Split(delimitadores);
            foreach (string s in strings)
            {

                if (s.Length > 10)v
                {
                    if (s.Substring(3, 1) == " " && s.Substring(7, 1) == " " && s.Substring(10, 1) == " ")
                    {
                        resposta.dia = s.Substring(8, 2);
                        resposta.mes = s.Substring(4, 3);
                        resposta.ano = s.Substring(20, 4);
                    }
                }
                if (s.StartsWith("ORA-"))
                {
                    Data.Add(resposta.data = (resposta.dia + " " + resposta.mes + " " + resposta.ano));
                    Lista.Add(resposta.resultado = s.Substring(0, 9));
                }
                
            }         

            return RedirectToAction("Resultado");
        }

        public ActionResult Resultado()
        {
            List<IndexModel> res = new List<IndexModel>();
            return View(res);
        }


    }
}
