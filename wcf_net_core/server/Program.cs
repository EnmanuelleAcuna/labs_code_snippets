using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using moneda;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel((context, options) =>
{
	options.AllowSynchronousIO = true;
});

// Add WSDL support
builder.Services.AddServiceModelServices();

var app = builder.Build();

app.UseServiceModel(builder =>
{
	builder.AddService<EchoService>()
	// Add a BasicHttpBinding at a specific endpoint
	.AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(), "/EchoService/basichttp");
});

app.Run();
