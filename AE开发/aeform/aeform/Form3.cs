using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace aeform
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public IMap currentmap;
        private IFeatureLayer currentlayer;

        public IFeatureLayer getlayer
        {
            set { currentlayer = value; }
            get { return currentlayer; }
        }
        public void start()
        {
            if (currentlayer == null)
            {
                return;
            }
            DataTable datadt = new DataTable();
            DataRow rrow = null;
            DataColumn ccol = null;
            IField ifield = null;
            for (int i = 0; i < currentlayer.FeatureClass.Fields.FieldCount; i++)
            {
                ifield = currentlayer.FeatureClass.Fields.get_Field(i);
                ccol = new DataColumn();
                ccol.ColumnName = ifield.AliasName;
                datadt.Columns.Add(ccol);
            }
            IFeatureCursor fcursor = currentlayer.Search(null, true);
            IFeature pfeature = fcursor.NextFeature();
            while (pfeature != null)
            {
                rrow = datadt.NewRow();
                for (int i = 0; i < datadt.Columns.Count; i++)
                {
                    rrow[i] = pfeature.get_Value(i);
                }
                datadt.Rows.Add(rrow);
                pfeature = fcursor.NextFeature();
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(fcursor);
            gridControl1.DataSource = datadt;
            gridView1.OptionsView.ShowGroupPanel = false;
            double total = datadt.AsEnumerable().Select(d => Convert.ToDouble(d.Field<string>("Area"))).Sum();

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
        }
    }
}
