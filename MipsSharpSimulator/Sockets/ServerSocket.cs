﻿using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace MipsSharpSimulator
{
	public class ServerSocket
	{
		public bool Started { get; private set; }

		private const int BUFFER_SIZE = 10024;

		public void Start(int port)
		{
			Started = false;
			Console.Title = "TCP/IP HTTP Server";
			TcpListener listener = null;

			try
			{
				listener = new TcpListener(IPAddress.Parse ("127.0.0.1"), port);
				listener.Start();
				Console.WriteLine("Servidor Iniciado na porta: {0}", port);
				Started = true;
			}
			catch (SocketException e)
			{
				Console.WriteLine("{0}: {1}", e.ErrorCode, e.Message);
				Environment.Exit(e.ErrorCode);
			}

			var buffer = new byte[BUFFER_SIZE];

			while (true)
			{
				TcpClient client = null;
				NetworkStream stream = null;

				try
				{
					client = listener.AcceptTcpClient();
					stream = client.GetStream();
					var bytesReceived = 0;

					Console.WriteLine("Handling client:");

					while (true)
					{
						bytesReceived = stream.Read(buffer, 0, BUFFER_SIZE);
						var dataFromClient = Encoding.ASCII.GetString(buffer, 0, bytesReceived);

						var s = ((IPEndPoint)client.Client.RemoteEndPoint);

						var ipClient = s.Address.ToString();

						Console.WriteLine("Acesso remoto de {0}", ipClient);

						while(SocketMessageRepository.Current.HasValue(ipClient)){}

						SocketMessageRepository.Current.Add(ipClient, dataFromClient);

						if (bytesReceived != BUFFER_SIZE) break;
					}

					var response = Encoding.ASCII.GetBytes(
						string.Format("{0}n{1}n{2}n{3}",
							"HTTP/1.1 200 OK",
							"Content-Type: text/html; charset=UTF-8",
							"",
							"From TcpServer"
						));

					stream.Write(response, 0, response.Length);

					Console.WriteLine("n");
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
				}
				finally
				{
					stream.Close();
					client.Close();
				}
			}

		}		
	}
}

