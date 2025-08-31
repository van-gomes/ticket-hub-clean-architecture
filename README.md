# TicketHub

TicketHub é uma aplicação construída com C# e React que segue os princípios da Arquitetura Limpa e Hexagonal.
Ela visa oferecer uma base robusta para criação de sistemas modulares, testáveis e escaláveis desde o início.

---

## 📂 Estrutura do Projeto

```
TicketHub/
├── backend_TicketHub/
│   ├── TicketHub.Domain/
│   ├── TicketHub.Application/
│   ├── TicketHub.Infrastructure/
│   ├── TicketHub.WebAPI/
│   ├── TicketHub.Documentation/
│   └── tests/
│       ├── TicketHub.UnitTests/
│       └── TicketHub.IntegrationTests/
├── frontend_TicketHub/
│   └── ... (em desenvolvimento)
```

---

## 🚀 Como Executar

### 1. Backend (.NET 8)

No diretório `backend_TicketHub`:

```bash
dotnet restore
dotnet build
dotnet run --project TicketHub.WebAPI
```

### 2. Testes

```bash
dotnet test tests/TicketHub.UnitTests
dotnet test tests/TicketHub.IntegrationTests
```

---

## 🧪 Testes e Qualidade

- Testes Unitários: Cobrem regras de negócio puras.
- Testes de Integração: Cobrem serviços, repositórios e banco de dados (ex: SQLite in-memory).
- Em breve:
  - Coverage com `coverlet` ou `ReportGenerator`
  - Testes End-to-End (E2E) com Cypress no frontend

---

## 🐳 Docker (Planejado)

- Backend com imagem multi-stage
- Banco SQLite ou PostgreSQL
- Frontend React com Nginx

---

## 🔁 CI/CD (Planejado)

- GitHub Actions
  - Build + Testes a cada push
  - Deploy automatizado (Docker Hub, Vercel, etc.)

---

## 🤝 Como Contribuir

1. Faça um fork do projeto
2. Crie uma branch: `git checkout -b feature/nova-funcionalidade`
3. Commits claros e concisos
4. Testes sempre que possível
5. Envie o PR com uma descrição objetiva

---

## 📄 Licença

Este projeto está sob a licença MIT.
