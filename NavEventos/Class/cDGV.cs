using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NavEventos.Class
{
    public class cDGV
    {
        public DataGridView Grade(DataGridView dg)
        {
            dg.EditMode = DataGridViewEditMode.EditProgrammatically;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.AutoGenerateColumns = false;
            dg.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8);
            dg.EnableHeadersVisualStyles = false; // Desabilita formatação padrão
            dg.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            //dg.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            //dg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dg.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dg.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            //dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dg.MultiSelect = false;
            return dg;
        }
    }
}
