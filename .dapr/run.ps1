Set-Location $PSScriptRoot
cd ../src/DaprKeyVault
dapr run --app-id demoapp --dapr-http-port 3500 --dapr-grpc-port 3501 --components-path ../../.dapr/components/ 
