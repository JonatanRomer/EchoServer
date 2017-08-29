using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace An_Echo_Server
{
    class Server
    {
        public Server()
        {
            
        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback,7);
            server.Start();

            using (TcpClient client = server.AcceptTcpClient())
            using (NetworkStream ns = client.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                String inlinje = sr.ReadLine();
                sw.WriteLine(inlinje);
                var strs = inlinje.Split(' ');
                sw.WriteLine(strs.Length);
                sw.Flush();


            }
            

            
        }

    }
}
