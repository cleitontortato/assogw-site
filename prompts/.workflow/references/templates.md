# Stage Templates

Replace `{task-name}` with the actual task name in snake_case.
Replace `{Título da Tarefa}` with a human-readable title.
Replace content in `[brackets]` with actual values.

---

## INTENT Template

```markdown
# {Título da Tarefa} - INTENT

## Role
[Persona the CLI should assume, e.g.:]
Atue como um [Arquiteto de Software .NET Sênior / Dev Android Sênior / Frontend Engineer React / etc.].

## Objetivo
[2-3 sentences: what this task accomplishes and why]

## Escopo
1. [Deliverable 1]
2. [Deliverable 2]
3. [Deliverable 3]

## Constraints
- **Linguagem:** [Java / C# / Dart / TypeScript / etc.]
- **Padrão a seguir:** [Reference existing code pattern, e.g. "Siga ProductModelsController"]
- **Versão FREE/PRO:** [If applicable]
- **Não fazer:** [Explicit exclusions]

## Referências
[IF project has docs/:]
- Consulte `@docs/readme.md` para a documentação do projeto
[IF project has NO docs/:]
- Analise a estrutura do projeto e código existente para contexto
- Referência de código: `@path/to/ExistingFile.ext` [describe why]
- ViewModel/Model: `@path/to/Model.ext`

## Fora do Escopo
- [Item explicitly excluded 1]
- [Item explicitly excluded 2]

---
## Próxima Etapa: Gerar PRD

**Instrução para a CLI:**

Leia o arquivo `prompts/{task-name}_INTENT.md` e gere um PRD detalhado.

[IF project has docs/:]
Leia `docs/readme.md` para entender a documentação disponível do projeto.
[IF project has NO docs/:]
Não há pasta docs/. Analise a estrutura do projeto e o código existente
para entender arquitetura, padrões e convenções antes de gerar.

O PRD deve conter:
1. Visão Geral e link para o INTENT
2. Requisitos Detalhados para cada item do Escopo
3. User Stories por perfil de usuário
4. Requisitos Técnicos (arquivos, dependências, configs)
5. Riscos e Mitigação
6. Critérios de Sucesso
7. Instruções para gerar o PLAN na próxima etapa

Salve o resultado em `prompts/{task-name}_PRD.md`.
```

---

## PRD Template

```markdown
# {Título da Tarefa} - PRD

**Origem:** `prompts/{task-name}_INTENT.md`

## 1. Visão Geral
[Summary of what is being built and why, referencing the INTENT]

## 2. Requisitos Detalhados

### 2.1. [Deliverable 1 Name]
**Estado Atual:** [What exists today]
**Estado Alvo:** [What it should become]

#### Especificação
[Detailed requirements, tables, behavior specs]

#### Arquivos Envolvidos
| Arquivo | Ação | Descrição |
|---------|------|-----------|
| `path/to/file` | CREATE / MODIFY | [What changes] |

### 2.2. [Deliverable 2 Name]
[Same structure as above]

## 3. User Stories

| ID | User Story | Critério de Aceite |
|----|------------|-------------------|
| US-01 | Como [persona], eu [ação] para [benefício] | [Measurable acceptance criteria] |

## 4. Requisitos Técnicos

### 4.1. Dependências
[New packages, SDKs, versions to verify]

### 4.2. Configurações
[Config keys, environment variables, resource strings]

### 4.3. Arquivos a Criar
| Arquivo | Propósito |
|---------|-----------|
| `path/to/NewFile.ext` | [Purpose] |

### 4.4. Arquivos a Modificar
| Arquivo | Alteração |
|---------|-----------|
| `path/to/ExistingFile.ext` | [What changes] |

## 5. Riscos e Mitigação

| Risco | Impacto | Mitigação |
|-------|---------|-----------|
| [Risk] | Alto/Médio/Baixo | [How to prevent/handle] |

## 6. Premissas Assumidas
[Only if the INTENT was ambiguous about something. List what was assumed:]
- [e.g. "INTENT não especificou versão do SDK; assumido 23.5.0 (atual no build.gradle)"]
- [e.g. "INTENT diz 'siga ProductModelsController'; assumido que inclui paginação"]

## 7. Critérios de Sucesso

| Métrica | Atual | Alvo | Medição |
|---------|-------|------|---------|
| [Metric] | [Current] | [Target] | [How to measure] |

**IMPORTANTE:** NÃO inclua checklists de implementação ou quebra de tarefas por
fase neste documento — isso é responsabilidade do PLAN.

---
## Próxima Etapa: Gerar PLAN

**Instrução para a CLI:**

Leia o arquivo `prompts/{task-name}_PRD.md` e gere um Plano de
Implementação detalhado.

[IF project has docs/:]
Leia `docs/readme.md` para entender a documentação disponível do projeto.
[IF project has NO docs/:]
Não há pasta docs/. Analise a estrutura do projeto e o código existente
para entender arquitetura, padrões e convenções.

Analise os arquivos de código-fonte referenciados no PRD.

O PLAN deve conter:
1. Ordem de Implementação com dependências
2. Alterações arquivo por arquivo com código COMPLETO (BEFORE/AFTER)
3. Checkpoints de teste após cada grupo lógico
4. Verificação final (build, testes, checks manuais)
5. Plano de rollback
6. Instrução para salvar o sumário em DEV ao executar

Todo código deve ser COMPLETO e EXECUTÁVEL — sem pseudocódigo.

Salve o resultado em `prompts/{task-name}_PLAN.md`.
```

