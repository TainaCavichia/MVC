using System;
using System.Collections.Generic;
using System.IO;
using Estacionamento.MVC.Models;

namespace Estacionamento.MVC.Repositorio
{
    public class RegistroRepositorio
    {
        public RegistroModel Cadastrar (RegistroModel registro) {
            if (File.Exists ("DataBase/Registros.csv")) {
                registro.Id = File.ReadAllLines ("DataBase/Registros.csv").Length + 1;
            } else {

                registro.Id = 1;
            }
            StreamWriter sw = new StreamWriter ("Registros.csv", true);
            sw.WriteLine ($"{registro.Id};{registro.Nome};{registro.Marca};{registro.Modelo};{registro.DataDeEntrada}");
            sw.Close ();

            return registro;
        }
        public List<RegistroModel> Listar () {
            List<RegistroModel> listaDeRegistros = new List<RegistroModel> ();

            string[] linhas = File.ReadAllLines ("Registros.csv");
            RegistroModel registro;
            foreach (var item in linhas) {
                if (string.IsNullOrEmpty (item)) {
                    //retorna para o foreach
                    continue;
                }
                string[] linha = item.Split (";");
                registro = new RegistroModel (
                    id: int.Parse (linha[0]),
                    nome: linha[1],
                    marca: linha[2],
                    modelo: linha[3],
                    placa: linha[4],
                    dataDeEntrada: DateTime.Parse (linha[4])
                );
                listaDeRegistros.Add (registro);
            }
            return listaDeRegistros;
        }
    }
}