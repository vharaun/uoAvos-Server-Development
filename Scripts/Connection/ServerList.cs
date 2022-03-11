
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Server.Misc
{
	public class ServerList
	{
		#region ServerList Instructions

		/// --------------------------------------------------------------------ADDRESS SETUP

		/// The default setting for 'Address' is a value of 'null'. This means that your server 
		/// will use your local internet protocol (IP) address. 

		/// If all of your local internet protocol (IP) addresses are private network addresses, 
		/// and 'AutoDetect' is set to 'true', then your server will attempt to discover and 
		/// utilize your public internet protocol (IP) address if it can be found.

		/// If your public internet protocol (IP) address cannot be determined, then you must 
		/// change the value of 'Address' to your public internet protocol (IP) address manually 
		/// in order to allow clients outside of your LAN to connect to your server. 

		/// If you do not plan on allowing clients outside of your local area network (LAN) to 
		/// connect, then you can set 'AutoDetect' to 'false' and leave 'Address' set to 'null'.

		/// It is a good idea not to give out your actual internet protocol (IP) address to players,
		/// if you want to avoid being hacked. In an effort to hide your real numeric IP address, I
		/// recommend you go to this website: https://account.dyn.com/

		/// An example of a Dynamic DNS (These Mask Your Real IP From Players):
		/// public static readonly string Address = @"yourservername.game-server.cc";

		/// --------------------------------------------------------------------ROUTER CONFIG

		/// If you want players outside your local area network (LAN) to be able to connect to 
		/// your server, and you are behind a router, then you must edit the 'Port Forwarding'
		/// settings for both Transmission Control Protocol (TCP) and User Datagram Protocol 
		/// (UDP) from within your router settings. This will designate any port or port range 
		/// that you choose on your computer for your server to access. This procedure varies 
		/// by manufacturer, and usually involves configuration through your web browser.

		/// This file will direct connecting clients to your server host; depending on the 
		/// internet protocol (IP) address they are connecting from and the internet protocol 
		/// (IP) address and remote port they are connecting to. Clients will either need a 
		/// game assistant to connect to your server, or your players will need to know how to
		/// edit the Login.cfg (LoginServer=yourserveraddress.cc,2590); located near the top
		/// of the directory their client's are installed in.

		#endregion

		public static readonly string Address = null;
		public static readonly string ServerName = "Test Server";

		public static readonly bool AutoDetect = true;

		public static void Initialize()
		{
			if (Address == null)
			{
				if (AutoDetect)
				{
					AutoDetection();
				}
			}
			else
			{
				Resolve(Address, out m_PublicAddress);
			}

			EventSink.ServerList += new ServerListEventHandler(EventSink_ServerList);
		}

		private static IPAddress m_PublicAddress;

		private static void EventSink_ServerList(ServerListEventArgs e)
		{
			try
			{
				var ns = e.State;
				var s = ns.Socket;

				var ipep = (IPEndPoint)s.LocalEndPoint;

				var localAddress = ipep.Address;
				var localPort = ipep.Port;

				if (IsPrivateNetwork(localAddress))
				{
					ipep = (IPEndPoint)s.RemoteEndPoint;
					if (!IsPrivateNetwork(ipep.Address) && m_PublicAddress != null)
					{
						localAddress = m_PublicAddress;
					}
				}

				e.AddServer(ServerName, new IPEndPoint(localAddress, localPort));
			}
			catch
			{
				e.Rejected = true;
			}
		}

		private static void AutoDetection()
		{
			if (!HasPublicIPAddress())
			{
				Console.Write("ServerList: Auto-detecting public IP address...");
				m_PublicAddress = FindPublicAddress();

				if (m_PublicAddress != null)
				{
					Console.WriteLine("done ({0})", m_PublicAddress.ToString());
				}
				else
				{
					Console.WriteLine("failed");
				}
			}
		}

		private static void Resolve(string addr, out IPAddress outValue)
		{
			if (IPAddress.TryParse(addr, out outValue))
			{
				return;
			}

			try
			{
				var iphe = Dns.GetHostEntry(addr);

				if (iphe.AddressList.Length > 0)
				{
					outValue = iphe.AddressList[iphe.AddressList.Length - 1];
				}
			}
			catch
			{
			}
		}

		private static bool HasPublicIPAddress()
		{
			var adapters = NetworkInterface.GetAllNetworkInterfaces();

			foreach (var adapter in adapters)
			{
				var properties = adapter.GetIPProperties();

				foreach (IPAddressInformation unicast in properties.UnicastAddresses)
				{
					var ip = unicast.Address;

					if (!IPAddress.IsLoopback(ip) && ip.AddressFamily != AddressFamily.InterNetworkV6 && !IsPrivateNetwork(ip))
					{
						return true;
					}
				}
			}

			return false;


			/*
			IPHostEntry iphe = Dns.GetHostEntry( Dns.GetHostName() );

			IPAddress[] ips = iphe.AddressList;

			for ( int i = 0; i < ips.Length; ++i )
			{
				if ( ips[i].AddressFamily != AddressFamily.InterNetworkV6 && !IsPrivateNetwork( ips[i] ) )
					return true;
			}

			return false;
			*/
		}

		private static bool IsPrivateNetwork(IPAddress ip)
		{
			// 10.0.0.0/8
			// 172.16.0.0/12
			// 192.168.0.0/16
			// 169.254.0.0/16
			// 100.64.0.0/10 RFC 6598

			if (ip.AddressFamily == AddressFamily.InterNetworkV6)
			{
				return false;
			}

			if (Utility.IPMatch("192.168.*", ip))
			{
				return true;
			}
			else if (Utility.IPMatch("10.*", ip))
			{
				return true;
			}
			else if (Utility.IPMatch("172.16-31.*", ip))
			{
				return true;
			}
			else if (Utility.IPMatch("169.254.*", ip))
			{
				return true;
			}
			else if (Utility.IPMatch("100.64-127.*", ip))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private static IPAddress FindPublicAddress()
		{
			try
			{
				var req = HttpWebRequest.Create("https://api.ipify.org");

				req.Timeout = 15000;

				var res = req.GetResponse();

				var s = res.GetResponseStream();

				var sr = new StreamReader(s);

				var ip = IPAddress.Parse(sr.ReadLine());

				sr.Close();
				s.Close();
				res.Close();

				return ip;
			}
			catch
			{
				return null;
			}
		}
	}
}