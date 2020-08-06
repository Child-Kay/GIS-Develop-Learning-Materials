using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.AnalysisTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.DataSourcesRaster;

namespace toRaster
{
    public partial class PointToRaster : Form
    {
        public PointToRaster()
        {
            // 绑定运行时
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);

            InitializeComponent();
        }

        private void toRaster_Click(object sender, EventArgs e)
        {
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;

            int pLayerId = -1;
            ILayer pLayer = null;
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                pLayer = axMapControl1.get_Layer(i);
                //if (pLayer is IFeatureLayer && pLayer.Name == "质点")
                if (pLayer is IFeatureLayer)
                {
                    pLayerId = i;
                }
            }
            if (pLayerId == -1)
            {
                MessageBox.Show("找不到点图层，请重新加载", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                ESRI.ArcGIS.ConversionTools.FeatureToRaster ptr = new ESRI.ArcGIS.ConversionTools.FeatureToRaster();

                // 获得点图层
                IFeatureLayer pfeatureLayer = axMapControl1.get_Layer(pLayerId) as IFeatureLayer;
                IFeatureClass feaureClass = pfeatureLayer.FeatureClass;

                ptr.in_features = pfeatureLayer;
                string filepath = @"d:\gis\";
                ptr.out_raster = filepath + pfeatureLayer.Name + ".tif"; // 将转换结果保存为tif格式
                ptr.field = "id"; // 设置根据那个字段进行转换
                ptr.cell_size = 64; // 设置转换后的栅格像元大小
                gp.Execute(ptr, null); // 执行 GP 工具

                MessageBox.Show("转换成功！", "恭喜你！", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                // 加载栅格
                IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory();
                IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(filepath, 0);
                IRasterWorkspace pRasterWorkspace = pWorkspace as IRasterWorkspace;
                IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pfeatureLayer.Name + ".tif");
                IRaster pRaster= pRasterDataset.CreateDefaultRaster();
                IRasterLayer pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromRaster(pRaster);
                ILayer layer = pRasterLayer as ILayer;
                axMapControl1.AddLayer(layer, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("转换失败！", "很遗憾！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
