using System;
using System.Net.NetworkInformation;
using System.Text;

namespace ICMP_Ping
{
    class Program
    {
        static void Main(string[] args)
        {
            string targetHost = "google.com";
            string data = "a quick brown fox jumped over the lazy dog";

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions
            {
                DontFragment = true
            };

            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1024;

            Console.WriteLine($"Pinging {targetHost}");
            PingReply reply = pingSender.Send(targetHost, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine($"Address: {reply.Address}");
                Console.WriteLine($"RoundTrip time: {reply.RoundtripTime}");
                Console.WriteLine($"Time to live: {reply.Options.Ttl}");
                Console.WriteLine($"Don't fragment: {reply.Options.DontFragment}");
                Console.WriteLine($"Buffer size: {reply.Buffer.Length}");
            }
            else
            {
                Console.WriteLine(reply.Status);
            }
        }
    }
}
