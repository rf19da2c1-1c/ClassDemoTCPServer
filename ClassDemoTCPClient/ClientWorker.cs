using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClassDemoTCPClient
{
    class ClientWorker
    {
        public void Start()
        {
            // client opretter forbindelse til server, der ligger på 'localhost' og port 7
            TcpClient socket = new TcpClient("localhost", 7);

            StreamReader sr = new StreamReader(socket.GetStream());
            StreamWriter sw = new StreamWriter(socket.GetStream());


            String strSomSendes = "Hallo Peter";
            sw.WriteLine(strSomSendes);
            sw.Flush();

            String strRetur = sr.ReadLine();
            Console.WriteLine($"Tilbage fra Server : {strRetur}");

            socket.Close();


        }
    }
}
