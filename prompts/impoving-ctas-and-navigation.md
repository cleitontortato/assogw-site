Act as a Senior Front-end Developer (.NET 8 + Tailwind CSS).
We are polishing the "ASSOGW" project in `src/`.

**Objective:** Apply specific UI/UX refinements to fonts, layout, and logic based on user feedback.

**Tasks & Deliverables (Output in separate code blocks):**

1.  **`src/Views/Shared/_Layout.cshtml` (Global & Nav Updates):**
    -   **Typography Rule (Task #1):** Add a global style block or update the `body` class to ensure all `h1` through `h5`, buttons, and anchor tags (`a`) use `font-serif` (Unna).
    -   **Navigation (Task #3, #9):**
        -   Ensure the Logo links to `asp-action="Index" asp-controller="Home"`.
        -   **Remove** the text link "Home" from the menu.
        -   **Remove** the "Área do Associado" button completely.
    -   **Footer (Task #9, #10, #11):**
        -   Remove the "Home" link.
        -   Make Email and Phone clickable (`href="mailto:..."`, `href="tel:..."`).
        -   Add Social Media Icons (LinkedIn, Instagram, Facebook) to the footer (styled like the Contact page: Gold/White).

2.  **`src/Views/Home/Index.cshtml` (Hero & New Section):**
    -   **Hero Height (Task #8):** Reduce height from `min-h-screen` to something moderate like `h-[500px]` or `min-h-[60vh]` so the news section is visible above the fold.
    -   **New CTA Section (Task #12):** Immediately after the "Latest News" section, add a new 2-column section (`grid md:grid-cols-2 gap-8`):
        -   **Card 1:** "Conheça nossos parceiros" -> Links to `Parceiros/Index`.
        -   **Card 2:** "Nossas concessionárias associadas" -> Links to `Concessionarias/Index`.
        -   *Style:* Use the "Premium" card style (white bg, shadow, gold accent).

3.  **`src/Controllers/ConcessionariasController.cs` (Logic Update):**
    -   **Sorting (Task #4):** Ensure the `Index` action orders the list alphabetically by Name (`.OrderBy(x => x.Name)`).

4.  **`src/Views/Concessionarias/Index.cshtml` (Refine Cards):**
    -   **Remove Search (Task #4):** Delete the search bar.
    -   **Card Design (Task #2):** Refactor the loop to use a cleaner, elegant card style based on this reference:
        -   Container: `bg-white p-8 rounded-xl shadow-lg border-t-4 border-gwm-gold hover:-translate-y-2 transition-all group`.
        -   Icon: Centered circle `bg-gwm-light` with a `text-gwm-gold` icon (use `bi-shop` or similar).
        -   Content: Display **only** Name (`font-serif text-xl font-bold`) and City/State (`text-gray-600`). Hide full address/zip/phone to keep it clean.

5.  **`src/Views/News/Index.cshtml` (Featured Layout):**
    -   **Remove Search (Task #5):** Delete the search input.
    -   **Featured Logic (Task #6):**
        -   Check if `Model.Any()`.
        -   **First Item:** Render as a "Featured Hero" (Full width image, large font).
        -   **Remaining Items:** Render in the existing 3-column grid below the featured item.

6.  **`src/Views/Parceiros/Index.cshtml` (Design Polish):**
    -   **Card Design (Task #7):** Refactor to use the rounded/elegant style similar to the Dealership reference above.
        -   **Dynamic Borders:**
            -   Gold Tier: `border-gwm-gold`
            -   Silver Tier: `border-gray-400`
            -   Bronze Tier: `border-gwm-bronze`
        -   **Content:** Circle container with the Partner Logo inside. Partner Name below.
        -   **Remove Link:** Do not include the "Visitar Site" button/link.

**Constraint:** Strict adherence to Tailwind utility classes and the `font-serif` (Unna) requirement for headings and buttons.