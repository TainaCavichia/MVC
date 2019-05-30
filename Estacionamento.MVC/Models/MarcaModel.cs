namespace Estacionamento.MVC.Models
{
    public class MarcaModel
    {
        public int Id {get;set;}
        public string Marca {get;set;}

        public MarcaModel( string marca)
        {
            this.Marca = marca;
        }

        public MarcaModel()
        {
        }
    }
}