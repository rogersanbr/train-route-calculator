# Train Route Calculator :train: :iphone: 

1. pt-BR
2. en-US

## pt-BR

## Sistema que calcula as rotas de uma linha de trens a partir de diferentes condições - menor rota, rota com X paradas, rota com Y de distância.

### Arquitetura

A arquitetura é baseada em DDD - Domain Driven Design, onde temos o Domínio do sistema, isto é, a representação de suas entidades e regras de negócio na camada domínio. 

Camadas: 
- TrainRoute.Application: Camada de Aplicação, onde o sistema é executado e os comandos são processados.
- TrainRoute.Domain: Camada de Domínio, onde as Entidades são representadas e as Regras de Negócio são definidas.
- TrainRoute.Kernel: Camada de núcleo, onde são definidas estruturas reaproveitáveis para o domínio da aplicação. Desta maneira é possível ter, por exemplo Bounded Contexts (Contextos Delimitados) entre diferentes pacotes da aplicação, e esta camada pode ser reaproveitada como um pacote Nuget.
- TrainRoute.Test: Camada de Teste Unitário, onde ocorre validações sobre a implementação e execução do sistema, garantindo que ele faça o que foi desenhado para fazer corretamente, e assegurando que alterações na implementação não quebrem o sistema.

### Instalação

O sistema utiliza .Net Core 2.2.x, é possível executálo através de container Docker utilizando o comando `docker build .` na taiz do projeto, ou instalando o .Net Core 2.2.x SDK.

#### Execução - Comandos

- Com Docker, na raiz do projeto: `docker build -t traincalculator .` e depois `docker run traincalculator` 

- Executar o sistema: `dotnet restore` e `dotnet run .\src\TrainRoute\Application`.

- Executar os testes: `dotnet test`.



## en-US

## The system calculates the possible routes between train stations. It can calculate the shortest path (Djikstra's Algorithm), a route with X stops, or Y distance.

### Architecture

The architecture is influenced by Layered Architecture (each layer has a unique responsability) and DDD - Domain Driven Design (the app core logic is separated from external world).

Layers: 
- TrainRoute.Application: Application Layer, where the presentation and I/O interaction are processed. This is the system entrance.
- TrainRoute.Domain: Domain Layer, where the system main goal is acchieved, represented with Entities and Business Rules.
- TrainRoute.Kernel: Core Layer, where the core structure to the Domain is defined. With this, you can even reuse the same core structure (as a Nuget package) in different apps within the same company each one with its own Bounded Contexts.
- TrainRoute.Test: Automated testing layer, where you can either see how the system should behave and ensure that the code that you added kept everything working fine.

### Installation

The system uses .Net Core 2.2.x. You can use it with containers or by compiling it locally on your machine.

#### Execution

- Docker:

`docker build -t trainroutecalculator`
`docker run trainroutecalculator`

- From your machine's runtime:

`dotnet restore && dotnet run -p .\src\TrainRoute\Application`
`dotnet test`