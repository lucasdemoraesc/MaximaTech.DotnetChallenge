# MaximaTech - Avaliação técnica

Este repositório possui a implementação da solução solicitada.

### Tecnologias utilizadas:
 - C# (dotnet 5)
 - Asp.Net Web Api
 - Asp.Net MVC Core + Razor Pages
 - Entity Framework Core
 - PostgresSQL
 - Docker

### Funcionalidades implementadas
 - [x] Serviço API para CRUD de produtos
 - [x] Serviço Web para o client-side
 - [x] Agendamento para consulta de dados na API externa de departamentos 
 - [x] Testes de unidade
 - [x] Script para automatização do processo de instalação via docker

### Observações
1. O serviço de api informado na atividade não está funcionando. Por isso resolvi criar outro mock para a API de departamentos, disponível aqui: https://61b6f51dc95dd70017d41117.mockapi.io/Departamentos.
2. A consulta agendada à API de departamentos é executada a cada 5 minutos após a inicialização da aplicação. Este tempo pode ser facilmente alterado, basta alterar os parâmetros passados para a classe [TaskScheduler](https://github.com/lucasdemoraesc/MaximaTech.DotnetChallenge/blob/main/MaximaTech.DotnetChallenge/MaximaTech.DotnetChallenge.Api/Utils/TaskScheduler.cs) no [Startup.cs](https://github.com/lucasdemoraesc/MaximaTech.DotnetChallenge/blob/main/MaximaTech.DotnetChallenge/MaximaTech.DotnetChallenge.Api/Startup.cs).
3. Os dados consultados da API de departamentos são persistidos no banco de dados (apenas se já não existirem).
4. O processo de login está sendo mockado, desta forma basta digitar qualquer endereço de e-mail no formulário de login da aplicação para acessar. Caso tente acessar outras URLs antes de passar pelo formulário verá um erro 401.

### Instalação

#### Pré requisitos
- Sistema operacional Windows (Caso instale utilizando o script powershel)
- Dotnet 5
- Docker

#### Instalação automatizada
Caso esteja utilizando Windows e possua o docker em sua máquina, a instalação pode ser feita automaticamente utilizando o script [Install.ps1](https://github.com/lucasdemoraesc/MaximaTech.DotnetChallenge/blob/main/Install.ps1)
Este script irá compilar a solução, executar os testes e subir os containers necessários no docker.

1. Faça clone deste repositório
```
git clone https://github.com/lucasdemoraesc/MaximaTech.DotnetChallenge.git
```

2. Execute o script Install.ps1 
```
Botão direito -> Executar com o PowerShell
```

3. Verifique se os containers estão rodando
```
docker container ps
```
- A saída deverá ser algo como:

![enter image description here](https://i.imgur.com/lUyGTsv.png)

4. Acesse a seguinte URL no navegador
```
http://localhost:4200/login
```

##### Problemas conhecidos

> Algumas inconsistências podem ocorrer ao se consultar os dados pelo
> cliente. Isso se deve ao fato de a aplicação requerer um certificado
> SSL para executar requisições https. Até cheguei a fornecê-lo gerando
> um certificado manualmente através do `dotnet dev-certs https` e
> injetando no container da aplicação, porém fazendo isso recebi outro
> erro relacionado a desserialização do token de autenticação. Desta
> forma, recomendo que a aplicação seja testada diretamente pelo Visual
> Studio em ambiente de desenvolvimento, conforme descrito abaixo.

#### Rodando pelo Visual Studio
Para executar pelo Visual Studio, verifique a string de conexão com o banco de dados em [appsettings.Develoment.json](https://github.com/lucasdemoraesc/MaximaTech.DotnetChallenge/blob/main/MaximaTech.DotnetChallenge/MaximaTech.DotnetChallenge.Api/appsettings.Development.json).
Alternativamente, você pode subir a instância do container do postgres referenciada na string de conexão com o seguinte comando:
```
docker run --name maximatechdotnetchallenge-database-1 --network=maxima-network -e "POSTGRES_PASSWORD=Postgres2018!" -p 3400:5432 -d postgres:12.9
```

### Imagens
Tela de login
![enter image description here](https://i.imgur.com/uLTARaf.png)

Tela de início
![enter image description here](https://i.imgur.com/XVCuOPI.png)

Listagem de produtos![enter image description here](https://i.imgur.com/kVgOxFQ.png)

Cadastro de produto
![enter image description here](https://i.imgur.com/4oZvOyx.png)

Editar produto
![enter image description here](https://i.imgur.com/vvXOmiG.png)

Erro padrão
![enter image description here](https://i.imgur.com/CuW2YXE.png)
