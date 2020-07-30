using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

namespace aeform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            ESRI.ArcGIS.RuntimeManager.BindLicense(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand openfile = new ControlsAddDataCommandClass();
            openfile.OnCreate(axMapControl1.Object);
            openfile.OnClick();
        }

        private void saveastoolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ICommand saveas = new ControlsSaveAsDocCommandClass();
            saveas.OnCreate(axMapControl1.Object);
            saveas.OnClick();
        }

        private void inoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand inout = new ControlsMapZoomPanToolClass();
            inout.OnCreate(axMapControl1.Object);
            axMapControl1.CurrentTool = inout as ITool;
        }

        private IFeatureLayer player = null;
        private void zoomtotheplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (player != null)
            {
                (axMapControl1.Map as IActiveView).Extent = player.AreaOfInterest;
                (axMapControl1.Map as IActiveView).PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

            }
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if(e.button == 2)
            {
                esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap bmp = null;
                ILayer layer = null;
                object unk = null;
                object data = null;
                axTOCControl1.HitTest(e.x, e.y, ref item, ref bmp, ref layer, ref unk, ref data);
                player = layer as IFeatureLayer;
                if (item == esriTOCControlItem.esriTOCControlItemLayer && player != null)
                {
                    contextMenuStrip1.Show(Control.MousePosition);
                }
            }
        }

        private Form3 att = null;
        private void attributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(att == null || att.IsDisposed)
            {
                att = new Form3();
            }

            att.currentmap = axMapControl1.Map;
            att.getlayer = player;
            att.start();
            att.Show();
        }

        private void readattributeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
