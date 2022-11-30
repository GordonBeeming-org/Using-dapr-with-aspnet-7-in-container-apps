using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace DaprKeyVault.Controllers;

[ApiController]
[Route("[controller]")]
public class Secrets2Controller : ControllerBase
{
  private readonly SecretClient secretClient;

  public Secrets2Controller(IConfiguration configuration)
  {
    this.secretClient = new SecretClient(new Uri(configuration["keyVaultUrl"]!), new DefaultAzureCredential(new DefaultAzureCredentialOptions
    {
#if !DEBUG
      ManagedIdentityClientId = "9032a945-d6c5-434d-9d61-87ee011f8ec1", // Can be set as environment variable AZURE_CLIENT_ID
#endif
    }));
    Configuration = configuration;
  }

  public IConfiguration Configuration { get; }

  [HttpGet("{name}")]
  public async Task<ActionResult> Get(string name)
  {
    try
    {
      var secret = await secretClient.GetSecretAsync(name);
      return Ok(secret.Value.Value);
    }
    catch (Exception e)
    {
      return Ok(e.ToString());
    }
  }

  [HttpGet("{name}/{value}")]
  public async Task<ActionResult> Put(string name, string value)
  {
    try
    {
      await secretClient.SetSecretAsync(name, value);
      return Ok();
    }
    catch (Exception e)
    {
      return Ok(e.ToString());
    }
  }
}
