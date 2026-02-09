# ASSOGW Frontend Redesign — Implementation Summary

## Phase 1: Design System Foundation

- **`source/wwwroot/css/input.css`** — Added 3 new color tokens (`gwm-electric`, `gwm-gray`, `gwm-charcoal`), swapped fonts to Instrument Serif + Inter, added `@layer base` heading styles (weight 400, letter-spacing -0.01em, font smoothing, link transitions) and `@layer components` with `.separator` and `.date-badge`
- **`source/wwwroot/css/site.css`** — Gutted all 283 lines of legacy Bootstrap-era CSS to a single comment
- Deleted `wwwroot/css/quem-somos.css` (empty) and `wwwroot/js/tailwind.config.js` (legacy CDN config)

## Phase 2: Master Layout (`Views/Shared/_Layout.cshtml`)

- Updated Google Fonts link to Instrument Serif + Inter
- Removed Bootstrap Icons CDN `<link>`
- Removed inline `<style>` block (heading fonts now in input.css `@layer base`)
- **Navbar**: `bg-gwm-dark/90 backdrop-blur shadow-lg` → `bg-white/95 backdrop-blur-sm border-b border-gwm-gray/50`
- **Logo**: Text "ASSOGW" → `<img>` SVG logo (`h-10 w-auto`)
- **Nav links**: `text-gray-300 hover:text-gwm-gold rounded-md` → `text-gwm-charcoal hover:text-gwm-blue tracking-wide`
- **Mobile menu**: `bg-gwm-dark border-gray-700` → `bg-white border-gwm-gray/30`
- **Footer**: `bg-gwm-dark` 3-col → `bg-gwm-charcoal` 4-col (Institucional, Rede, Contato, Social)
- **Footer headings**: `text-gwm-gold font-bold` → `text-xs uppercase tracking-widest text-white/40`
- **Footer links**: `text-gray-400 hover:text-white` → `text-white/60 hover:text-white text-sm`
- **Social**: Gold gradient circle icons → text-only links
- **Footer logo**: SVG logo with `brightness-0 invert opacity-80`

## Phase 3: Home Page (`Views/Home/Index.cshtml`)

- **Hero**: Dark gradient bg → clean white bg, left-aligned `text-7xl/8xl` serif headline, eyebrow bronze label, flat dark primary + outlined secondary buttons
- **News section**: Left heading + right "Ver todas" link, borderless cards (image + text stacked), `hover:scale-[1.03]`, whole card is clickable `<a>`, `.date-badge` text below image
- **CTA section**: Icon circles + shadow cards → two text panels with `gap-px bg-gwm-gray/30` hairline divider, `hover:bg-white` background change only
- **Partners strip**: `opacity-60 hover:grayscale-0` → `opacity-40 grayscale` (permanently muted), added "Nossos Parceiros" uppercase label

## Phase 4: Internal Pages

### 4.1 Unified Page Header
All internal pages now use: `pt-32 pb-16 bg-white border-b border-gwm-gray/30` with eyebrow (bronze `.date-badge`) + h1 (serif, gwm-dark)

### 4.2 QuemSomos (`Views/Home/QuemSomos.cshtml`)
- **History**: Removed decorative rotated gold bg, shadows, hover transforms → simple 2-col grid with `gap-24`
- **Mission/Vision/Values**: Removed icon circles, shadow cards, gold borders → `gap-px bg-gwm-gray/30` hairline divider grid
- **Leadership**: Removed card containers and decorative gold circles → `grayscale` photo + name + title, no wrapper

### 4.3 Contact (`Views/Home/Contact.cshtml`)
- Left panel: `bg-gwm-dark` → `bg-gwm-charcoal`, removed decorative blur circles
- Heading: Removed `border-l-4 border-gwm-gold`, clean serif style
- Icons: `bg-white/10 rounded-full`, no gold hover swap
- Social: Outline circles (`border border-white/20`) instead of gold gradient
- Map: Permanently grayscale, removed `hover:grayscale-0`

### 4.4 News Index (`Views/News/Index.cshtml`)
- **Featured**: Removed gradient overlay on image → `aspect-21/9` cinematic crop, image above text below
- **Grid**: Same borderless card pattern as homepage
- **Pagination**: Text-only with `border-b-2` active indicator (no rounded buttons)

### 4.5 News Details (`Views/News/Details.cshtml`)
- **Layout**: Removed 12-col sidebar grid → single-column centered `max-w-4xl`
- **Share buttons**: Removed brand-colored circles → neutral outline circles (`border border-gwm-gray/50`)
- **Recent news**: Moved from sidebar to "Mais Notícias" section at bottom (3-col grid)

### 4.6 Concessionarias (`Views/Concessionarias/Index.cshtml`)
- Removed icon circles, shadow cards, gold borders, hover transforms
- `gap-px bg-gwm-gray/30` grid with serif name + small gray city per cell

### 4.7 Parceiros (`Views/Parceiros/Index.cshtml`)
- Added unified page header
- Removed heavy borders, shadows, `hover:-translate-y`
- Gold section: `border border-gwm-gray/40` cards, no shadows
- Silver/Bronze: same simplification with decreasing size

## Phase 5: Design System (`Views/DesignSystem/Index.cshtml`)

- Updated font labels to Instrument Serif + Inter
- Added all 7 color swatches (blue, dark, gold, bronze, electric, charcoal, gray)
- Updated button styles to flat pattern (no border-radius, no shadows)
- Updated card variations to borderless/hairline patterns
- Added sections for spacing guidelines and page header pattern
- Removed old gradient showcases, round border-radius demos, and heavy shadow demos

## Phase 6: JS & Performance

### `wwwroot/js/site.js`
- Added scroll-aware navbar: `shadow-sm` on scroll, `border-b` at top (uses `requestAnimationFrame` for performance)

### Cleanup
- Deleted `wwwroot/lib/bootstrap/` (45 files)
- Deleted `wwwroot/lib/jquery/` (7 files)
- Deleted `wwwroot/lib/jquery-validation/` (5 files)
- Deleted `wwwroot/lib/jquery-validation-unobtrusive/` (3 files)
- Total: 60 unused library files removed

---

## Before → After Summary

| Element | Before | After |
|---------|--------|-------|
| Heading font | Unna serif (bold) | Instrument Serif (normal weight 400) |
| Body font | Lato sans | Inter |
| Nav | Dark with blur + shadow | White with thin gray border |
| Section spacing | `py-16`/`py-20` | `py-24` consistently |
| Cards | `rounded-xl shadow-lg border-t-4 hover:shadow-2xl` | Borderless or `border border-gwm-gray/30`, no shadow |
| Image hover | `scale-110` | `scale-[1.03]` |
| Buttons | Gold gradient, rounded, shadow, `hover:scale-105` | Flat `bg-gwm-dark` or `border`, no radius |
| Dividers | Gold gradient bar `w-24 h-1` | `border-t border-gwm-gray/30` |
| Footer | Dark, 3-col, gold headings, circle icons | Charcoal, 4-col, text-only social |
| Page heroes | Dark bg, gradient overlay, white text | White bg, serif heading, bronze eyebrow |
| Icons (BI) | `bi-bullseye`, `bi-eye`, `bi-award`, `bi-shop` | Removed (Bootstrap Icons CDN dropped) |

## Build Validation
All phases built successfully with `npm run css:build` (Tailwind v4.1.18, zero errors).
