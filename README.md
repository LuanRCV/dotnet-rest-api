# .NET RESTFull API

## Resumo
* API construída para portfolio com base no framework .NET 5 com o objetivo de acessar um banco de dados e fornecer informações a partir da consulta;
* Foram utilizadas concepções de boas práticas e organização estrutural, além de buscar sempre implementações de código limpo (clean code);
* Além dos requisitos de negócio e funcionais habilitados, há também uma preocupação com a segurança da aplicação, de forma que métodos de autenticação e autorização foram implementados.

## Resumo Técnico
* Utilização do padrão arquitetural REST;
* Integração com banco de dados MySQL;
* Divisão da arquitetura em camadas (controller - business - repository);
* Versionamento de endpoints;
* Utilização do padrão de projeto *Generic Repository*;
* Utilização do padrão de projeto *Value Object (VO)*;
* Utilização de *HypermediaLinks* no padrão de implementação HATEOAS;
* Utilização de autenticação via JWT para execução de rotas;
* Uso da dockerização da aplicação e do banco de dados com orquestração via docker-compose;