// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.NetworkInformation;
using Tecan.Sila2.Client;
using Tecan.Sila2.Client.ExecutionManagement;
using Tecan.Sila2.Discovery;
using TestConsole.BankServer;
using TestConsole.CardReaderService;

var connector = new ServerConnector(new DiscoveryExecutionManager());
var discovery = new ServerDiscovery(connector);
var executionManagerFactory = new ExecutionManagerFactory(Enumerable.Empty<IClientRequestInterceptor>());

var servers = discovery.GetServers(TimeSpan.FromSeconds(10), n => n.NetworkInterfaceType == NetworkInterfaceType.Loopback);

var terminalServer = servers.First(s => s.Info.Type == "Terminal");
var bankServer = servers.First(s => s.Info.Type == "BankServer");

var cardReader = new CardReaderServiceClient(terminalServer.Channel, executionManagerFactory.CreateExecutionManager(terminalServer));
var bankInterface = new BankServerClient(bankServer.Channel, executionManagerFactory.CreateExecutionManager(bankServer));

var context = bankInterface.CreateContext(5000);
var authorizeCommand = cardReader.Authorize(5000, context.Challenge);
var token = await authorizeCommand.Response;
try
{
    bankInterface.AuthorizePayment(context.ContextId, token.Account, token.AuthorizationToken);
    cardReader.Confirm();
}
catch (Exception ex)
{
    cardReader.Abort(ex.Message);
}