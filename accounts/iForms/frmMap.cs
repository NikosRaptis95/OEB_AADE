using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using Syncfusion.Windows.Forms;

namespace DesktopBusiness.iForms
{
    public partial class frmMap: templates.Forms.def
    {

        #region formDefinition
        public frmMap(List<string> ids, List<string> descs, List<string> addrs)
        {
            InitializeComponent();
            Ids = ids;
            Descs = descs;
            Addrs = addrs;           
            initMap();
            loadMapProviders();
            loadSynFl();
        }      

        #endregion

        #region interface
        private void button1_Click(object sender, EventArgs e)
        {         
            this.gMapControl1.Position = GetAddress(textBox1.Text);            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ClearPoints();
        }
        private void gMapControl1_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            if (item.Tag.ToString().Length > 0)
            {
                string id = item.Tag.ToString();
                MForms.frmSynFl f = new MForms.frmSynFl(id, accountsClassLibrary.SynFl.TypeOfSynFl.All);
                f.MdiParent = this.ParentForm; ;
                f.Show();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < GMap.NET.MapProviders.GMapProviders.List.Count; i++)
            {
                if (GMap.NET.MapProviders.GMapProviders.List[i].Name == comboBox1.SelectedItem.ToString() && comboBox1.SelectedItem.ToString().Length>0)
                {
                    gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.List[i];
                }
            }
        }
        #endregion

        #region buttons

        #endregion

        #region GeneralFuncsAndVars
        private List<string> Ids;
        private List<string> Descs;
        private List<string> Addrs;

        private void loadSynFl()
        {
            Cursor.Current = Cursors.WaitCursor;
            int i;
            textBox1.Items.Clear();
            for (i=0; i< Ids.Count; i++)
            {  if (Addrs[i].Length > 0)
                {
                    PointAddress(Addrs[i], Descs[i], Ids[i], GMap.NET.WindowsForms.Markers.GMarkerGoogleType.orange_small);
                    textBox1.Items.Add(Addrs[i]);
                }
            }
            accountsClassLibrary.FilPin f = new accountsClassLibrary.FilPin();
            f.Read("xr001");
            string desc = f.Fields.Name;
            f.Read("xr003");
            string addr = f.Fields.Name;
            PointAddress(addr, desc, "", GMap.NET.WindowsForms.Markers.GMarkerGoogleType.pink_pushpin);
            Cursor.Current = Cursors.Default;
        }


        private void loadMapProviders()
        {
            comboBox1.ValueMember = "Name";
            comboBox1.DataSource = GMap.NET.MapProviders.GMapProviders.List;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.BingMap;
            comboBox1.SelectedItem = gMapControl1.MapProvider;
        }


        private void initMap()
        {
            gMapControl1.Bearing = 0;
            gMapControl1.CanDragMap = true;
            gMapControl1.GrayScaleMode = false;
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Zoom = 16;
            gMapControl1.Manager.Mode = GMap.NET.AccessMode.ServerAndCache;
        }

        private PointLatLng GetAddress(String Address)  
        {
            PointLatLng Res = new GMap.NET.PointLatLng();
            gMapControl2.Position = Res;
            gMapControl2.SetCurrentPositionByKeywords(Address);
            Res.Lat = gMapControl2.Position.Lat;
            Res.Lng = gMapControl2.Position.Lng;
            return Res;
        }


        private void PointAddress(string myAddress,string  desc, string myID, GMap.NET.WindowsForms.Markers.GMarkerGoogleType MarkPoint)
        {
            try
            {
                GMap.NET.PointLatLng MyLL = new PointLatLng();
                GMap.NET.WindowsForms.GMapOverlay overlayOne = new GMap.NET.WindowsForms.GMapOverlay();
                MyLL = GetAddress(myAddress);
                if (MyLL.Lat == 0 && MyLL.Lng == 0) { return; }
                this.gMapControl1.Position = MyLL;
                GMap.NET.WindowsForms.Markers.GMarkerGoogle MyM = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(MyLL, MarkPoint);
                MyM.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.OnMouseOver;
                MyM.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;
                MyM.ToolTipText = desc + "\n" + myAddress;
                MyM.Tag = myID;
                overlayOne.Markers.Add(MyM);
                gMapControl1.Overlays.Add(overlayOne);           
            }
            catch { }

        }

        private void ClearPoints()
        {
            try
            {
                gMapControl1.Overlays.Clear();
                initMap();
                loadSynFl();
            }
            catch { }

        }

        #endregion

        
    }
}
