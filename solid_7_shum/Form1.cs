using SolidWorks.Interop.sldworks;
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

            // Получаем массив всех сущностей детали
            FeatureManager swFeatMgr = swModel.FeatureManager;
            object[] swFeatures = (object[])swFeatMgr.GetFeatures(true);

            // Создаем пустой список граней
            List<Face2> facesList = new List<Face2>();

            // Обходим все сущности и добавляем их грани в список
            foreach (object feature in swFeatures)
            {
                if (feature is Body2)
                {
                    Body2 swBody = (Body2)feature;
                    object[] swFaces = (object[])swBody.GetFaces();

                    foreach (object face in swFaces)
                    {
                        if (face is Face2)
                        {
                            facesList.Add((Face2)face);
                        }
                    }
                }
            }

            // Преобразуем список граней в массив
            Face2[] facesArray = facesList.ToArray();

            MessageBox.Show($"{facesArray.Length}");
        }
    }
}
