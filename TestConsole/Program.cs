// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.NetworkInformation;
using Tecan.Sila2.Discovery;

var connector = new ServerConnector(new DiscoveryExecutionManager());
var discovery = new ServerDiscovery(connector);

var server = connector.Connect(IPAddress.Loopback, 50052, null, new Dictionary<string, string>
{
    {"encrypted", "false" }
});

var servers = discovery.GetServers(TimeSpan.FromSeconds(5), n => n.NetworkInterfaceType == NetworkInterfaceType.Loopback);

Console.WriteLine(string.Join(",", servers.Select(s => s.Config.Name)));