using System;
using Microsoft.Extensions.Primitives;

namespace Estacionamento.MVC.Models
{
    public class RegistroModel
    {
        public int Id {get;set;}
        public string Nome {get;set;}
        public string Marca {get;set;}
        public string Modelo {get;set;}
        public string Placa {get;set;}
        public DateTime DataDeEntrada {get;set;}

        

    }
}