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

            BluetoothRadio radio = BluetoothRadio.PrimaryRadio;
            if (radio == null)
            {
                MessageBox.Show("No bluetooth device connected");
                return;
            }
            else
            {
                radio.Mode = RadioMode.Discoverable;
            }
            //BluetoothClient cliente = new BluetoothClient();
            //BluetoothDeviceInfo[] lista= cliente.DiscoverDevices(20, true, true, true);
            //BluetoothListener servidor = new BluetoothListener(BluetoothService.L2CapProtocol);
            
            //servidor.Authenticate = true;
            //servidor.ServiceClass = ServiceClass.Capturing | ServiceClass.ObjectTransfer;
            //servidor.ServiceName = "cliente ftp";
            //servidor.Start();

            ObexListener receptorImagenes = new ObexListener(ObexTransport.Bluetooth);
            receptorImagenes.Start();
            MessageBox.Show("Esperando imagen","Receptor Imagenes",MessageBoxButtons.OK);
            ObexListenerContext contexto = receptorImagenes.GetContext();
            MessageBox.Show("Imagen Recibida", "Receptor Imagenes", MessageBoxButtons.OK);

            ObexListenerRequest req = contexto.Request;

            string archivoDireccion = req.RawUrl;
            string extension = req.RawUrl.Split('.').ToList().LastOrDefault();
            archivo = new MemoryStream();
            req.InputStream.CopyTo(archivo);
            string b64 = Convert.ToBase64String(archivo.ToArray());
            //req.WriteFile("."+ archivoDireccion);
            //File.WriteAllBytes("./b64." + extension, archivo.ToArray());
            receptorImagenes.Stop();
            imgVista.Refresh();
            imgVista.Image = Image.FromStream(archivo);
            imgVista.SizeMode = PictureBoxSizeMode.StretchImage;
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
            MessageBox.Show("Imprimiendo imagen", "Receptor Imagenes", MessageBoxButtons.OK);
            PdfDocument documento = new PdfDocument();
            PdfPage pagina = documento.AddPage();
            XGraphics graficador = XGraphics.FromPdfPage(pagina);
            //imgVista.Image.Save(archivo, ImageFormat.Bmp);
            graficador.DrawImage(XImage.FromStream(archivo),0,0,imgVista.Width,imgVista.Height);
            string nombreArchivo = "impresion.pdf";
            documento.Save(nombreArchivo);
            Process.Start(nombreArchivo);
            documento.Close();
        }
    }
}
