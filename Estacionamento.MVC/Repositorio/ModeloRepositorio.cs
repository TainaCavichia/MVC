using System.Collections.Generic;
using System.IO;
using Estacionamento.MVC.Models;

namespace Estacionamento.MVC.Repositorio
{
    public class ModeloRepositorio
    {
        private const string PATH = "DataBase/Modelos.csv";

        private List<ModeloModel> Carros = new List<ModeloModel>();

        public List<ModeloModel> Listar()
        {
            var registros = File.ReadAllLines(PATH);
            foreach (var item in registros)
            {
                var valores = item.Split(";");
                ModeloModel carro = new ModeloModel();
                carro.Id = int.Parse(valores[0]);
                carro.Modelo = valores[1];

                this.Carros.Add(carro);
            }
            return this.Carros;
        }
    }
}