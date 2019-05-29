using System.Collections.Generic;
using Estacionamento.MVC.Models;

namespace Estacionamento.MVC.ViewModel
{
    public class RegistroViewModel
    {
        public List<MarcaModel> Marcas {get;set;}
        public List<ModeloModel> Modelos {get;set;}
    }
}