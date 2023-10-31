# Projeto de Minimal API Catálogo

Este é um projeto de Minimal API Catálogo, que fornece endpoints para gerenciar categorias e produtos em um catálogo.

## Requisitos

- .NET 6.0 SDK
- MySQL Server
- Entity Framework Core
- Pacotes NuGet necessários (consulte o arquivo `.csproj` para obter detalhes)

## Configuração

1. Clone este repositório:

   ```bash
   git clone https://github.com/naylima/MinimalAPI_Catalogo.git
   ```

2. Configure a conexão do banco de dados MySQL no arquivo `appsettings.json`:

   ```json
   {
       "ConnectionStrings": {
           "DefaultConnection": "sua-string-de-conexao"
       },
       // ...
   }
   ```

3. No terminal, navegue até a pasta raiz do projeto e execute as migrações para criar o banco de dados:

   ```bash
   dotnet ef database update
   ```

4. Configure as variáveis de ambiente necessárias para autenticação JWT no arquivo `appsettings.json`:

   ```json
   {
       "Jwt": {
           "Key": "sua-chave-secreta",
           "Issuer": "seu-issuer",
           "Audience": "sua-audiencia"
       },
       // ...
   }
   ```

## Endpoints

### Autenticação

#### POST /login

- Autenticação de usuário e geração de token JWT.

### Categorias

#### GET /categorias

- Recupera a lista de categorias.

#### GET /categorias/{id}

- Recupera uma categoria específica por ID.

#### POST /categorias

- Cria uma nova categoria.

#### PUT /categorias/{id}

- Atualiza uma categoria existente por ID.

#### DELETE /categorias/{id}

- Exclui uma categoria por ID.

### Produtos

#### GET /produtos

- Recupera a lista de produtos.

#### GET /produtos/{id}

- Recupera um produto específico por ID.

#### POST /produtos

- Cria um novo produto.

#### PUT /produtos/{id}

- Atualiza um produto existente por ID.

#### DELETE /produtos/{id}

- Exclui um produto por ID.

## Como Executar

1. Abra um terminal na pasta raiz do projeto.

2. Execute o seguinte comando para iniciar o aplicativo:

   ```bash
   dotnet run
   ```

3. O aplicativo estará disponível em `http://localhost:7227`.
   Para acessar a documentação da API via Swagger, abra seu navegador da web e vá para:
   `http://localhost:7227/swagger/index.html`
   Isso permitirá que você explore e teste os endpoints da API de forma interativa usando o Swagger UI.
