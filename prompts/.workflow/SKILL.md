---
name: spec-driven-dev
description: >
  Spec Driven Development workflow for planning and executing software tasks
  through a 4-stage document chain: INTENT → PRD → PLAN → DEV. Use this skill
  when the user wants to: (1) plan a new feature or change using the spec-driven
  workflow, (2) draft an INTENT document from an informal description, (3) review
  or improve any stage document (INTENT, PRD, PLAN, DEV), (4) understand or apply
  the INTENT→PRD→PLAN→DEV pipeline, (5) set up the prompts/ and docs/ folder
  structure for a project. Triggers on keywords like "intent", "PRD", "plan",
  "spec driven", "workflow", "task pipeline", or references to the 4-stage flow.
  Language and framework agnostic — works with Android, Flutter, ASP.NET, React,
  or any stack.
---

# Spec Driven Development Workflow

## Overview

A 4-stage document chain where each stage generates the next. Designed to run
with AI CLI tools (Claude Code, Gemini CLI, etc.) with human review between stages.

```
INTENT ──→ PRD ──→ PLAN ──→ DEV
  ↑          ↑       ↑        ↑
 human    human    human    human
 writes   reviews  reviews  validates
```

**Folders:**
- `prompts/` — All workflow documents live here (configurable via `PROMPTS_DIR`)
- `docs/` — Persistent project reference (architecture, scope, conventions, integrations)

## Naming Convention

All files follow: `{task-name}_{STAGE}.md`

Examples:
- `ad_improvements_phase1_INTENT.md`
- `create_lead_source_categories_PRD.md`
- `migrate_auth_to_oauth2_PLAN.md`

The `{task-name}` uses `snake_case`, is descriptive, and stays consistent across all 4 stages.

## Stage Definitions

### Stage 1: INTENT

**Who writes:** Human (or human + Claude in chat)
**Purpose:** Define WHAT to build, WHY, and the boundaries.
**Kept lean.** No implementation details — those belong in PRD and PLAN.

Required sections:
1. **Role** — What persona the CLI should assume (e.g. "Atue como um Arquiteto .NET Sênior", "Atue como um Dev Android Sênior com experiência em AdMob")
2. **Objetivo** — What this task accomplishes (2-3 sentences)
3. **Escopo** — Numbered list of deliverables
4. **Constraints** — Hard rules (language, patterns, what NOT to do)
5. **Referências** — Either `docs/readme.md` OR specific code files the CLI must read
6. **Fora do Escopo** — Explicitly excluded items
7. **Gerar PRD** — Chain instructions (see Chain Section below)

**Anti-patterns to avoid in INTENT:**
- Architecture details → move to PRD
- Risk mitigation → move to PRD
- Code examples → move to PLAN
- Dependency checks → move to PRD

### Stage 2: PRD (Product Requirements Document)

**Who writes:** CLI (from INTENT), human reviews
**Purpose:** Detail HOW the requirements will be satisfied, without writing code.

Required sections:
1. **Visão Geral** — Summary + link to INTENT
2. **Requisitos Detalhados** — One subsection per deliverable from INTENT
3. **User Stories** — From each relevant user perspective
4. **Requisitos Técnicos** — Files to create/modify, dependencies, configs
5. **Riscos e Mitigação** — What can go wrong + countermeasures
6. **Premissas Assumidas** — Ambiguities from INTENT that were resolved with assumptions
7. **Critérios de Sucesso** — Measurable outcomes
8. **Gerar PLAN** — Chain instructions (see Chain Section below)

**Key rule:** The PRD must acquire project context. If `docs/` exists, instruct:
`"Leia @docs/readme.md para entender a documentação do projeto."`
If no `docs/`, instruct:
`"Analise a estrutura do projeto e o código existente para contexto."`

**Anti-pattern:** Do NOT include implementation checklists or phase-by-phase task
breakdowns in the PRD — that is the PLAN's job. The PRD defines WHAT and WHY,
the PLAN defines HOW and IN WHAT ORDER.

