What is Web Service
- web services are tipically services exposed over HTTP for interoperating between two systems
- HTTP endpoints that contain methods that are called by sending serialized XML which is enclosed in a special format called SOAP

FOUR TECHNOLOGIES INVOLVED
1. HTTP - protol used for transfering info (disconnected model)
2. XML - format to store data in
3. SOAP - protocol for defining and invoking services and wrapping the data (defines what XML data-request/response should look like)
4. WSDL - technology for making web services discoverable and parsable (think of it as MENU/ Interface for interacting with Web Service)
	- Proxy Class - will call WebService methods => created from WSDL file (link under Service Description)

HTTP is paper, XML is words, SOAP defines what words mean

HOW WEB SERVICE WORKS
Client code => IHTTP Handler => Asmx File => Web Service class

[WebMethod] - Attribute WebMethod lets us expose public method as service method
:WebService - WebService base class provides Session object and others
EnableSession = true - Attribute allows for using session
[SoapHeader("Authentication")] - adding header to pass data to web method

SUMMARY
1. Creating Protein counter web service
2. Creating client app
	a. Adding web service reference (Proxy class) (from WSDL file link)
	b. Initializing - new ProteinTrackerServiceSoapClient()
	c. Asynch calls - added dealy for testing purposes to AddProtein() method 
	d. Exceptions - adding try/catch block to AddProtein() - FaultException wrapped in SOAP returned from web service
3. Custom SOAP Headers - used for passing additionial data, ie. Login credentials etc
	a. Create a class and inherit from SoapHeader. Add attribute "SoapHeader" and within Web Method test. => ListUsers()
	b. Use AuthenticationHeader class within the Client app => new AuthenticationHeader() etc. (var auth = new AuthenticationHeader { UserName = "Bob", Password = "Pass" };)
4. Command line - Generating Proxy class from WSDL. VS command prompt => WSDL "paste wsdl url"
5. AJAX - asynch javascript and XML - making request via javascript (only portion of data can be sent between client/server)
	a. JQuery converstion => calling .asmx/AddUser() method (and other methods)
6. Newer technologies
	- why switch?: performance (XML with SOAP vs. JSON and REST)
	SOAP vs. (JSON and REST) => Soap - very descriptive (WSDL), REST - less descriptive, relies on client of what to pass (less overhead)
	SOAP => clearly defines what will be passed in to Web Service, what happends when someone breaches the contract?
	REST => less format, and open to interpretation, less constraints, less overhead, simpler
7. XML (SOAP) vs. JSON(REST) = technology choices in Microsoft Stack
	a. WCF - technology allows for creating services that are not dependent on specific protocol or data format (HTTP SOAP XML or JSON or whatever binding can be used)
	b. Web API - REST and HTTP. MVC pattern. good choice for creating light weight web services
	c. ServiceStack - non microsoft, like WCF and WebAPI
8. WCF - converting web service to WCF
	a. IProteinTrackerService interface, taking out attributes from old Web Service methods

