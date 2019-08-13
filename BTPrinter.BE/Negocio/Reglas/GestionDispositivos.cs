using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTPrinter.BE.Negocio.Reglas
{
    public class GestionDispositivos
    {
        private readonly Guid IdentificadorGlobal = BluetoothService.GenericFileTransfer;

        public async Task<bool> DescubrirDispositivos()
        {
            
            BluetoothListener servidor = new BluetoothListener(IdentificadorGlobal);
            servidor.Start();
            BluetoothClient cliente = new BluetoothClient();
            cliente = servidor.AcceptBluetoothClient();
            var strim=cliente.GetStream();
            return await Task.FromResult(true);
        }

        public MemoryStream IniciarRecepcionImagenBT()
        {
            MemoryStream archivo = new MemoryStream();

            BluetoothRadio radio = BluetoothRadio.PrimaryRadio;
            if (radio == null)
            {
                throw new Exception("No bluetooth device connected");
            }
            else
            {
                radio.Mode = RadioMode.Discoverable;
            }


            ObexListener receptorImagenes = new ObexListener(ObexTransport.Bluetooth);
            receptorImagenes.Start();
            //MessageBox.Show("Esperando imagen", "Receptor Imagenes", MessageBoxButtons.OK);
            ObexListenerContext contexto = receptorImagenes.GetContext();
            //MessageBox.Show("Imagen Recibida", "Receptor Imagenes", MessageBoxButtons.OK);

            ObexListenerRequest req = contexto.Request;

            string archivoDireccion = req.RawUrl;
            string extension = req.RawUrl.Split('.').ToList().LastOrDefault();
            archivo = new MemoryStream();
            req.InputStream.CopyTo(archivo);
            string b64 = Convert.ToBase64String(archivo.ToArray());
            //req.WriteFile("."+ archivoDireccion);
            //File.WriteAllBytes("./b64." + extension, archivo.ToArray());
            receptorImagenes.Stop();

            return archivo;
        }

        public void ImprimirArchivo(MemoryStream archivo,double ancho, double alto)
        {
            PdfDocument documento = new PdfDocument();
            PdfPage pagina = documento.AddPage();
            XGraphics graficador = XGraphics.FromPdfPage(pagina);
            //imgVista.Image.Save(archivo, ImageFormat.Bmp);
            graficador.DrawImage(XImage.FromStream(archivo), 0, 0, ancho, alto);
            string nombreArchivo = "impresion.pdf";
            documento.Save(nombreArchivo);
            Process.Start(nombreArchivo);
            documento.Close();
        }
    }
}
