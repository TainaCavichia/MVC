using System;
using System.Collections.Generic;
using System.IO;
using Estacionamento.MVC.Models;

namespace Estacionamento.MVC.Repositorio
{
    public class CarroRepositorio
    {
        public RegistroModel Cadastrar (RegistroModel carro) {
            if (File.Exists ("DataBase/carros.csv")) {
                carro.Id = File.ReadAllLines ("DataBase/carros.csv").Length + 1;
            } else {

                carro.Id = 1;
            }
            StreamWriter sw = new StreamWriter ("carros.csv", true);
            sw.WriteLine ($"{carro.Id};{carro.Nome};{carro.Marca};{carro.Modelo};{carro.DataDeEntrada}");
            sw.Close ();

            return carro;
        }
        public List<RegistroModel> Listar () {
            List<RegistroModel> listaDeCarros = new List<RegistroModel> ();

            string[] linhas = File.ReadAllLines ("carros.csv");
            RegistroModel carro;
            foreach (var item in linhas) {
                if (string.IsNullOrEmpty (item)) {
                    //retorna para o foreach
                    continue;
                }
                string[] linha = item.Split (";");
                carro = new RegistroModel (
                    id: int.Parse (linha[0]),
                    nome: linha[1],
                    marca: linha[2],
                    modelo: linha[3],
                    placa: linha[4],
                    dataDeEntrada: DateTime.Parse (linha[4])
                );
                listaDeCarros.Add (carro);
            }
            return listaDeCarros;
        }
    }
}