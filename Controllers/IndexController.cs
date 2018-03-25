using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALBA.Models;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace ALBA.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        [HttpGet]
        public ActionResult Index()
        {
            //List<Informacoes> datas = Session["datas"] as List<Informacoes>;

            //if (datas != null)
            //{
                //return View("Grid", datas);
            //}

            //else
            //{
                return View();
            //}
        }

        [HttpPost]
        public ActionResult Results(Log log, Informacoes data)
        {
            List<Log> errologs = new List<Log>();
            List<Informacoes> datas = new List<Informacoes>();
            List<Tratamento> tratamentos = new List<Tratamento>();
            

            BinaryReader b = new BinaryReader(log.file.InputStream);
            byte[] binData = b.ReadBytes((int)log.file.InputStream.Length);

            string result = System.Text.Encoding.UTF8.GetString(binData);

            char[] delimitadores = new char[] { '\n' };
            string[] strings = result.Split(delimitadores);

            foreach (string s in strings)
            {

                if (s.Length >= 24)
                {
                    //Validar datas
                    if (s.Substring(13, 1) == ":" && s.Substring(16, 1) == ":")
                    {
                        data = new Informacoes();
                        data.Dia = s.Substring(8, 2);
                        data.Mes = s.Substring(4, 3);
                        data.Ano = s.Substring(20, 4);

                        string datac = data.Dia + " " + data.Mes + " " + data.Ano;
                        IFormatProvider cultura = new System.Globalization.CultureInfo("en-US", true);
                        DateTime dataconvertida = DateTime.Parse(datac, cultura, System.Globalization.DateTimeStyles.AssumeLocal);
                        data.Data = dataconvertida.ToString("dd/MM/yyyy");

                    }
                    if (s.StartsWith("ORA-"))
                    {
                        //Validar erros para exibição
                        Regex restricao = new Regex("[0-9]");
                        StringBuilder be = new StringBuilder();
                        foreach (Match m in restricao.Matches(s.Substring(0, 9)))
                        {
                            be.Append(m.Value);
                        }
                        data.Numero = "ORA-"+be.ToString();

                        if (tratamentos.Count == 0)
                        {
                            Tratamento tr = new Tratamento();
                            tr.Prefixo = "ORA-";
                            tr.Numero = be.ToString();
                            tratamentos.Add(tr);
                        }
                        else
                        {
                            
                        }

                        //Validar mensagem para exibição
                        if (s.Substring(9, 1) == ":")
                        {
                            data.Mensagem = s.Substring(10, Convert.ToInt32(s.Length - 10));
                        }
                        else
                        {
                            data.Mensagem = s.Substring(9, Convert.ToInt32(s.Length - 9));
                        }
 
                        datas.Add(data);
                    }

                }

            }

            Session["datas"] = datas;

            return View("Grid", datas);

        }

        
        public ActionResult Grid()
        {
            return View();
        }

        public ActionResult _Erro()
        {
            return View();
        }


    }
}
