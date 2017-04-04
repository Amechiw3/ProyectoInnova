using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using ProyectoInnovaDESK.Tools;

namespace ProyectoInnovaDESK.userControl
{
    public partial class ucFichaMunicipio : UserControl
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        public String ImagenString { get; set; }
        public Bitmap ImagenBitmap { get; set; }

        public ucFichaMunicipio()
        {
            InitializeComponent();
        }
       
        private void videoSource_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ImagenBitmap = (Bitmap)eventArgs.Frame.Clone();
            ImagenString = ImagenTool.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
            pBoxFoto.Image = ImagenBitmap;
        }

        public void FinalizarControles()
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }
        public void colocarFotografia(string fotografia)
        {
            pBoxFoto.Image = ImagenTool.Base64StringToBitmap(fotografia);
            ImagenString = fotografia;
        }
        public void PonerFotografia(String pathImagen)
        {
            ImagenBitmap = new System.Drawing.Bitmap(pathImagen);
            ImagenString = ImagenTool.ToBase64String(ImagenBitmap, ImageFormat.Jpeg);
            pBoxFoto.Image = ImagenBitmap;
        }

        private void ucFichaMunicipio_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo device in videoDevices)
            {
                cmbCamaras.Items.Add(device.Name);
            }
            if (cmbCamaras.Items.Count > 0)
            {
                cmbCamaras.SelectedIndex = 0;
                videoSource = new VideoCaptureDevice();
            }
            else
            {
                lblError.Visible = true;
                btnIniciar.Enabled = false;
            }

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                //this.picImagen.Image = null;
                this.pBoxFoto.Image = ImagenBitmap;
                pBoxFoto.Invalidate();
            }
            else
            {
                videoSource = new VideoCaptureDevice(videoDevices[cmbCamaras.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_newFrame);
                videoSource.Start();
            }

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "jpeg (*.jpeg)| *.jpeg|png (*.png)| *.png|";
            open.Title = "Selecciona Logotipo";
            if (open.ShowDialog() == DialogResult.OK)
            {
                this.pBoxFoto.ImageLocation = open.FileName;
            }

        }
    }
}