### Stage 3: PLAN (Implementation Plan)

**Who writes:** CLI (from PRD), human reviews
**Purpose:** Step-by-step recipe that another CLI session can execute mechanically.

Required sections:
1. **Ordem de Implementação** — Dependency tree + sequence
2. **Alterações Arquivo por Arquivo** — For each file:
   - Full path
   - Action: CREATE / MODIFY / DELETE
   - BEFORE/AFTER code blocks (for MODIFY)
   - Complete content (for CREATE)
3. **Checkpoints de Teste** — After each logical group, how to verify
4. **Verificação Final** — Build commands, test commands, manual checks
5. **Rollback** — How to undo if things break
6. **Gerar DEV** — Chain instructions (see Chain Section below)

**Key rules:**
- All code is COMPLETE and RUNNABLE — no pseudocode, no "..."
- Code must be in the project's language (specified in INTENT constraints)
- Follow conventions from `docs/`

### Stage 4: DEV (Execution Summary)

**Who writes:** CLI (after executing PLAN)
**Purpose:** Record what was actually done. Audit trail.

Required sections:
1. **Status** — COMPLETED / PARTIAL / FAILED
2. **Arquivos Criados** — Table: file path + purpose
3. **Arquivos Modificados** — Table: file path + what changed
4. **Funcionalidades Implementadas** — Grouped by feature, each item with ✅ or ❌
5. **Ajustes de Compilação** — Any deviations from the PLAN and why
6. **Dependências Pendentes** — External blockers (assets, configs, credentials)
7. **Validações Realizadas** — What was verified (build, syntax, links, etc.)
8. **Checklist Pré-Release** — Outstanding items before going live
9. **Comandos de Build** — Exact commands to build/test

## Chain Instructions Format

Every stage document ends with a standardized section that instructs the CLI
to generate the next stage. Use this exact pattern:

```markdown
---
## Próxima Etapa: Gerar {NEXT_STAGE}

**Instrução para a CLI:**

Leia o arquivo `prompts/{task-name}_{CURRENT_STAGE}.md` e gere o próximo
artefato seguindo as regras da etapa {NEXT_STAGE} do workflow Spec Driven Dev.

[IF docs/ exists:]
Leia `docs/readme.md` para entender a documentação disponível do projeto.

[IF no docs/:]
Não há pasta docs/. Analise a estrutura do projeto e o código existente
para entender arquitetura, padrões e convenções antes de gerar.

Salve o resultado em `prompts/{task-name}_{NEXT_STAGE}.md`.
```

For the PLAN (last chain step before execution), replace with:

```markdown
---
## Próxima Etapa: Executar PLAN

**Instrução para a CLI:**

Leia o arquivo `prompts/{task-name}_PLAN.md` e execute as alterações na
ordem especificada. Após concluir, salve o sumário da execução em
`prompts/{task-name}_DEV.md` seguindo a estrutura da etapa DEV.
```

## Project Context: `docs/` or Codebase Scan

**Two modes depending on the project:**

### Mode A: Project has `docs/`
If a `docs/` folder exists, it ALWAYS contains a `readme.md` that indexes
the available documentation. The CLI should read `docs/readme.md` FIRST
to understand what other docs exist and when to consult them.

The structure and contents of `docs/` vary per project — there is no fixed
schema. The `readme.md` is the only guaranteed file.

Chain instructions should include:
`"Leia @docs/readme.md para entender a documentação disponível do projeto."`

### Mode B: Project has no `docs/`
Smaller or legacy projects may have no documentation folder. In this case,
the CLI must scan the codebase directly to understand the project:
- Read key files (entry points, configs, manifests, build files)
- Identify patterns, language, framework, folder structure
- Infer conventions from existing code

Chain instructions should include:
`"Não há pasta docs/. Analise a estrutura do projeto e o código existente
para entender arquitetura, padrões e convenções antes de gerar."`

