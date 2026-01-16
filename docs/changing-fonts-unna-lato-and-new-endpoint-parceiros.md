Act as a Senior Full-Stack Developer (.NET 8 + Tailwind CSS).

**Context:**
We are refining the visual identity of the ASSOGW project located in the `src/` directory.

**Goal:**
1.  Update the Typography to use "Unna" (Headings) and "Lato" (Body) with increased line spacing.
2.  Refine the random color logic in the Backend to match the brand palette.
3.  Create a new "Parceiros" (Partners) feature with tiered categories (Gold, Silver, Bronze).

**Tasks & Deliverables (Output in separate code blocks):**

1.  **Configuration & Typography (Separation of Concerns):**
    -   **Create `src/wwwroot/js/tailwind.config.js`:**
        -   Move all Tailwind customizations to this external file to keep the Layout clean.
        -   **Syntax Requirement:** Since we are using the Play CDN, the file content must start with `tailwind.config = { ... }` (do not use `module.exports`).
        -   **Theme Configuration:**
            -   **Colors:** Re-declare the GWM palette here (`gwm-blue`, `gwm-dark`, `gwm-gold`, `gwm-bronze`, `gwm-light`).
            -   **Fonts:** Set `fontFamily`:
                -   `serif`: `['Unna', 'serif']`
                -   `sans`: `['Lato', 'sans-serif']`
            -   **Line Height:** Extend theme with `lineHeight: { 'extra-loose': '2.0' }`.
    -   **Update `src/Views/Shared/_Layout.cshtml`:**
        -   **Google Fonts:** Add the `<link>` for **Unna** (400, 700) and **Lato** (300, 400, 700).
        -   **Scripts:**
            1.  Keep the Tailwind CDN script: `<script src="https://cdn.tailwindcss.com"></script>`.
            2.  **Immediately after it**, add the reference to your new config: `<script src="~/js/tailwind.config.js"></script>`.
            3.  Remove the old inline `<script>tailwind.config = ...</script>`.
    -   **Global Style:** On the `<body>` tag, apply `font-sans antialiased text-gray-700 leading-relaxed` to establish the new elegant typography base.
    
2.  **`src/Controllers/NewsController.cs` (Color Logic Fix):**
    -   Refactor the `_getRandomHexColor()` method.
    -   Instead of random RGB, it must return a random color **strictly** from this array:
        -   `#00447F` (Deep Blue)
        -   `#0B1A2B` (Midnight Blue)
        -   `#C6B18A` (Gold)
        -   `#9E8A64` (Bronze)
        -   `#4B5563` (Cool Gray - to balance)
    -   This ensures the placeholder cards always look cohesive.

3.  **`src/Controllers/ParceirosController.cs` (New Endpoint):**
    -   Create a `ParceirosController` with an `Index` action.
    -   Create a simple `PartnerViewModel` class inside the file (Name, LogoUrl, Url, Category).
    -   **Generate Dummy Data:**
        -   **Category Gold:** 3 items.
        -   **Category Silver:** 6 items.
        -   **Category Bronze:** 9 items.
    -   Pass this categorized data to the View.

4.  **`src/Views/Parceiros/Index.cshtml` (Tiered Layout):**
    -   **Typography:** Use `font-serif` for category titles.
    -   **Visual Hierarchy (Tiers):**
        -   **Gold Section:** Large Grid (`grid-cols-1 md:grid-cols-3`). Cards should be large, `p-8`, with a **Gold** top border (`border-t-4 border-gwm-gold`). Large text/logos.
        -   **Silver Section:** Medium Grid (`grid-cols-2 md:grid-cols-4`). Cards medium size, `p-6`, with a **Silver/Gray** top border (`border-t-4 border-gray-400`). Medium text.
        -   **Bronze Section:** Compact Grid (`grid-cols-2 md:grid-cols-6`). Cards compact, `p-4`, with a **Bronze** top border (`border-t-4 border-gwm-bronze`). Smaller text.
    -   **Card Style:** Clean white cards (`bg-white shadow-sm hover:shadow-md transition`), centered content, containing the Partner Name and a "Visitar" link.

**Constraint:** Stick to Tailwind utility classes. Ensure the line-height changes make the text feel elegant and airy.