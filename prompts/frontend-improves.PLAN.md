# ASSOGW Frontend Redesign Plan

## Context

The ASSOGW website currently uses a "dark corporate" aesthetic with heavy gradients, large shadows, flashy hover transforms, and gold accent borders. The user wants to transform it into a **premium editorial-style portal** inspired by Polestar — ultra-minimal, typography-driven, generous whitespace, and restrained color use. A new expanded color palette and SVG logo were provided.

**Design principles:** less is more, typography as hero, generous whitespace, restrained color, subtle micro-interactions, editorial quality.

---

## Phase 1: Design System Foundation

### 1.1 Fonts
**Replace:** Unna (serif) + Lato (sans) → **Instrument Serif** (headings, normal weight) + **Inter** (body/UI)

Instrument Serif reads as modern luxury editorial. Inter is razor-sharp at all sizes and feels premium.

### 1.2 `wwwroot/css/input.css`
- Add 3 new color tokens: `--color-gwm-electric: #0129FF`, `--color-gwm-gray: #D6D6D6`, `--color-gwm-charcoal: #2E2E2E`
- Update font families to Instrument Serif + Inter
- Add `@layer base` with heading styles (`font-weight: 400`, `letter-spacing: -0.01em`), font smoothing, link transitions
- Add `@layer components` with `.separator` (thin gold line) and `.date-badge` (uppercase bronze date text)

### 1.3 `wwwroot/css/site.css`
**Gut entirely.** All 283 lines are dead Bootstrap-era CSS superseded by Tailwind classes. Replace with a minimal comment.

### 1.4 Cleanup
- Delete `wwwroot/css/quem-somos.css` (empty, comment only)
- Delete `wwwroot/js/tailwind.config.js` (legacy CDN config, replaced by input.css @theme)
- Remove Bootstrap Icons CDN from `_Layout.cshtml` — replace the 4 BI usages with FontAwesome equivalents (`bi-bullseye`→`fa-bullseye`, `bi-eye`→`fa-eye`, `bi-award`→`fa-award`, `bi-shop`→`fa-store`)

---

## Phase 2: Master Layout (`Views/Shared/_Layout.cshtml`)

### 2.1 `<head>`
- Update Google Fonts link: `Instrument+Serif:ital@0;1` + `Inter:wght@300;400;500;600;700`
- Remove Bootstrap Icons CDN `<link>`
- Remove inline `<style>` block (heading fonts now in input.css `@layer base`)

### 2.2 Navbar
| Element | Before | After |
|---------|--------|-------|
| Background | `bg-gwm-dark/90 backdrop-blur shadow-lg` | `bg-white/95 backdrop-blur-sm border-b border-gwm-gray/50` |
| Logo | Text "ASSOGW" in white | `<img>` SVG logo (`h-10 w-auto`) |
| Links | `text-gray-300 hover:text-gwm-gold rounded-md` | `text-gwm-charcoal hover:text-gwm-blue tracking-wide` |
| Mobile menu | `bg-gwm-dark border-gray-700` | `bg-white border-gwm-gray/30` |
| Mobile links | `text-gray-300 hover:text-gwm-gold` | `text-gwm-charcoal hover:text-gwm-blue` |

### 2.3 Footer
| Element | Before | After |
|---------|--------|-------|
| Background | `bg-gwm-dark` | `bg-gwm-charcoal` |
| Layout | 3 columns | 4 columns (Institucional, Rede, Contato, Social) |
| Headers | `text-gwm-gold font-bold` | `text-xs uppercase tracking-widest text-white/40` |
| Links | `text-gray-400 hover:text-white` | `text-white/60 hover:text-white text-sm` |
| Social | Gold gradient circle icons | Text-only links (no icons) |
| Logo | None | SVG logo with `brightness-0 invert opacity-80` |

---

## Phase 3: Home Page (`Views/Home/Index.cshtml`)

### 3.1 Hero
| Before | After |
|--------|-------|
| Dark gradient bg + overlay image | Clean white bg |
| Centered, gradient text, drop-shadows | Left-aligned, `text-7xl/8xl` serif headline |
| Two gradient/glass CTA buttons | Flat dark primary + outlined secondary |
| `min-h-[60vh]` | `pt-32 pb-24 md:pt-40 md:pb-32` |

Structure: eyebrow label (bronze uppercase) → large serif heading → subtitle paragraph → two flat buttons.

### 3.2 News Section
| Before | After |
|--------|-------|
| `shadow-lg hover:shadow-2xl rounded-xl` cards | Borderless: image + text stacked |
| Centered heading + gold underline | Left heading + right "Ver todas" link |
| `hover:scale-110` on images | `hover:scale-[1.03]` (subtle) |
| Separate "Ler Mais" link per card | Whole card is clickable `<a>` |
| Date badge overlaid on image | `.date-badge` text below image |

### 3.3 CTA Section
| Before | After |
|--------|-------|
| Icon circles + shadow cards + gold border-t-4 | Two text panels with `gap-px` hairline divider |
| `hover:shadow-2xl hover:scale-110` | `hover:bg-white` background change only |

### 3.4 Partners Strip
- `opacity-60` → `opacity-40`, remove `hover:grayscale-0` (permanently muted)
- Add small uppercase label "Nossos Parceiros"

