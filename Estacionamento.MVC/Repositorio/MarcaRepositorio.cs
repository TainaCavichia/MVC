using System.Collections.Generic;
using System.IO;
using Estacionamento.MVC.Models;

namespace Estacionamento.MVC.Repositorio
{
    public class MarcaRepositorio
    {
        private const string PATH = "DataBase/Marcas.csv";

        private List<MarcaModel> Marcas = new List<MarcaModel>();

        public List<MarcaModel> Listar()
        {
            var registros = File.ReadAllLines(PATH);
            foreach (var item in registros)
            {
                var valores = item.Split(";");
                MarcaModel marca = new MarcaModel();
                marca.Id = int.Parse(valores[0]);
                marca.Marca = valores[1];

                this.Marcas.Add(marca);
            }
            return this.Marcas;
        }
    }
}