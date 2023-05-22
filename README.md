# Flux
Sistema de gerenciamento de entradas e saídas para o desafio da Indra Company (Carrefour).

## Instalação

### Localmente
1. Clonar o projeto 
  git clone https://github.com/ErivanCavalcante/flux.git
  
#### Font-end
1. Abrir um prompt de comomando na pasta Flux.Client
2. Instalar as dependências 
  npm install
3. Rodar o projeto
  ng s
  
#### Back-end
1. Ter instalado o Visual Studio
2. Abrir a solução do projeto localizada na pasta Flux
3. No Visual Studio clicar com o botão direito na solução do projeto depois cliclar em propriedades
4. Selecionar Vários projetos de inicialização
5. Selecionar o checkbox de ação para iniciar nos seguintes projetos: Flux.Gateway.Presentation.WebApi, Flux.Movimentacao.Presentation.WebApi, Flux.Consolidado.Presentation.WebApi
6. Clicar em aplicar e executar o projeto

## Descrição da solução

![](/flux-flow.png)

O sistema é dividido em dois projetos os quais são: projeto cliente desenvolvido em Angular 15 e o projeto de back-end feito em Dotnet core.
O projeto de back-end foi estruturado como microserviços tendo 3 partes principais: Gateway, serviço de movimentação e o serviço de consolidado.
Os sistemas Flux.Movimentacao e Flux.Consolidado usam a arquitetura de software limpa onde as camadas tem as dependências a seguir: Entity > Application > Infrastructure > WebApi.
O projeto Entity e Application formam o domínio da aplicação contento todas as regras de negócio. O projeto Application foi desenvolvido usando o padrão de projeto CQRS.

### Responsabilidade dos serviços de back-end

#### Flux.Gateway

A responsabilidade desse projeto é centralizar as requisições vindo do cliente e redirencionar para os serviços correspondentes.

#### Flux.Movimentacao

A responsabilidade desse projeto é gerenciar as entradas e saidas de dinheiro. Ao registrar qualquer movimentação o sistema se comunica com o serviço de consolidado para manter o histórico.

#### Flux.Consolidado
A responsabilidade desse projeto é gerenciar o histórico de consolidado. Além disso tem a função de gerar todo o relatório e gráficos do saldo consolidado anual e diário.