---

## Phase 4: Internal Pages

### 4.1 Unified Page Header
Replace all dark hero sections with a consistent light pattern:
```
pt-32 pb-16 bg-white border-b border-gwm-gray/30
  → eyebrow (bronze uppercase) + h1 (serif, gwm-dark)
```
Applies to: QuemSomos, News/Index, Concessionarias, Parceiros.

### 4.2 QuemSomos (`Views/Home/QuemSomos.cshtml`)
- **History:** Remove decorative rotated gold bg, shadows, hover transforms. Simple 2-col grid with more whitespace (`gap-24`)
- **Mission/Vision/Values:** Remove icon circles, shadow cards, gold borders. Use `gap-px` hairline divider grid
- **Leadership:** Remove card containers and decorative gold circles. Just `grayscale` photo + name + title, no wrapper

### 4.3 Contact (`Views/Home/Contact.cshtml`)
- Left panel: `bg-gwm-dark` → `bg-gwm-charcoal`, remove decorative blur circles, more padding
- Heading: Remove `border-l-4 border-gwm-gold`, remove gold span color
- Icons: Simpler `bg-white/10 rounded-full`, remove gold hover swap
- Social: Outline circles instead of gold gradient circles
- Map: Keep permanently grayscale, remove `hover:grayscale-0`

### 4.4 News Index (`Views/News/Index.cshtml`)
- **Featured:** Remove gradient overlay on image. Image above, text below (clean separation). `aspect-[21/9]` cinematic crop
- **Grid:** Same borderless card pattern as homepage
- **Pagination:** Text-only with `border-b-2` active indicator (no rounded buttons)

### 4.5 News Details (`Views/News/Details.cshtml`)
- **Layout:** Remove 12-col sidebar grid → single-column centered `max-w-4xl`
- **Share buttons:** Remove brand-colored circles → neutral outline circles
- **Recent news:** Move from sidebar to "Mais Noticias" section at bottom (3-col grid)

### 4.6 Concessionarias (`Views/Concessionarias/Index.cshtml`)
- Remove icon circles, shadow cards, gold borders, hover transforms
- `gap-px` grid with just name (serif) + city (small gray) per cell

### 4.7 Parceiros (`Views/Parceiros/Index.cshtml`)
- Add unified page header for consistency
- Remove heavy borders, shadows, `hover:-translate-y`
- Gold section: `border border-gwm-gray/40` cards, no shadows
- Silver/Bronze: same simplification with decreasing size

---

## Phase 5: Design System (`Views/DesignSystem/Index.cshtml`)
- Update font labels to Instrument Serif + Inter
- Add 3 new color swatches (electric, gray, charcoal)
- Update button styles to flat pattern
- Update card variations to borderless/hairline patterns
- Add sections for spacing guidelines and page header pattern

---

## Phase 6: JS & Performance

### `wwwroot/js/site.js`
- Optional scroll-aware navbar (add `shadow-sm` on scroll, border at top)
- Smoother mobile menu animation with max-height transition

### Cleanup
- Delete `wwwroot/lib/bootstrap/`, `jquery/`, `jquery-validation/` directories (confirmed unused)
- Consider SVGO optimization for the 51KB SVG logo

---

## Implementation Order

1. `input.css` — foundation (colors, fonts, base rules)
2. `_Layout.cshtml` — global shell (head, nav, footer)
3. `site.css` — gut legacy CSS
4. `Home/Index.cshtml` — homepage validates the new direction
5. `News/Index.cshtml` + `News/Details.cshtml` — editorial core
6. `Home/QuemSomos.cshtml` — apply same patterns
7. `Home/Contact.cshtml` — minor refinements
8. `Concessionarias/Index.cshtml` — quick win
9. `Parceiros/Index.cshtml` — quick win
10. `DesignSystem/Index.cshtml` — document everything
11. Cleanup (delete unused files)

---

## Before → After Summary

| Element | Before | After |
|---------|--------|-------|
| Heading font | Unna serif (bold) | Instrument Serif (normal weight) |
| Body font | Lato sans | Inter |
| Nav | Dark with blur + shadow | White with thin gray border |
| Section spacing | `py-16`/`py-20` | `py-24` consistently |
| Cards | `rounded-xl shadow-lg border-t-4 hover:shadow-2xl` | Borderless or `border border-gwm-gray/30`, no shadow |
| Image hover | `scale-110` | `scale-[1.03]` |
| Buttons | Gold gradient, rounded, shadow, `hover:scale-105` | Flat `bg-gwm-dark` or `border`, no radius |
| Dividers | Gold gradient bar `w-24 h-1` | `border-t border-gwm-gray/30` |
| Footer | Dark, 3-col, gold headings, circle icons | Charcoal, 4-col, text-only social |
| Page heroes | Dark bg, gradient overlay, white text | White bg, serif heading, bronze eyebrow |

## Verification
- Run `npm start` (tailwind watch + dotnet watch)
- Check every page visually in browser
- Test responsive behavior (mobile menu, grid breakpoints)
- Verify SVG logo renders correctly in nav and footer
- Confirm no broken icon references after BI → FA swap