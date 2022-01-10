﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NSPassServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting... ");

            TcpListener server = null;
            try
            {
                Int32 port = 1194;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, port);
                server.Start();

                Byte[] bytes = new Byte[256];
                String data = null;

                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    NetworkStream stream = client.GetStream();

                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        Console.WriteLine("Proccessing... \nDomain = " + data);

                        try
                        {
                            foreach (IPAddress ip in Dns.GetHostAddresses(data))
                            {
                                byte[] msg = Encoding.ASCII.GetBytes(ip.ToString());
                                stream.Write(msg, 0, msg.Length);
                                Console.WriteLine("Sent: {0}", data);
                            }
                        } 
                        catch
                        {
                            byte[] msg = Encoding.ASCII.GetBytes("0");
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", data);
                        }
                        
                        
                    }
                    client.Close();
                }
            }
            catch(SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

      
    }
}