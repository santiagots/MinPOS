using System.Windows.Forms;

namespace FormUI.Componentes
{
    public class DataGridViewSiNoCellColumn : DataGridViewColumn
    {
        public DataGridViewSiNoCellColumn()
        {
            this.CellTemplate = new DataGridViewSiNoCell();
        }
    }
}
