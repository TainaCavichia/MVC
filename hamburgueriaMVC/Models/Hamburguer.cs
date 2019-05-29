using Microsoft.Extensions.Primitives;

namespace hamburgueriaMVC.Models
{
    public class Hamburguer : Produto
    {
        public Hamburguer()
        {
            
        }
        public Hamburguer(StringValues Nome, double Preco)
        {
            this.Nome = Nome;
            this.Preco = Preco;
        }
    }
}