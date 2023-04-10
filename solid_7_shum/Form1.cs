using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace solid_7_shum
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем активный документ SolidWorks
            SldWorks swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");

            ModelDoc2 swModel = swApp.ActiveDoc;
            PartDoc swPart = (PartDoc)swModel;

            // имя грани, которую нужно выбрать
            string faceName = "хуй";

            // выбираем грань по имени
            bool status = swModel.Extension.SelectByID2(faceName, "FACE", 0, 0, 0, false, 0, null, 0);


           
        }
    }
}