**The INTENT determines which mode applies.** If the author knows `docs/`
exists, they reference it. If not, they point to specific code files as
reference instead.

## Amendment Protocol

Later stages sometimes reveal gaps in earlier documents. Rules:

**During PRD generation** — If the CLI identifies ambiguity in the INTENT,
it should flag it in the PRD under a new section "Premissas Assumidas"
(assumptions made). The human reviews these before proceeding.

**During PLAN generation** — If the CLI discovers the PRD missed a file,
dependency, or technical detail, it adds it to the PLAN with a note:
`"[Adição ao PRD: ...]"`. The PRD is NOT retroactively edited — the PLAN
is the source of truth for implementation.

**During execution** — If the code diverges from the PLAN (e.g., method
signature doesn't match, API returns differently), the DEV records it in
"Ajustes de Compilação" with the reason. The PLAN is NOT retroactively edited.

**Principle:** Documents flow forward, never backward. Each stage can ADD
context but never CONTRADICT the previous stage. If a contradiction is
found, the human must decide: fix the earlier doc and re-run, or accept
the amendment in the current stage.

## Review Guide (Human Checkpoints)

What to verify at each stage before proceeding:

### After INTENT (before generating PRD)
- Is the scope small enough for one chain? (see Task Decomposition below)
- Are constraints explicit about language and patterns?
- Are references pointing to real files?
- Is "Fora do Escopo" clear enough to prevent scope creep?

### After PRD (before generating PLAN)
- Does every INTENT deliverable have a corresponding "Requisitos Detalhados" section?
- Are the files to create/modify realistic? (no phantom files)
- Do the user stories cover all affected personas?
- Are risks identified for anything that could block execution?
- Is it FREE of implementation checklists? (that's the PLAN's job)

### After PLAN (before executing)
- Does every file change have COMPLETE code? (no "...", no pseudocode)
- Are BEFORE/AFTER blocks accurate to the current codebase?
- Do checkpoints include build commands that can actually run?
- Is the rollback section actionable?
- Is the chain instruction to generate DEV present and complete?

### After DEV (before merging)
- Are all INTENT deliverables marked ✅ or ❌?
- Are "Ajustes de Compilação" reasonable or signs of a bad PLAN?
- Are "Dependências Pendentes" tracked for follow-up?
- Does the build command succeed right now?

## Task Decomposition

**When to split a task into multiple chains:**

A single INTENT → DEV chain should represent ONE cohesive change that can
be merged independently. Split when:

- **Scope exceeds ~10 files modified** — likely too big for one chain
- **Multiple unrelated features** — each feature deserves its own chain
- **Sequential dependency** — Feature B needs Feature A merged first; make
  two separate chains, with B's INTENT referencing A's DEV as prerequisite
- **Different expertise domains** — backend API + frontend UI + mobile app
  are better as separate chains even if they're "one feature"

**Naming for related chains:**
```
feature_auth_phase1_INTENT.md   (backend API)
feature_auth_phase2_INTENT.md   (frontend integration)
```

**Cross-chain references:** When tasks are related, the later INTENT should
include under Referências: `"Prerequisito: prompts/feature_auth_phase1_DEV.md"`

## Working with This Skill

### Drafting an INTENT from conversation

When the user describes a task informally, help structure it into INTENT format:
1. Extract the objective and scope from the conversation
2. Determine the appropriate role/persona for the CLI to assume
3. Identify constraints (language, patterns, what to avoid)
4. Determine if the project has `docs/` — if yes, reference `docs/readme.md`;
   if no, identify key code files the CLI should read for context
5. Evaluate if the task should be split (see Task Decomposition)
6. Produce the INTENT markdown following the template in `references/templates.md`

### Reviewing a stage document

When the user shares a stage document for review:
1. Check it follows the required sections for that stage
2. Apply the stage-specific checklist from the Review Guide above
3. Flag missing information or sections
4. Check the chain instructions point to the correct next file
5. Verify naming convention consistency

### For complete templates of each stage, read `references/templates.md`.
