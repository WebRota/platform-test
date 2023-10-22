# README - Projeto de Rastreamento de Rotas

Este projeto consiste na criação de uma aplicação simples que se conecta a um banco de dados SQL Server e implementa recursos de autenticação de usuários. A aplicação utiliza um arquivo chamado `positions.json`, disponível neste repositório, para renderizar um mapa. Além disso, a aplicação cria marcadores em cada coordenada contida no JSON, permitindo a visualização de um trajeto cronológico. A aplicação rodar execução em containers.

## Instruções para Execução

Para rodar o projeto, siga os passos abaixo:

1. Certifique-se de ter o Docker e o Docker Compose instalados em seu ambiente.

2. No terminal, navegue até a raiz do projeto e execute os seguintes comandos:

   ```bash
   docker-compose build
   docker-compose up
   ```

3. Aguarde a construção e inicialização dos containers. Uma vez concluído, a aplicação estará disponível para acesso.

## Estrutura do Projeto

- A pasta `ClientApp` contém o frontend da aplicação desenvolvido em Angular.
- A pasta `WebRota.Web` contém os controladores da aplicação.
- A pasta `WebRota.Domain` contém os objetos e regras de negócio da aplicação.
- A pasta `WebRota.Infra` é responsável pelo acesso ao banco de dados SQL Server. Não se preocupe, a aplicação .NET criará as tabelas necessárias automaticamente para funcionar no container SQL.

## Tecnologias Utilizadas

- Banco de Dados: SQL Server, roda na porta: 1433
- Backend: ASP.NET Core 7 com a arquitetura DDD (Domain-Driven Design), roda na porta: 80
- Frontend: Angular, com a biblioteca Leaflet para exibição das coordenadas no mapa, roda na porta: 4200

## Funcionalidades

- Visualização do trajeto cronológico no mapa, com marcadores nas coordenadas.
- Preparação da aplicação para execução em containers.
- Salvar usuarios e efetuar login com autentificação
- Exibição da soma da distância entre os pontos renderizados.
- Possibilidade de adicionar novos pontos ao mapa.
