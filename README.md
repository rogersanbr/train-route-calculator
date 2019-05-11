# TrainRouteCalculator
## Sistema que calcula as rotas de uma linha de trens a partir de diferentes condições - menor rota, rota com X paradas, rota com Y de distância.

### Arquitetura

A arquitetura é baseada em DDD - Domain Driven Design, onde temos o Domínio do sistema, isto é, a representação de suas entidades e regras de negócio na camada domínio. 

Camadas: 
- TrainRoute.Application: Camada de Aplicação, onde o sistema é executado e os comandos são processados.
- TrainRoute.Domain: Camada de Domínio, onde as Entidades são representadas e as Regras de Negócio são definidas.
- TrainRoute.Kernel: Camada de núcleo, onde são definidas estruturas reaproveitáveis para o domínio da aplicação. Desta maneira é possível ter, por exemplo Bounded Contexts (Contextos Delimitados) entre diferentes pacotes da aplicação, e esta camada pode ser reaproveitada como um pacote Nuget.
- TrainRoute.Test: Camada de Teste Unitário, onde ocorre validações sobre a implementação e execução do sistema, garantindo que ele faça o que foi desenhado para fazer corretamente, e assegurando que alterações na implementação não quebrem o sistema.

### Instalação

O sistema utiliza .Net Core 2.1.x, é possível executálo através de container Docker utilizando o comando `docker build .` na taiz do projeto, ou instalando o .Net Core 2.1.x SDK.

#### Execução - Comandos

- Com Docker, na raiz do projeto: `docker build -t traincalculator .` e depois `docker run traincalculator` 

- Executar o sistema: `dotnet restore` e `dotnet run .\TrainRoute\Application`.

- Executar os testes: `dotnet test TrainRoute.Test`.

