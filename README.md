# HealthTrack

HealthTrack é um sistema de gestão de saúde voltado para consultórios médicos de pequeno porte, desenvolvido como um MVP com foco em organização administrativa e boas práticas de desenvolvimento backend em .NET.
O objetivo do projeto é consolidar fundamentos reais de backend, simulando um sistema utilizado em ambiente profissional, servindo também como projeto de portfólio para entrevistas técnicas.

## Funcionalidades

- Gerenciamento de Médicos
- Gerenciamento de Pacientes
- Estrutura preparada para Consultas (em evolução)

### Funcionalidades Implementadas

- Autenticação básica (login simples)
- Menu de navegação (Home, Médicos, Pacientes)
- Listagem de Médicos e Pacientes
- Cadastro de Médicos e Pacientes
- Layout responsivo com Bootstrap 5

---

### Em Desenvolvimento

- Edição e exclusão de Médicos e Pacientes
- Tela de Consultas
- Filtros e pesquisa
- Relatórios
- Autenticação com ASP.NET Identity
- Testes unitários

---

## Tecnologias Utilizadas

- .NET 9.0
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5

## Estrutura do Projeto

```

/Controllers  
- AccountController.cs  
- HomeController.cs  
- PacienteController.cs  
- MedicoController.cs  

/Models  
- Paciente.cs  
- Medico.cs  
- Consulta.cs  

/Data  
- HealthTrackContext.cs  

/Views  
- Home  
- Paciente  
- Medico  
- Shared 

```

## Como Executar

1. Clone o repositório:

```bash
git clone https://github.com/NCS-DEVX/HealthTrack.git
```

2. Abra a pasta do projeto:

```bash
cd HealthTrack
```

3. Restaure os pacotes NuGet:

```bash
dotnet restore
```

4. Atualize o banco de dados (caso tenha alterações):

```bash
dotnet ef database update
```

5. Execute a aplicação:

```bash
dotnet run
```

A aplicação estará disponível em:

```text
http://localhost:5126
```

## Usuário de Teste

- **Usuário:** admin  
- **Senha:** admin123

## Observações

- Projeto em desenvolvimento contínuo
- A autenticação atual é simplificada
- Estrutura pensada para evolução gradual de arquitetura

## Licença

Este projeto é de uso pessoal e acadêmico.
