# az login
# az account set --subscription "SUBSCRIPTION_ID"
# az acr login --name "ACR_NAME"


$TimeStamp = Get-Date -Format "yyyyMMddHHmmss"
$Image = "gbedaprdemo.azurecr.io/demoapp"
$Tag = "$($Image):$($TimeStamp)"
$TagLatest = "$($Image):latest"

docker build -f src/Dockerfile -t $Tag -t $TagLatest ./src/
Write-Host "Pushing $($Tag)"
docker push $Tag
Write-Host "Pushing $($TagLatest)"
docker push $TagLatest
