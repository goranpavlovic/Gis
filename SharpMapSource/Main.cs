﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSGeo.GDAL;
<<<<<<< HEAD
<<<<<<< HEAD
using SharpMap.Layers;
using SharpMapSource.Layers;
using SharpMapSource.Interface;
using SharpMap.Data.Providers;

namespace SharpMapSource
{
    

    public partial class Main : Form
    {
        private SharpMap.Map _sharpMap;
        private LayerManager _manager;
        private SharpMap.Geometries.LinearRing select;
        private IList<Point> poligon;
        private bool _polySelection;

        private AvailableModes _applicationMode;

namespace SharpMapSource
{
    public partial class Main : Form
    {
        private SharpMap.Map _sharpMap;

        private const float ZOOM_FACTOR = 0.3f;
        private String DATA_NAME = "World Countries";
        private String DATA_PATH = "Data//world_adm0.shp";
        SharpMap.Geometries.LinearRing select;

        private LayerManager _manager;


        private const float ZOOM_FACTOR = 0.3f;
        //private String DATA_NAME = "World Countries";
        //private String DATA_PATH = "Data//world_adm0.shp";
        //pan image
        private Point _panCoordinate;
        private Image _backupImage;
        private Point _selectionDownCoordinate;
        private Point _selectionLastDownCoordinate;

        public Main()
        {
            InitializeComponent();
            _sharpMap = new SharpMap.Map(this._sharpMapImage.Size);
            _sharpMap.BackColor = Color.White;
            this._manager = new LayerManager(this._sharpMap);
            this.select = new SharpMap.Geometries.LinearRing();
            this.poligon = new List<Point>();
            this._applicationMode = AvailableModes.ImagePan;
            this._selectionDownCoordinate = new Point();
            this._selectionLastDownCoordinate = new Point();
            this._backupImage = null;
            this._polySelection = false;
            select = new SharpMap.Geometries.LinearRing();
            _sharpMap = new SharpMap.Map(this.pbxMapa.Size);
            _sharpMap.BackColor = Color.WhiteSmoke;

            /*String path;
            _sharpMap = new SharpMap.Map(this._sharpMapImage.Size);
            _sharpMap.BackColor = Color.White;
            this._manager = new LayerManager(this._sharpMap);

            RefreshMap();
        }

        public void RefreshMap()
        {
            if (this._sharpMap.Size.Width == 0 || this._sharpMap.Size.Height == 0)
            {
                this._sharpMapImage.Image = null;
            }
            else
            {
                if (_sharpMap.Layers.Count != 0)
                    this._sharpMapImage.Image = _sharpMap.GetMap();
                else
                    this._sharpMapImage.Image = null;
            }
            if (_sharpMap.Layers.Count != 0)
                this._sharpMapImage.Image = _sharpMap.GetMap();
            else
                this._sharpMapImage.Image = null;

        }

        private void btnRemoveLayer_Click(object sender, EventArgs e)
        {
            if (this._dataGridLayers.SelectedRows.Count > 0)
            {
                if (this._dataGridLayers.SelectedRows[0].Index >= 0)
                {
                    _sharpMap.Layers.RemoveAt(this._dataGridLayers.SelectedRows[0].Index);
                    this._dataGridLayers.Rows.RemoveAt(this._dataGridLayers.SelectedRows[0].Index);
                    if (_sharpMap.Layers.Count != 0)
                    {
                        _sharpMap.ZoomToExtents();
                    }
                    RefreshMap();
                }
            }
        }

        private void menyAddVectorLayer_Click(object sender, EventArgs e)
        {
            String path;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "shp Files (.shp)|*.shp|All Files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                path = dialog.FileName;
            else
                path = DATA_PATH;
            //SharpMap.Layers.VectorLayer layer = new SharpMap.Layers.VectorLayer(DATA_NAME);
            //layer.DataSource = new SharpMap.Data.Providers.ShapeFile(DATA_PATH);
            SharpMap.Layers.VectorLayer layer = new SharpMap.Layers.VectorLayer(dialog.SafeFileName);
            layer.DataSource = new SharpMap.Data.Providers.ShapeFile(path);
            layer.Style.Fill = Brushes.LightGreen;
            layer.Style.EnableOutline = true;
            layer.Style.Outline = Pens.DarkGreen;*/
            //dodavanje labele
            /*SharpMap.Layers.LabelLayer labelLayer = new SharpMap.Layers.LabelLayer("Country Names");
            labelLayer.DataSource = layer.DataSource;
            labelLayer.LabelColumn = "NAME";
            labelLayer.Style.CollisionDetection = true;
            //labelLayer.Style.CollisionBuffer = new SizeF(10, 10);
            labelLayer.LabelFilter = SharpMap.Rendering.LabelCollisionDetection.ThoroughCollisionDetection;
            labelLayer.MultipartGeometryBehaviour = SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum.Largest;
            labelLayer.Style.Font = new Font(FontFamily.GenericSansSerif, 8);

            _sharpMap.Layers.Add(labelLayer);*/
           /* _sharpMap.Layers.Add(layer);
            this.lbxLayers.Items.Add(layer.LayerName);
            _sharpMap.ZoomToExtents();*/

            RefreshMap();
        }

