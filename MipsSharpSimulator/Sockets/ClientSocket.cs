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
				var endpoint = ip.Split(':');

				TcpClient clientSocket = new TcpClient();
				clientSocket.Connect(endpoint[0], Convert.ToInt32(endpoint[1]));
				NetworkStream serverStream = clientSocket.GetStream();
				byte[] outStream = System.Text.Encoding.ASCII.GetBytes(message);
				serverStream.Write(outStream, 0, outStream.Length);
				serverStream.Flush();

				byte[] inStream = new byte[10025];
				serverStream.Read(inStream, 0, 10025);
				System.Text.Encoding.ASCII.GetString(inStream);
			}
			catch(Exception ex) {
				throw ex;
			}
		}
	}
}

