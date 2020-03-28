using System.Drawing;

namespace impresoraText
{
    public class Estilo
    {
        public Font Fuente;
    
        private Estilo(Font fuente, int totalCaracteresPorLinea)
        {
        }

        public static Estilo Obtener(TipoEstilo tipoEstilo, bool negrita)
        {
            switch (tipoEstilo)
            {
                case TipoEstilo.Titulo when negrita:
                    return new Estilo(new Font("Courier New", 12, FontStyle.Bold), 30);

                default:
                        throw new System.Exception();
            }

        }
    }
}
