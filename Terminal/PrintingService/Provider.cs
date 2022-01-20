//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Linq;
using Tecan.Sila2;
using Tecan.Sila2.Client;
using Tecan.Sila2.Server;
using Terminal.Contracts;

namespace CoCoME.Terminal.PrintingService
{
    
    
    ///  <summary>
    /// A class that exposes the IPrintingService interface via SiLA2
    /// </summary>
    [System.ComponentModel.Composition.ExportAttribute(typeof(IFeatureProvider))]
    [System.ComponentModel.Composition.PartCreationPolicyAttribute(System.ComponentModel.Composition.CreationPolicy.Shared)]
    public partial class PrintingServiceProvider : IFeatureProvider
    {
        
        private IPrintingService _implementation;
        
        private Tecan.Sila2.Server.ISiLAServer _server;
        
        private static Tecan.Sila2.Feature _feature = FeatureSerializer.LoadFromAssembly(typeof(PrintingServiceProvider).Assembly, "PrintingService.sila.xml");
        
        ///  <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="implementation">The implementation to exported through SiLA2</param>
        /// <param name="server">The SiLA2 server instance through which the implementation shall be exported</param>
        [System.ComponentModel.Composition.ImportingConstructorAttribute()]
        public PrintingServiceProvider(IPrintingService implementation, Tecan.Sila2.Server.ISiLAServer server)
        {
            _implementation = implementation;
            _server = server;
        }
        
        ///  <summary>
        /// The feature that is exposed by this feature provider
        /// </summary>
        /// <returns>A feature object</returns>
        public Tecan.Sila2.Feature FeatureDefinition
        {
            get
            {
                return _feature;
            }
        }
        
        ///  <summary>
        /// Registers the feature in the provided feature registration
        /// </summary>
        /// <param name="registration">The registration component to which the feature should be registered</param>
        public void Register(IServerBuilder registration)
        {
            registration.RegisterUnobservableCommand<PrintLineRequestDto, EmptyRequest>("PrintLine", PrintLine);
            registration.RegisterUnobservableCommand<StartNextRequestDto, EmptyRequest>("StartNext", StartNext);
        }
        
        ///  <summary>
        /// Executes the Print Line command
        /// </summary>
        /// <param name="request">A data transfer object that contains the command parameters</param>
        /// <returns>The command response wrapped in a data transfer object</returns>
        protected virtual EmptyRequest PrintLine(PrintLineRequestDto request)
        {
            try
            {
                _implementation.PrintLine(request.Line.Extract(_server));
                return EmptyRequest.Instance;
            } catch (System.ArgumentException ex)
            {
                if ((ex.ParamName == "line"))
                {
                    throw _server.ErrorHandling.CreateValidationError("terminal/contracts/PrintingService/v1/Command/PrintLine/Parameter/Line", ex.Message);
                }
                throw _server.ErrorHandling.CreateUnknownValidationError(ex);
            }
        }
        
        ///  <summary>
        /// Executes the Start Next command
        /// </summary>
        /// <param name="request">A data transfer object that contains the command parameters</param>
        /// <returns>The command response wrapped in a data transfer object</returns>
        protected virtual EmptyRequest StartNext(StartNextRequestDto request)
        {
            _implementation.StartNext();
            return EmptyRequest.Instance;
        }
        
        ///  <summary>
        /// Gets the command with the given identifier
        /// </summary>
        /// <param name="commandIdentifier">A fully qualified command identifier</param>
        /// <returns>A method object or null, if the command is not supported</returns>
        public System.Reflection.MethodInfo GetCommand(string commandIdentifier)
        {
            if ((commandIdentifier == "terminal/contracts/PrintingService/v1/Command/PrintLine"))
            {
                return typeof(IPrintingService).GetMethod("PrintLine");
            }
            if ((commandIdentifier == "terminal/contracts/PrintingService/v1/Command/StartNext"))
            {
                return typeof(IPrintingService).GetMethod("StartNext");
            }
            return null;
        }
        
        ///  <summary>
        /// Gets the property with the given identifier
        /// </summary>
        /// <param name="propertyIdentifier">A fully qualified property identifier</param>
        /// <returns>A property object or null, if the property is not supported</returns>
        public System.Reflection.PropertyInfo GetProperty(string propertyIdentifier)
        {
            return null;
        }
    }
}

