namespace Estacionamento.MVC.Models
{
    public class ModeloModel
    {
        public int Id {get;set;}
        public string Modelo {get;set;}

        public ModeloModel(string modelo)
        {
            this.Modelo = modelo;
        }

        public ModeloModel()
        {
        }
    }
}