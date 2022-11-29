# Using dapr with aspnet 7 in container apps

This is a sample project to show how to use dapr with aspnet 7 in container apps. Locally it uses a `secretstores.local.file` which loads the secrets.json file from the DaprKeyVault project directory.

## Running the sample

To run the app you'll need to first run the `run.ps1` in the .dapr/components folder. This will start the dapr sidecar and the dapr placement service. Then you can run the app using `dotnet run` or `dotnet watch run` in the DaprKeyVault project directory. All launch settings are configured to use the dapr sidecar ports used in the `run.ps1`.

# Azure setup

- Create your Azure Key Vault
- Create managed identity user
- Add a Dapr Component
  - Component type: secretstores.azure.keyvault
  - Version: v1
- Add Meta to the component
  - vaultName: the vault name you used
  - azureClientId: the managed identity client id

## References

- [Azure Key Vault secret store](https://docs.dapr.io/reference/components-reference/supported-secret-stores/azure-keyvault/)
- [Authenticating to Azure](https://docs.dapr.io/developing-applications/integrations/azure/authenticating-azure/)