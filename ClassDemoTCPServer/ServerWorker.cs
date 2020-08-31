using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClassDemoTCPServer
{
    class ServerWorker
    {
        public void Start()
        {
            // her kommer koden

            // opret server
            // ip egen computer (samme som 127.0.0.1), port er applikationen her en ekko server derfor port 7
            TcpListener server = new TcpListener(IPAddress.Loopback, 7);
            server.Start();

            // venter på en klient skal lave et opkald
            TcpClient socket = server.AcceptTcpClient();

            DoClient(socket);

            socket.Close();


        }

        private void DoClient(TcpClient socket)
        {
            // net stream
            NetworkStream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            // læs tekst fra klient
            String str = sr.ReadLine();
            Console.WriteLine($"Her er server input: {str}");

            // skriv tilbage til klient
            String UpperStr = str.ToUpper();
            sw.WriteLine(UpperStr);
            sw.Flush(); // tømmer buffer
        }
    }
}
