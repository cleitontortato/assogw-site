# Bootstrap: Gerar Documentação do Projeto

## Instrução para a CLI

Atue como um Arquiteto de Software Sênior. Sua tarefa é analisar este projeto
e gerar uma documentação estruturada na pasta `docs/`.

### Passo 1: Varredura do Projeto

Analise a estrutura completa do projeto:

1. **Estrutura de pastas** — liste a árvore de diretórios (2-3 níveis)
2. **Arquivos de configuração** — leia: manifests, build files, package.json,
   .csproj, build.gradle, pubspec.yaml, Dockerfile, docker-compose, .env.example
3. **Entry points** — identifique: main, Program.cs, App.java, index.ts, etc.
4. **Dependências** — extraia de: package.json, .csproj, build.gradle, requirements.txt, pubspec.yaml
5. **Models/Entities** — identifique entidades de domínio e seus relacionamentos
6. **Rotas/Endpoints** — mapeie controllers, routes, API endpoints
7. **Padrões de código** — observe: naming conventions, arquitetura (MVC, Clean, etc.),
   linguagem predominante, uso de DI, testes

### Passo 2: Gerar Documentação

Crie os seguintes arquivos. Adapte o conteúdo ao que o projeto realmente tem —
se um tópico não se aplica, omita-o em vez de inventar.

---

#### `docs/readme.md`
Índice da documentação. Sempre o primeiro arquivo a ser lido.

```markdown
# {Nome do Projeto} — Documentação

## Documentos Disponíveis

| Documento | Descrição |
|-----------|-----------|
| [architecture.md](architecture.md) | Stack técnico, estrutura de pastas, padrões |
| [scope.md](scope.md) | Escopo funcional, features, entidades |
| [conventions.md](conventions.md) | Convenções de código, naming, commits |
| [integrations.md](integrations.md) | APIs, SDKs, serviços externos |

*Gerado automaticamente em {data}. Revise e ajuste conforme necessário.*
```

Omita da tabela qualquer documento que não faça sentido para o projeto.

---

#### `docs/architecture.md`
Deve conter APENAS o que foi encontrado no código:

- **Tech Stack** — linguagem, framework, versão, banco de dados
- **Estrutura de Pastas** — árvore comentada (o que cada pasta faz)
- **Padrões Arquiteturais** — MVC, Clean Architecture, Repository Pattern, etc.
- **Build & Run** — comandos para buildar, rodar, testar
- **Módulos/Projetos** — se for monorepo ou multi-module, descreva cada um
- **Ambientes** — dev, staging, prod (se identificável)

---

#### `docs/scope.md`
Deve conter:

- **O que o projeto faz** — descrição funcional em 3-5 frases
- **Entidades Principais** — lista com breve descrição de cada uma
- **Features/Módulos Funcionais** — agrupados por área
- **Fluxos Principais** — os 3-5 fluxos mais importantes do sistema
- **Perfis de Usuário / Roles** — se houver controle de acesso

---

#### `docs/conventions.md`
Deve conter APENAS o que foi inferido do código existente:

- **Linguagem e Style Guide** — tabs vs spaces, naming (camelCase, PascalCase, snake_case)
- **Estrutura de Arquivos** — onde ficam controllers, models, views, services, tests
- **Padrões de Naming** — como são nomeados: classes, métodos, variáveis, arquivos
- **Git** — branch naming, commit messages (se houver histórico acessível)
- **Tratamento de Erros** — padrão observado (exceptions, Result pattern, etc.)
- **Testes** — framework usado, onde ficam, convenção de nomes

---

#### `docs/integrations.md`
Apenas se o projeto tiver integrações externas:

- **APIs Consumidas** — URL base, autenticação, propósito
- **SDKs/Bibliotecas Chave** — nome, versão, pra que serve
- **Banco de Dados** — tipo, connection string pattern, migrations
- **Serviços Externos** — email, storage, analytics, push notifications, etc.
- **Autenticação/Autorização** — método usado (JWT, cookies, Identity, OAuth)

Se o projeto não tem integrações externas relevantes, NÃO crie esse arquivo.

### Passo 3: Revisão Final

Após gerar todos os arquivos:

1. Releia cada documento e remova qualquer informação INVENTADA ou SUPOSTA —
   documente apenas o que foi observado no código
2. Marque com `[TODO: verificar]` qualquer item que não ficou 100% claro
3. Confirme que `docs/readme.md` referencia apenas os documentos que foram criados

### Regras

- **NÃO invente** — se não encontrou evidência no código, não documente
- **Marque incertezas** — use `[TODO: verificar]` para itens duvidosos
- **Português** — toda documentação em português brasileiro
- **Conciso** — cada doc deve ter no máximo 2-3 páginas; prefira tabelas a prosa
- **Salve tudo em `docs/`** — crie a pasta se não existir
