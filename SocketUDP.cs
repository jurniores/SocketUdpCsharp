using System;
using System.Net.Sockets;
using System.Text;
using System.Net;

namespace SocketUDP
{

    public class SocketClient
    {

        Socket client;
        IPEndPoint ep;
        private bool ativo = true;

        public void Connect(string ip, int port)
        {


            string IP = ip;
            int PORT = port;

            try
            {
                ep = new IPEndPoint(IPAddress.Parse(IP), port);


                client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
                {
                    Blocking = false
                };
            }
            catch(SocketException e) { 


            Console.Write(e.Message);
            }
           



        }


        public void Send(string send, string message)
        {
            byte[] packatData = Encoding.ASCII.GetBytes(send + ':' + message);
            client.SendTimeout = 1;
            client.SendTo(packatData, ep);

        }

        public delegate void Cb(string String);
        public void On(string valida, Cb callBack)
        {
            if (ativo)
            {


                if (client.Available != 0)
                {
                    try
                    {
                        byte[] msg = new byte[64];

                        client.Receive(msg);

                        string[] msgValida = Encoding.ASCII.GetString(msg).Split(':');


                        if (msgValida[0] == "brc" || msgValida[0] == valida)
                        {
                            callBack(msgValida[1]);
                        }
                    }
                    catch(SocketException e)
                    {
                        Console.Write(e.Message);
                    }


                }
            }

        }



        public void Diconnected()
        {
            ativo = false;
            client.Close();
        }

    }
}