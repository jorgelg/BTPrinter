using BTPrinter.BE.Negocio.Reglas;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTPrinter.Forms
{
    public partial class Form1 : Form
    {
        MemoryStream archivo = new MemoryStream();

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnRecibir_click(object sender, EventArgs e)
        {
            //var radios = BluetoothRadio.AllRadios;

            try
            {
                GestionDispositivos gestion = new GestionDispositivos();
                archivo=gestion.IniciarRecepcionImagenBT();
                imgVista.Refresh();
                imgVista.Image = Image.FromStream(archivo);
                imgVista.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #region Buscar dispositivo

            //BluetoothClient cliente = new BluetoothClient();
            //BluetoothDeviceInfo[] lista= cliente.DiscoverDevices(20, true, true, true);
            //BluetoothListener servidor = new BluetoothListener(BluetoothService.L2CapProtocol);

            //servidor.Authenticate = true;
            //servidor.ServiceClass = ServiceClass.Capturing | ServiceClass.ObjectTransfer;
            //servidor.ServiceName = "cliente ftp";
            //servidor.Start();
            #endregion

            #region Redimensionar imagen
            //byte[] imageBytes;

            ////Of course image bytes is set to the bytearray of your image      

            //using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            //{
            //    using (Image img = Image.FromStream(ms))
            //    {
            //        int h = 100;
            //        int w = 100;

            //        using (Bitmap b = new Bitmap(img, new Size(w, h)))
            //        {
            //            using (MemoryStream ms2 = new MemoryStream())
            //            {
            //                b.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
            //                imageBytes = ms2.ToArray();
            //            }
            //        }
            //    }
            //}
            #endregion
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Imprimiendo imagen", "Receptor Imagenes", MessageBoxButtons.OK);
            GestionDispositivos gestion = new GestionDispositivos();
            gestion.ImprimirArchivo(archivo,imgVista.Width,imgVista.Height);
        }
    }
}
