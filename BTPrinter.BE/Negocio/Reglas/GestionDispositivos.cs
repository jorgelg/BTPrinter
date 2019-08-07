using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
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
    }
}
