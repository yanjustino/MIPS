using System;
using System.Net.Sockets;

namespace MipsSharpSimulator
{
	public class ClientSocket
	{

		public ClientSocket ()
		{
		}

		public void Send(string ip, string message)
		{
			try
			{
				TcpClient clientSocket = new TcpClient();
				clientSocket.Connect(ip, 8085);
				NetworkStream serverStream = clientSocket.GetStream();
				byte[] outStream = System.Text.Encoding.ASCII.GetBytes(message);
				serverStream.Write(outStream, 0, outStream.Length);
				serverStream.Flush();

				byte[] inStream = new byte[10025];
				serverStream.Read(inStream, 0, 10025);
				string returndata = System.Text.Encoding.ASCII.GetString(inStream);
			}
			catch(Exception ex) {
				throw ex;
			}
		}
	}
}

