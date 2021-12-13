$SolutionPath = ".\MaximaTech.DotnetChallenge"
$DockerComposeFilePath = ".\MaximaTech.DotnetChallenge\docker-compose.yaml"
$Solution = ".\MaximaTech.DotnetChallenge\MaximaTech.DotnetChallenge.sln"
$ApiCsproj = ".\MaximaTech.DotnetChallenge\MaximaTech.DotnetChallenge.Api\MaximaTech.DotnetChallenge.Api.csproj"
$TestsCsproj = ".\MaximaTech.DotnetChallenge\MaximaTech.DotnetChallenge.Tests\MaximaTech.DotnetChallenge.Tests.csproj"

If(
    (Test-Path $SolutionPath) -and (Test-Path $DockerComposeFilePath -PathType Leaf) -and (Test-Path $ApiCsproj) -and (Test-Path $Solution) -and (Test-Path $TestsCsproj)
) {
    Write-Host "🥁 Preparando o ambiente..." -ForegroundColor Magenta
    $ErrorActionPreference='SilentlyContinue'
    docker rm maximatechdotnetchallenge-web-1 --force
    docker rm maximatechdotnetchallenge-api-1 --force
    docker rm maximatechdotnetchallenge-database-1 --force
    dotnet tool install --global dotnet-ef
    $ErrorActionPreference='Continue'
    Write-Host "🏗 Compilando solução..." -ForegroundColor Magenta
    dotnet build $Solution
    Write-Host "✅ Executando testes..." -ForegroundColor Magenta
    dotnet test --no-build --no-restore $TestsCsproj
    Write-Host "🌐 Criando docker network..." -ForegroundColor Magenta
    docker network create --driver bridge maxima-network
    Write-Host "📦 Subindo container de banco de dados..." -ForegroundColor Magenta
    docker run --name maximatechdotnetchallenge-database-1 --network=maxima-network -e "POSTGRES_PASSWORD=Postgres2018!" -p 3400:5432 -d postgres:12.9
    Write-Host "🎲 Aplicando migrations..." -ForegroundColor Magenta
    dotnet ef database update -p $ApiCsproj -s $ApiCsproj
    Write-Host "🚀 Subindo containers da aplicação com docker compose..." -ForegroundColor Magenta
    docker compose -f $DockerComposeFilePath up -d --build    
}
Else {
    Write-Host "😢 Não foi possível localizar os arquivos necessários..." -ForegroundColor Red
}

PAUSE
