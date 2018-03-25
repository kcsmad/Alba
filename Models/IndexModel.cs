using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ALBA.Models
{
    public class IndexModel
    {
        [FileExtensions(ErrorMessage = "O arquivo não é um arquivo valido. Por favor insira um arquivo com as extensões .log e .xml.", Extensions = "xml,log")]
        [Required(ErrorMessage = "Você precisa selecionar um arquivo.")]
        public HttpPostedFileBase file { get; set; }
        public string resultado { get; set; }
        public string data { get; set; }
        public string dia { get; set; }
        public string mes { get; set; }
        public string ano { get; set; }
    }
}