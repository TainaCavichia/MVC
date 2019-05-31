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
            StreamWriter sw = new StreamWriter ("DataBase/Registros.csv", true);
            sw.WriteLine ($"{registro.Id};{registro.Nome};{registro.Marca};{registro.Modelo};{registro.Placa};{registro.DataDeEntrada}");
            sw.Close ();

            return registro;
        }
        public List<RegistroModel> Listar () {
            List<RegistroModel> listaDeRegistros = new List<RegistroModel> ();

            string[] linhas = File.ReadAllLines ("DataBase/Registros.csv");
            foreach (var item in linhas) {
                if (string.IsNullOrEmpty (item)) {
                    //retorna para o foreach
                    continue;
                }
                string[] linha = item.Split (";");
                var registroRecuperado = new RegistroModel();

                registroRecuperado.Id = int.Parse(linha[0]);
                registroRecuperado.Nome = linha[1];
                registroRecuperado.Marca = linha[2];
                registroRecuperado.Modelo = linha[3];
                registroRecuperado.Placa = linha[4];
                registroRecuperado.DataDeEntrada = DateTime.Parse (linha[5]);

                listaDeRegistros.Add (registroRecuperado);
            }
            return listaDeRegistros;
        }
    }
}