---

## PLAN Template

```markdown
# {Título da Tarefa} - PLAN

**Origem:** `prompts/{task-name}_PRD.md`

## 1. Ordem de Implementação

### Fase A: [Group Name, e.g. Infrastructure]
| # | Tarefa | Complexidade | Arquivos |
|---|--------|-------------|----------|
| 1.1 | [Task] | Baixa/Média/Alta | [file] |

### Fase B: [Group Name]
| # | Tarefa | Complexidade | Arquivos |
|---|--------|-------------|----------|
| 2.1 | [Task] | Baixa/Média/Alta | [file] |

### Árvore de Dependências
```
[dependency diagram]
```

## 2. Alterações Arquivo por Arquivo

### 2.1. [filename] — [Action: CREATE/MODIFY]
**Caminho:** `full/path/to/file.ext`

[For MODIFY: BEFORE/AFTER blocks]
```[lang]
// BEFORE (lines X-Y):
[existing code]

// AFTER:
[new code]
```

[For CREATE: complete file content]
```[lang]
[complete file content]
```

### 2.2. [next file...]

## 3. Checkpoints de Teste

### Após Fase A
- [ ] [Verification step]
- [ ] [Build command]

### Após Fase B
- [ ] [Verification step]

## 4. Verificação Final

### Comandos de Build
```bash
[build commands]
```

### Checklist Manual
- [ ] [Test item]

## 5. Rollback

### Estratégia de Branch
```bash
git checkout -b feature/{task-name}
# commit after each phase
```

### Reverter por Fase
| Fase | Comando |
|------|---------|
| Tudo | `git checkout main -- .` |
| Fase A | `git checkout main -- [files]` |

---
## Próxima Etapa: Executar PLAN

**Instrução para a CLI:**

Leia o arquivo `prompts/{task-name}_PLAN.md` e execute as alterações na
ordem especificada na Seção 1.

Para cada arquivo:
- Se é CREATE: crie com o conteúdo exato especificado
- Se é MODIFY: aplique as alterações BEFORE/AFTER

Após cada fase, execute o checkpoint de teste correspondente.

Ao concluir, salve o sumário da execução em `prompts/{task-name}_DEV.md`
com a seguinte estrutura:
- Status (COMPLETED / PARTIAL / FAILED)
- Arquivos Criados (tabela: caminho + propósito)
- Arquivos Modificados (tabela: caminho + o que mudou)
- Funcionalidades Implementadas (agrupadas por feature, com ✅ ou ❌)
- Ajustes de Compilação (desvios do PLAN e motivo)
- Dependências Pendentes (bloqueios externos não resolvidos)
- Validações Realizadas (o que foi verificado: build, syntax, links)
- Checklist Pré-Release (itens pendentes antes de ir para produção)
- Comandos de Build
```

---

## DEV Template

```markdown
# {Título da Tarefa} - DEV

**Origem:** `prompts/{task-name}_PLAN.md`
**Data:** [execution date]

## Status: [COMPLETED / PARTIAL / FAILED]

## 1. Arquivos Criados

| Arquivo | Propósito |
|---------|-----------|
| `path/to/file.ext` | [Purpose] |

## 2. Arquivos Modificados

| Arquivo | Alteração |
|---------|-----------|
| `path/to/file.ext` | [What changed] |

## 3. Funcionalidades Implementadas

### [Feature Group 1]
- ✅ [Item implemented successfully]
- ✅ [Item implemented successfully]
- ❌ [Item not implemented — reason]

### [Feature Group 2]
- ✅ [Item implemented successfully]

## 4. Ajustes de Compilação
[Any deviations from PLAN: what was different and why]
- [Adjustment 1]
- [Adjustment 2]

## 5. Dependências Pendentes
[External blockers not resolved during implementation]
- [e.g. "Logo images: using placeholders until real assets are provided"]
- [e.g. "Production API keys: replace TEST keys in config before release"]

## 6. Validações Realizadas
- ✅ [e.g. "Build successful (dotnet build / gradlew assembleFreeDebug)"]
- ✅ [e.g. "JSON syntax validated"]
- ✅ [e.g. "All external links verified (target=_blank, rel=noopener)"]

## 7. Checklist Pré-Release

- [ ] [Pending item 1]
- [ ] [Pending item 2]

## 8. Comandos de Build

```bash
[exact build/test commands]
```

---

**Referências:**
- INTENT: `prompts/{task-name}_INTENT.md`
- PRD: `prompts/{task-name}_PRD.md`
- PLAN: `prompts/{task-name}_PLAN.md`
```
