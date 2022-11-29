using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace DaprKeyVault.Controllers;

[ApiController]
[Route("[controller]")]
public class SecretsController : ControllerBase
{
  private readonly DaprClient daprClient;

  public SecretsController(DaprClient daprClient)
  {
    this.daprClient = daprClient;
  }

  [HttpGet("{name}")]
  public async Task<ActionResult> Get(string name)
  {
    try
    {
      var secret = await daprClient.GetSecretAsync("topsecret", name);
      if (secret.Count > 0)
      {
        return Ok(secret[name]);
      }
    }
    catch (Exception e)
    {
      return Ok(e.ToString());
    }

    return NotFound();
  }
}
