📚 Gerenciador de Livros API
API REST desenvolvida para o gerenciamento de uma biblioteca pessoal, permitindo o cadastro, consulta, atualização e exclusão de livros.

📖 Sobre o Projeto
Este projeto consiste em uma API para gerenciar uma coleção de livros. Foi construído utilizando as tecnologias mais recentes do ecossistema .NET, com foco em aprender boas práticas de desenvolvimento e uma arquitetura organizada.

A aplicação expõe endpoints para todas as operações CRUD (Create, Read, Update, Delete) relacionadas aos livros, e toda a documentação pode ser consultada de forma interativa através do Swagger.

🛠️ Tecnologias Utilizadas
.NET 9: A mais nova versão do framework da Microsoft, garantindo performance e acesso aos recursos mais modernos.

ASP.NET Core Web API: Para a construção dos endpoints REST.

Entity Framework Core: Como ORM para a comunicação com o banco de dados.

SQL Server: Sistema de Gerenciamento de Banco de Dados relacional.

Swagger: Para documentação e teste interativo da API.

⚙️ Configuração e Instalação
Para executar este projeto localmente, siga os passos abaixo.

Pré-requisitos
.NET 9 SDK

Uma instância do SQL Server.

Um editor de código de sua preferência (Visual Studio, VS Code, etc.).

Passo a Passo
Clone o repositório:

git clone https://github.com/Helon21/Gerenciador_Livros.git

Navegue até a pasta do projeto:

cd Gerenciador_Livros

Configure as variáveis de ambiente: Este projeto utiliza um arquivo .env para carregar a senha do banco de dados de forma segura. Crie um arquivo chamado .env na raiz do projeto.

Dentro do arquivo .env, adicione a seguinte variável com a sua senha do SQL Server:

# .env
DB_PASSWORD=sua_senha_super_secreta_aqui

Atenção: A connection string no arquivo appsettings.json já está configurada para ler esta variável. Certifique-se de que o restante da string (servidor, nome do banco, usuário) corresponde à sua configuração local.

Aplique as Migrations do Entity Framework: Este comando irá criar o banco de dados e as tabelas necessárias com base nos modelos definidos no projeto.

dotnet ef database update

🚀 Executando a Aplicação
Com tudo configurado, inicie a aplicação com o seguinte comando:

dotnet run (ou através da IDE)

Por padrão, a aplicação estará disponível em https://localhost:7008 ou http://localhost:5284 (verifique o seu launchSettings.json).

📄 Documentação da API (Swagger)
A documentação completa de todos os endpoints disponíveis está gerada automaticamente e pode ser acessada de forma interativa através do Swagger UI.

Após iniciar a aplicação, acesse a seguinte URL no seu navegador:

http://localhost:porta/swagger

Lá você poderá ver todos os endpoints, seus parâmetros, schemas e até mesmo testá-los diretamente pelo navegador.
