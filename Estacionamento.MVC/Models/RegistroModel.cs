using System;
using Microsoft.Extensions.Primitives;

namespace Estacionamento.MVC.Models
{
    public class RegistroModel
    {
        private StringValues marca;
        private StringValues modelo;

        public int Id {get;set;}
        public string Nome {get;set;}
        public MarcaModel Marca {get;set;}
        public ModeloModel Modelo {get;set;}
        public string Placa {get;set;}
        public DateTime DataDeEntrada {get;set;}


         public RegistroModel (int id,string nome, DateTime dataDeEntrada, string marca, string modelo, string placa){
            this.Id = id;
            this.Nome = nome;
            this.Marca.Marca = marca;
            this.Modelo.Modelo = modelo;
            this.Placa = placa;
            this.DataDeEntrada = dataDeEntrada;
        }

        public RegistroModel()
        {
            
        }

        public RegistroModel(StringValues nome, StringValues marca, StringValues modelo, StringValues placa, DateTime dataDeEntrada)
        {
            Nome = nome;
            this.marca = marca;
            this.modelo = modelo;
            Placa = placa;
            DataDeEntrada = dataDeEntrada;
        }
    }
}