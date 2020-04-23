﻿using System.Drawing;
using System.Windows.Forms;

namespace FormUI.Componentes
{
    public class DataGridViewSiNoCell : DataGridViewTextBoxCell
    {
        protected override void Paint(
              Graphics graphics,
              Rectangle clipBounds,
              Rectangle cellBounds,
              int rowIndex,
              DataGridViewElementStates cellState,
              object value, object formattedValue,
              string errorText,
              DataGridViewCellStyle cellStyle,
              DataGridViewAdvancedBorderStyle
              advancedBorderStyle,
              DataGridViewPaintParts paintParts)
            {
            formattedValue = (bool)value ? "Si" : "No";

            base.Paint(graphics, clipBounds,
                    cellBounds, rowIndex, cellState,
                    value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle,
                    paintParts);
            }
    }
}
