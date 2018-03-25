using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ALBA.Models
{
    public class Log
    {
        [FileExtensions(ErrorMessage = "O arquivo não é um arquivo valido. Por favor insira um arquivo com as extensões .log e .xml.", Extensions = "xml,log")]
        [Required(ErrorMessage = "Você precisa selecionar um arquivo.")]
        public HttpPostedFileBase file { get; set; }
    }
}