        public void RefreshMap()
        {
            if (_sharpMap.Layers.Count != 0)
                pbxMapa.Image = _sharpMap.GetMap();
            else
                pbxMapa.Image = null;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            _sharpMap.Zoom -= _sharpMap.Zoom * ZOOM_FACTOR; 
            RefreshMap();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
            {
                path = dialog.FileName;
                if (File.Exists(path))
                {
                    string layerName = Path.GetFileNameWithoutExtension(path);
                    bool exist = false;
                    foreach (DataGridViewRow row in this._dataGridLayers.Rows)
                    {
                        if (string.Equals((string)row.Cells[1].Value, layerName))
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (exist == false)
                    {
                        this._manager.AddVectorLayer(layerName, new SharpMap.Data.Providers.ShapeFile(path));
                        this._dataGridLayers.Rows.Add(true, layerName);
                    }
                    else
                    {
                        MessageBox.Show("Layer " + layerName + " allready exists!!!"
                            , "Sharp Map Source", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            try
            {
                _sharpMap.ZoomToExtents();
                RefreshMap();
            }
            catch (Exception)
            {
                //MessageBox.Show("Layer already inserted");
            }
        }

        private void menuAddRasterLayer_Click(object sender, EventArgs e)
        {
            SharpMap.Layers.ILayer layer = _sharpMap.Layers["RasterLayer"];
            String path;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                path = dialog.FileName;
                if (File.Exists(path))
                {
                    bool exist = false;
                    foreach (DataGridViewRow row in this._dataGridLayers.Rows)
                    {
                        if (String.Equals((string)row.Cells[1].Value, dialog.SafeFileName))
                        {
                            exist = true;
                        }
                    }
                    if (exist == false)
                    {
                        this._manager.AddRasterLayer(Path.GetFileNameWithoutExtension(path), path);
                        this._dataGridLayers.Rows.Add(true, Path.GetFileNameWithoutExtension(path));
                    }
                    else
                    {
                        MessageBox.Show("Layer " + dialog.SafeFileName + " allready exist!!!", "Sharp Map Source"
                            , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    RefreshMap();
                }
            }
        }

        private void menuAddLabelLayer_Click(object sender, EventArgs e)
        {
            LabelLayerAddDialog dijalog = new LabelLayerAddDialog(this._sharpMap);
            if(dijalog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String layer = dijalog.retLayer;
                String name = dijalog.retName;

                SharpMap.Layers.LabelLayer labelLayer = new LabelLayer(layer + name);
                SharpMap.Layers.VectorLayer lay = _sharpMap.GetLayerByName(layer) as SharpMap.Layers.VectorLayer;
                if (lay != null)
                {
                    labelLayer.DataSource = lay.DataSource;
                    labelLayer.LabelColumn = name;
                    labelLayer.Style.CollisionDetection = true;
                    //labelLayer.Style.CollisionBuffer = new SizeF(10, 10);
                    labelLayer.LabelFilter = SharpMap.Rendering.LabelCollisionDetection.ThoroughCollisionDetection;
                    labelLayer.MultipartGeometryBehaviour = SharpMap.Layers.LabelLayer.MultipartGeometryBehaviourEnum.Largest;
                    labelLayer.Style.Font = new Font(FontFamily.GenericSansSerif, 8);

                    _sharpMap.Layers.Add(labelLayer);
                    this.RefreshMap();

                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Geografski informacioni sistemi i tehnologije");
        }

        private void toolZoomIn_Click(object sender, EventArgs e)
        {
            _sharpMap.Zoom -= _sharpMap.Zoom * ZOOM_FACTOR;
            RefreshMap();
        }

        private void toolZoomOut_Click(object sender, EventArgs e)
        {
            _sharpMap.Zoom += _sharpMap.Zoom * ZOOM_FACTOR;
            RefreshMap();
        }
		
        private void btnZoomFull_Click(object sender, EventArgs e)
        {
            if(_sharpMap.Layers.Count != 0)

        private void toolZoomToExtends_Click(object sender, EventArgs e)
        {
            if (_sharpMap.Layers.Count != 0)
                _sharpMap.ZoomToExtents();
            RefreshMap();
        }

        private void toolEditLayer_Click(object sender, EventArgs e)
        {

        }

        private void toolDeleteLayer_Click(object sender, EventArgs e)
        {
            if (this._dataGridLayers.SelectedRows.Count > 0)
            {
                if (this._dataGridLayers.SelectedRows[0].Index >= 0)
                {
                    _sharpMap.Layers.RemoveAt(this._dataGridLayers.SelectedRows[0].Index);
                    this._dataGridLayers.Rows.RemoveAt(this._dataGridLayers.SelectedRows[0].Index);
                    if (_sharpMap.Layers.Count != 0)
                    {
                        _sharpMap.ZoomToExtents();
                    }
                    RefreshMap();
                }
            }
        }

        private void sharpMapImage_MouseMove(SharpMap.Geometries.Point WorldPos, MouseEventArgs ImagePos)
        {
            this.lblWorldCoordiantes.Text = "World Coordinates: " + WorldPos.X + ":" + WorldPos.Y;
            this.lblImageCoordinates.Text = "Image Coordinates: " + ImagePos.X + ":" + ImagePos.Y;
            if (this._applicationMode == AvailableModes.SelectFeaturesByRectangle)
            {
                if (this._sharpMapImage.Image != null)
                {
                    if (ImagePos.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        Point currentPoint = ImagePos.Location;
                        if (this._selectionLastDownCoordinate.X != -1)
                        {
                            //draw reverse rectanhgle selectionDown, selectionLastDown
                            this.DrawRectangle(this._selectionDownCoordinate, this._selectionLastDownCoordinate);
                        }
                        this._selectionLastDownCoordinate = ImagePos.Location;
                        //Draw reversible rectangle // selectionDown, current
                        this.DrawRectangle(this._selectionDownCoordinate, currentPoint);
                    }
                }
            }
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            this._sharpMap.Size = this._sharpMapImage.Size;
            this.RefreshMap();
        }

        private void DrawRectangle(Point p1, Point p2)
        {
            Image image = (Image)this._backupImage.Clone();

            Graphics g = Graphics.FromImage(image);


            Rectangle rectangle = new Rectangle();
            if (p1.X < p2.X)
            {
                rectangle.X += p1.X;
                rectangle.Width += p2.X - p1.X;
            }
            else
            {
                rectangle.X += p2.X;
                rectangle.Width += p1.X - p2.X;
            }
            if (p1.Y < p2.Y)
            {
                rectangle.Y += p1.Y;
                rectangle.Height += p2.Y - p1.Y;
            }
            else
            {
                rectangle.Y += p2.Y;
                rectangle.Height += p1.Y - p2.Y;
            }
            g.DrawRectangle(new Pen(Color.Red),rectangle);
            this._sharpMapImage.Image = image;
            this._sharpMapImage.Invalidate();
        }

        private void sharpMapImage_MouseUp(SharpMap.Geometries.Point WorldPos, MouseEventArgs ImagePos)
        {
            if (this._applicationMode == AvailableModes.ImagePan)
            {
                if (ImagePos.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point mapCenter = new Point(this._sharpMapImage.Size.Width / 2 - ImagePos.Location.X + this._panCoordinate.X
                            , this._sharpMapImage.Size.Height / 2 - ImagePos.Location.Y + this._panCoordinate.Y);
                    this._sharpMap.Center = this._sharpMap.ImageToWorld(mapCenter);
                    this.RefreshMap();
                }
            }
            else if(this._applicationMode == AvailableModes.IdentifyFeature)
            {
            }
            else if (this._applicationMode == AvailableModes.SelectFeaturesByRectangle)
            {
                if (this._sharpMapImage.Image != null)
                {
                    if (ImagePos.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        if (this._selectionLastDownCoordinate.X != -1)
                        {
                            //draw polygon selectiondowncoordinate, selectionlastcoordinate
                            this.DrawRectangle(this._selectionDownCoordinate, this._selectionLastDownCoordinate);
                        }
                        this._sharpMapImage.Image = this._backupImage;
                        this._sharpMapImage.Invalidate();

                        this._selectionDownCoordinate.X = -1;
                        this._selectionDownCoordinate.Y = -1;

                        this._selectionLastDownCoordinate.X = -1;
                        this._selectionLastDownCoordinate.Y = -1;

                    }
                }
            }
            else if(this._applicationMode == AvailableModes.SelectFeaturesByPolygon)
            {
            }
            /*
            if (ImagePos.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (Control.ModifierKeys == Keys.Shift || Control.ModifierKeys == Keys.Control)
                { 
                }
                else
                {
                    Point mapCenter = new Point(this._sharpMapImage.Size.Width / 2 - ImagePos.Location.X + this._panCoordinate.X
                        , this._sharpMapImage.Size.Height / 2 - ImagePos.Location.Y + this._panCoordinate.Y);
                    this._sharpMap.Center = this._sharpMap.ImageToWorld(mapCenter);
                    this.RefreshMap();
                }
            }
             */
        }

        private void _sharpMapImage_MouseDown(SharpMap.Geometries.Point WorldPos, MouseEventArgs ImagePos)
        {
            if (this._applicationMode == AvailableModes.ImagePan)
            {
                if (ImagePos.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this._panCoordinate = ImagePos.Location;
                }
            }
            else if (this._applicationMode == AvailableModes.IdentifyFeature)
            {
                var pp = _sharpMap.ImageToWorld(ImagePos.Location);
                SharpMap.Data.FeatureDataSet ds = new SharpMap.Data.FeatureDataSet();
                String str = "";
                foreach (var layer in _sharpMap.Layers)
                {
                    //var queryLayer = layer as SharpMap.Layers.ICanQueryLayer;
                    //if (queryLayer != null)
                    //{
                    VectorLayer vLay = layer as VectorLayer;
                    if (vLay != null && vLay.LayerName != "selected layer")
                    {
                        SharpMap.Data.Providers.NtsProvider provider;
                        if (!(vLay.DataSource is SharpMap.Data.Providers.PostGIS))
                        {
                            provider = new NtsProvider(vLay.DataSource);
                            provider.ExecuteIntersectionQuery(pp.GetBoundingBox().Grow(_sharpMap.Zoom / 1000), ds);
                        }
                        else
                        {
                            vLay.DataSource.ExecuteIntersectionQuery(pp.GetBoundingBox().Grow(_sharpMap.Zoom / 1000), ds);
                        }


                        //queryLayer.ExecuteIntersectionQuery(pp.GetBoundingBox().Grow(_sharpMap.Zoom / 1000), ds);
                        foreach (SharpMap.Data.FeatureDataTable tab in ds.Tables)
                        {
                            foreach (SharpMap.Data.FeatureDataRow dr in tab)
                            {
                                foreach (object o in dr.ItemArray)
                                {
                                    str += o.ToString() + " | " + _sharpMap.Zoom.ToString();
                                }
                                str += "\n";
                            }
                            showData(tab);
                        }
                        // }
                    }
                }
                //MessageBox.Show(str);
                SharpMap.Layers.VectorLayer lay = new SharpMap.Layers.VectorLayer("selected layer", new SharpMap.Data.Providers.GeometryFeatureProvider(ds.Tables[0]));
                lay.Style.Fill = Brushes.Yellow;
                //_manager.AddVectorLayer(lay.LayerName,lay.DataSource);
                ILayer layerToRemove = _sharpMap.GetLayerByName("selected layer");
                if (layerToRemove != null)
                {
                    _sharpMap.Layers.Remove(layerToRemove);
                }
                _sharpMap.Layers.Add(lay);

                this.RefreshMap();

                // _sharpMap.Layers.Remove(lay);
            }
            else if (this._applicationMode == AvailableModes.SelectFeaturesByRectangle)
            {
                if (ImagePos.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (this._sharpMapImage.Image != null)
                    {
                        this._backupImage = (Image)this._sharpMapImage.Image.Clone();

                        this._selectionDownCoordinate.X = ImagePos.X;
                        this._selectionDownCoordinate.Y = ImagePos.Y;

                        this._selectionLastDownCoordinate.X = -1;
                        this._selectionLastDownCoordinate.Y = -1;
                    }
                }
            }
            else if (this._applicationMode == AvailableModes.SelectFeaturesByPolygon)
            {
                SharpMap.Geometries.Point point = new SharpMap.Geometries.Point(ImagePos.X, ImagePos.Y);
                select.Vertices.Add(point);
                poligon.Add(new Point(ImagePos.X,ImagePos.Y));
                //Graphics olovka = this.CreateGraphics();
                if (this._polySelection == false)
                {
                    if (this._sharpMapImage.Image != null)
                    {
                        this._backupImage = (Image)this._sharpMapImage.Image.Clone();
                    }
                }
                this._polySelection = true;
                this.DrawPolygon();

                if (ImagePos.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this._polySelection = false;
                    this._sharpMapImage.Refresh();
                    SharpMap.Geometries.LinearRing pom = new SharpMap.Geometries.LinearRing();
                    foreach (Point p in poligon)
                    {
                        pom.Vertices.Add(_sharpMap.ImageToWorld(p));
                    }
                    var pp = _sharpMap.ImageToWorld(ImagePos.Location);
                    SharpMap.Data.FeatureDataSet ds = new SharpMap.Data.FeatureDataSet();
                    String str = "";
                    foreach (var layer in _sharpMap.Layers)
                    {
                        //var queryLayer = layer as SharpMap.Layers.ICanQueryLayer;
                        // if (queryLayer != null)
                        // {
                        select.Vertices.Add(select.Vertices[0]);
                        poligon.Add(poligon[0]);
                        pom.Vertices.Add(_sharpMap.ImageToWorld(poligon[0]));
                        SharpMap.Geometries.Polygon poly = new SharpMap.Geometries.Polygon(pom);
                        VectorLayer vect = layer as VectorLayer;
                        if (vect != null && vect.LayerName != "selected layer")
                        {
                            SharpMap.Data.Providers.NtsProvider provider;
                            if (!(vect.DataSource is SharpMap.Data.Providers.PostGIS))
                            {
                                provider = new SharpMap.Data.Providers.NtsProvider(vect.DataSource);
                                provider.ExecuteIntersectionQuery(poly.GetBoundingBox(), ds);
                            }
                            else
                            {
                                vect.DataSource.ExecuteIntersectionQuery(poly.GetBoundingBox(), ds);
                            }
                            //queryLayer.ExecuteIntersectionQuery(poly.GetBoundingBox(), ds);
                            foreach (SharpMap.Data.FeatureDataTable tab in ds.Tables)
                            {
                                foreach (SharpMap.Data.FeatureDataRow dr in tab)
                                {
                                    foreach (object o in dr.ItemArray)
                                    {
                                        str += o.ToString() + " | " + _sharpMap.Zoom.ToString();
                                    }
                                    str += "\n";
                                }
                                showData(tab);
                            }
                        }

                        //}
                    }
                    foreach (Point niz in poligon)
                        str += niz.ToString();
                    //MessageBox.Show(str);
                    //MessageBox.Show(str);
                    select.Vertices.Clear();
                    poligon.Clear();
                    SharpMap.Layers.VectorLayer lay = new SharpMap.Layers.VectorLayer("selected layer", new SharpMap.Data.Providers.GeometryFeatureProvider(ds.Tables[0]));
                    lay.Style.Fill = Brushes.Yellow;
                    //_manager.AddVectorLayer(lay.LayerName,lay.DataSource);
                    ILayer layerToRemove = _sharpMap.GetLayerByName("selected layer");
                    if (layerToRemove != null)
                    {
                        _sharpMap.Layers.Remove(layerToRemove);
                    }
                    _sharpMap.Layers.Add(lay);
                    RefreshMap();
                }
            }
            /*
            if (Control.ModifierKeys != Keys.Shift)
            {
                this.select.Vertices.Clear();
                this.poligon.Clear();
            }

                if (Control.ModifierKeys == Keys.Control)
                {
                    var pp = _sharpMap.ImageToWorld(ImagePos.Location);
                    SharpMap.Data.FeatureDataSet ds = new SharpMap.Data.FeatureDataSet();
                    String str = "";
                    foreach (var layer in _sharpMap.Layers)
                    {
                        //var queryLayer = layer as SharpMap.Layers.ICanQueryLayer;
                        //if (queryLayer != null)
                        //{
                        VectorLayer vLay = layer as VectorLayer;
                        if(vLay != null && vLay.LayerName != "selected layer")
                        {
                            SharpMap.Data.Providers.NtsProvider provider = new NtsProvider(vLay.DataSource);
                            provider.ExecuteIntersectionQuery(pp.GetBoundingBox().Grow(_sharpMap.Zoom / 1000), ds);

                            //queryLayer.ExecuteIntersectionQuery(pp.GetBoundingBox().Grow(_sharpMap.Zoom / 1000), ds);
                            foreach (SharpMap.Data.FeatureDataTable tab in ds.Tables)
                            {
                                foreach (SharpMap.Data.FeatureDataRow dr in tab)
                                {
                                    foreach (object o in dr.ItemArray)
                                    {
                                        str += o.ToString() + " | " + _sharpMap.Zoom.ToString();
                                    }
                                    str += "\n";
                                }
                            }
                       // }
                        }
                    }
                    MessageBox.Show(str);
                    SharpMap.Layers.VectorLayer lay = new SharpMap.Layers.VectorLayer("selected layer", new SharpMap.Data.Providers.GeometryProvider(ds.Tables[0]));
                    lay.Style.Fill = Brushes.Yellow;
                    //_manager.AddVectorLayer(lay.LayerName,lay.DataSource);
                    ILayer layerToRemove = _sharpMap.GetLayerByName("selected layer");
                    if (layerToRemove != null)
                    {
                        _sharpMap.Layers.Remove(layerToRemove);
                    }
                    _sharpMap.Layers.Add(lay);

                    this.RefreshMap();

                   // _sharpMap.Layers.Remove(lay);

                }
                else if (Control.ModifierKeys == Keys.Shift)
                {
                    SharpMap.Geometries.Point point = new SharpMap.Geometries.Point(ImagePos.X, ImagePos.Y);
                    select.Vertices.Add(point);
                    poligon.Add(new Point(ImagePos.X,ImagePos.Y));
                    //Graphics olovka = this.CreateGraphics();
                    if (ImagePos.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        this._sharpMapImage.Refresh();
                        SharpMap.Geometries.LinearRing pom = new SharpMap.Geometries.LinearRing();
                        foreach (Point p in poligon)
                        {
                            pom.Vertices.Add(_sharpMap.ImageToWorld(p));
                        }
                        var pp = _sharpMap.ImageToWorld(ImagePos.Location);
                            }
                        }
                    }
                    MessageBox.Show(str);
                    /*SharpMap.Layers.VectorLayer lay = new SharpMap.Layers.VectorLayer(new System.Random().ToString(), new SharpMap.Data.Providers.GeometryProvider(ds.Tables[0]));
                    lay.Style.Fill = Brushes.Yellow;
                    _sharpMap.Layers.Add(lay);

                    this.RefreshMap();*/
                }
                else if(Control.ModifierKeys == Keys.Control)
                {
                    SharpMap.Geometries.Point point = new SharpMap.Geometries.Point(m.X,m.Y);
                    select.Vertices.Add(point);
                    if (m.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        var pp = _sharpMap.ImageToWorld(m.Location);
                        SharpMap.Data.FeatureDataSet ds = new SharpMap.Data.FeatureDataSet();
                        String str = "";
                        foreach (var layer in _sharpMap.Layers)
                        {
                            //var queryLayer = layer as SharpMap.Layers.ICanQueryLayer;
                           // if (queryLayer != null)
                           // {
                                select.Vertices.Add(select.Vertices[0]);
                                poligon.Add(poligon[0]);
                                pom.Vertices.Add(_sharpMap.ImageToWorld(poligon[0]));
                                SharpMap.Geometries.Polygon poly = new SharpMap.Geometries.Polygon(pom);
                                VectorLayer vect = layer as VectorLayer;
                                if (vect != null && vect.LayerName != "selected layer")
                                {
                                    SharpMap.Data.Providers.NtsProvider provider = new SharpMap.Data.Providers.NtsProvider(vect.DataSource);
                                    provider.ExecuteIntersectionQuery(poly, ds);
                                    //queryLayer.ExecuteIntersectionQuery(poly.GetBoundingBox(), ds);
                                    foreach (SharpMap.Data.FeatureDataTable tab in ds.Tables)
                                    {
                                        foreach (SharpMap.Data.FeatureDataRow dr in tab)
                                        {
                                            foreach (object o in dr.ItemArray)
                                            {
                                                str += o.ToString() + " | " + _sharpMap.Zoom.ToString();
                                            }
                                            str += "\n";
                                        }
                                    }
                                }

                            //}
                        }
                        foreach (Point niz in poligon)
                            str += niz.ToString();
                        //MessageBox.Show(str);
                        MessageBox.Show(str);
                        select.Vertices.Clear();
                        poligon.Clear();
                        SharpMap.Layers.VectorLayer lay = new SharpMap.Layers.VectorLayer("selected layer", new SharpMap.Data.Providers.GeometryProvider(ds.Tables[0]));
                        lay.Style.Fill = Brushes.Yellow;
                        //_manager.AddVectorLayer(lay.LayerName,lay.DataSource);
                        ILayer layerToRemove = _sharpMap.GetLayerByName("selected layer");
                        if (layerToRemove != null)
                        {
                            _sharpMap.Layers.Remove(layerToRemove);
                        }
                        _sharpMap.Layers.Add(lay);
                        RefreshMap();
                    }
                }
                else if (ImagePos.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this._panCoordinate = ImagePos.Location;
                }
                /*else
                {
                    //--> Convert mouse click point from image coordinates to world coordinates
                    SharpMap.Geometries.Point p = _sharpMap.ImageToWorld(new PointF(ImagePos.X, ImagePos.Y));
                    //--> Recenter map
                    _sharpMap.Center.X = p.X;
                    _sharpMap.Center.Y = p.Y;
                    RefreshMap();
                }*/
        }


        public void DrawPolygon()
        {
            if (this._polySelection)
            {
                if (this.poligon.Count > 2)
                {
                    if (this._backupImage != null)
                    {
                        Image drawingImage = (Image)this._backupImage.Clone();
                        Graphics g = Graphics.FromImage(drawingImage);
                        g.DrawPolygon(new Pen(Color.Red), this.poligon.ToArray<Point>());
                        this._sharpMapImage.Image = drawingImage;
                        this._sharpMapImage.Invalidate();
                    }
                }
                else if (this.poligon.Count == 2)
                {
                    if (this._backupImage != null)
                    {
                        Image drawingImage = (Image)this._backupImage.Clone();
                        Graphics g = Graphics.FromImage(drawingImage);
                        g.DrawPolygon(new Pen(Color.Red), this.poligon.ToArray<Point>());
                        g.DrawLine(new Pen(Color.Red), this.poligon[0], this.poligon[1]);
                        this._sharpMapImage.Image = drawingImage;
                        this._sharpMapImage.Invalidate();
                    }
        private void toolEditLayer_Click(object sender, EventArgs e)
        {

        }

        private void toolDeleteLayer_Click(object sender, EventArgs e)
        {
            if (this._dataGridLayers.SelectedRows.Count > 0)
            {
                if (this._dataGridLayers.SelectedRows[0].Index >= 0)
                {
                    _sharpMap.Layers.RemoveAt(this._dataGridLayers.SelectedRows[0].Index);
                    this._dataGridLayers.Rows.RemoveAt(this._dataGridLayers.SelectedRows[0].Index);
                    if (_sharpMap.Layers.Count != 0)
                    {
                        _sharpMap.ZoomToExtents();
                    }
                    RefreshMap();

                }
            }
        }

        public void SortLayers()
        {
            LayerCollection collection = new LayerCollection();
            foreach (ILayer layer in this._sharpMap.Layers)
            {
                collection.Add(layer);
            }
            this._sharpMap.Layers.Clear();
            foreach(DataGridViewRow row in this._dataGridLayers.Rows)
            {
                string layerGridName = (string)row.Cells[1].Value;
                foreach (ILayer layer in collection)
                {
                    if (string.Equals(layerGridName, layer.LayerName))
                    {
                        this._sharpMap.Layers.Add(layer);
                        break;
                    }
                }
            }
            this.RefreshMap();
        }

        private void btnLayerDown_Click(object sender, EventArgs e)
        {
            if (this._dataGridLayers.SelectedRows.Count > 0)
            {
                int selectedRow = this._dataGridLayers.SelectedRows[0].Index;
                if (selectedRow < this._dataGridLayers.Rows.Count - 1)
                {
                    DataGridViewRow row = this._dataGridLayers.Rows[selectedRow];
                    this._dataGridLayers.Rows.Remove(row);
                    this._dataGridLayers.Rows.Insert(selectedRow + 1, row);
                    this._dataGridLayers.Rows[selectedRow + 1].Selected = true;
                    this.SortLayers();
                }
            }
        }

        private void btnLayerUp_Click(object sender, EventArgs e)
        {
            if (this._dataGridLayers.SelectedRows.Count > 0)
            { 
                int selectedIndex = this._dataGridLayers.SelectedRows[0].Index;
                if (selectedIndex > 0)
                {
                    DataGridViewRow row = this._dataGridLayers.Rows[selectedIndex];
                    this._dataGridLayers.Rows.Remove(row);
                    this._dataGridLayers.Rows.Insert( selectedIndex - 1,row);
                    this._dataGridLayers.Rows[selectedIndex - 1].Selected = true;
                    this.SortLayers();
                }
            }
        }

        private void addPostGisVectorLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPostGisLayer layerDialog = new AddPostGisLayer();
            layerDialog.StartPosition = FormStartPosition.CenterParent;
            //layerDialog.Parent = this;
            layerDialog.addedPostGisLayer += new AddedPostGisLayer(this.AddedNewPostGisLayer);
            layerDialog.ShowDialog();
        }

        private void AddedNewPostGisLayer(object sender, PostGisEventArgs e)
        {
            bool exists = false;
            foreach(DataGridViewRow row in this._dataGridLayers.Rows)
            {
                if(string.Equals( (string)row.Cells[1].Value,e.LayerName))
                {
                    exists = true;
                }
            }
            if (exists == false)
            {
                this._manager.AddVectorLayer(e.LayerName, e.PostGis);
                this._dataGridLayers.Rows.Add(true, e.LayerName);
                //MessageBox.Show(e.LayerName);
                try
                {
                    _sharpMap.ZoomToExtents();
                    RefreshMap();
                }
                catch (Exception)
                {
                    //MessageBox.Show("Layer already inserted");
                }
            }
        }

        private void toolPan_Click(object sender, EventArgs e)
        {
            this._applicationMode = AvailableModes.ImagePan;
            this._sharpMapImage.ActiveTool = SharpMap.Forms.MapImage.Tools.Pan;
            this.select.Vertices.Clear();
            this.poligon.Clear();
        }

        private void toolIdentifyFeature_Click(object sender, EventArgs e)
        {
            this._applicationMode = AvailableModes.IdentifyFeature;
            this._sharpMapImage.ActiveTool = SharpMap.Forms.MapImage.Tools.None;
        }

        private void toolSelectByRectangle_Click(object sender, EventArgs e)
        {
            this._applicationMode = AvailableModes.SelectFeaturesByRectangle;
            this._sharpMapImage.ActiveTool = SharpMap.Forms.MapImage.Tools.None;
            this.select.Vertices.Clear();
            this.poligon.Clear();
        }

        private void toolSelectByPolygon_Click(object sender, EventArgs e)
        {
            this._applicationMode = AvailableModes.SelectFeaturesByPolygon;
            this._sharpMapImage.ActiveTool = SharpMap.Forms.MapImage.Tools.None;
            this.select.Vertices.Clear();
            this.poligon.Clear();
        }

        private void showData(SharpMap.Data.FeatureDataTable tabela)
        {
            LayerInfo lay = new LayerInfo(tabela);
            //LayerInfo lay = new LayerInfo();
            lay.Show();
        }

        private void spatialQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpatialQuery query = new SpatialQuery(_sharpMap, this);
            query.Show();
        private void pbxMapa_MouseMove(object sender, MouseEventArgs e)
        {
            SharpMap.Geometries.Point p = _sharpMap.ImageToWorld(new PointF(e.X, e.Y));
            lbCoord.Text = "Coord:" + p.X + " : " + p.Y;
        }

        private void brnAddLayer_Click(object sender, EventArgs e)
        {
            String path;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "shp Files (.shp)|*.shp|All Files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.Multiselect = false;
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
                path = dialog.FileName;
            else
                path = DATA_PATH;
            SharpMap.Layers.VectorLayer layer = new SharpMap.Layers.VectorLayer(dialog.SafeFileName);
            //layer.DataSource = new SharpMap.Data.Providers.ShapeFile(DATA_PATH);
            layer.DataSource = new SharpMap.Data.Providers.ShapeFile(path);
            layer.Style.Fill = Brushes.Red;
            layer.Style.EnableOutline = true;
            layer.Style.Outline = Pens.OrangeRed;

            //MessageBox.Show(layer.DataSource.GetFeatureCount().ToString());

            try
            {
                _sharpMap.Layers.Add(layer);
                _sharpMap.ZoomToExtents();
                RefreshMap();
                this.lbxLayers.Items.Add(layer.LayerName);
            }
            catch (Exception)
            {
                MessageBox.Show("Layer already inserted");
            }
        }

        private void btnRemoveLayer_Click(object sender, EventArgs e)
        {
            if (this.lbxLayers.SelectedIndex >= 0)
            {
                _sharpMap.Layers.RemoveAt(lbxLayers.SelectedIndex);
                lbxLayers.Items.RemoveAt(lbxLayers.SelectedIndex);
                if (_sharpMap.Layers.Count != 0)
                {
                    _sharpMap.ZoomToExtents();
                }
                RefreshMap();
            }
                
        }

        private void btnEditLayer_Click(object sender, EventArgs e)
        {

        }

        private void btnAddRaster_Click(object sender, EventArgs e)
        {
            SharpMap.Layers.ILayer layer = _sharpMap.Layers["RasterLayer"];
            String path;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                path = dialog.FileName;
                /*SharpMap.Layers.GdalRasterLayer rasterLayer = new SharpMap.Layers.GdalRasterLayer(dialog.SafeFileName, path);
                rasterLayer.ReprojectToMap(_sharpMap);
                _sharpMap.Layers.Add(rasterLayer);
                _sharpMap.ZoomToExtents();
                lbxLayers.Items.Add(dialog.SafeFileName);
                RefreshMap();*/
            }
            else
                path = DATA_PATH;
=======
        private void sharpMapImage_MouseMove(SharpMap.Geometries.Point WorldPos, MouseEventArgs ImagePos)
        {
            this.lblWorldCoordiantes.Text = "World Coordinates: " + WorldPos.X + ":" + WorldPos.Y;
            this.lblImageCoordinates.Text = "Image Coordinates: " + ImagePos.X + ":" + ImagePos.Y;
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            this._sharpMap.Size = this._sharpMapImage.Size;
            this.RefreshMap();
        }

        private void sharpMapImage_MouseUp(SharpMap.Geometries.Point WorldPos, MouseEventArgs ImagePos)
        {
            if (ImagePos.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point mapCenter = new Point(this._sharpMapImage.Size.Width / 2 - ImagePos.Location.X + this._panCoordinate.X
                    , this._sharpMapImage.Size.Height / 2 - ImagePos.Location.Y + this._panCoordinate.Y);
                this._sharpMap.Center = this._sharpMap.ImageToWorld(mapCenter);
                this.RefreshMap();
            }
        }

        private void _sharpMapImage_MouseDown(SharpMap.Geometries.Point WorldPos, MouseEventArgs ImagePos)
        {
            if(ImagePos.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this._panCoordinate = ImagePos.Location;
            }
        }
    }
}
