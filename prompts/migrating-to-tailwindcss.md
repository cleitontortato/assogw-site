Act as a Senior Front-end Developer and UI/UX Designer specializing in Tailwind CSS and ASP.NET Core.

**Context & Directory Structure:**
- The project source code is located in the `src/` directory.
- All file paths in your output must reflect this (e.g., `src/Views/Shared/_Layout.cshtml`).
- You are refactoring the project from Bootstrap 5 to **Tailwind CSS v3**.

**Objective:**
Rebuild the frontend to use Tailwind utility classes while maintaining the "Premium Automotive" aesthetic (Gold/Blue palette).

**Theme Configuration (to be used in Tailwind config):**
- Deep Blue: `#00447F` (`gwm-blue`)
- Midnight Blue: `#0B1A2B` (`gwm-dark`)
- Gold Gradient: Start `#C6B18A` (`gwm-gold`) -> End `#9E8A64` (`gwm-bronze`)
- Off-White: `#F7F6F3` (`gwm-light`)

**Tasks & Deliverables (Output in separate code blocks):**

1.  **`src/Views/Shared/_Layout.cshtml`:**
    -   Replace Bootstrap links with Tailwind CSS Play CDN script.
    -   Inside `<head>`, add the `<script>` for `tailwind.config` extending the colors with the values above.
    -   Refactor Navbar: Flexbox, sticky, glassmorphism (`bg-gwm-dark/90 backdrop-blur`), hover effects.
    -   Refactor Footer: Grid layout (`grid-cols-1 md:grid-cols-3`).

2.  **`src/Views/Home/Index.cshtml`:**
    -   **Hero:** Full screen, gradients, `text-4xl md:text-6xl`.
    -   **News:** Grid (`grid-cols-1 md:grid-cols-3 gap-8`). Cards with `rounded-xl shadow-lg`.
    -   **Buttons:** Replace old classes with `bg-gradient-to-r from-gwm-gold to-gwm-bronze text-white hover:scale-105 transition`.

3.  **`src/Views/Concessionarias/Index.cshtml`:**
    -   Grid layout (`grid-cols-1 md:grid-cols-3`).
    -   **Typographic Cards:** Header `bg-gwm-blue`, Body `bg-white`, border `border-gray-100`.
    -   **Buttons:** Full width (`w-full`), distinct styles for "Ligar" (border only) and "WhatsApp" (solid green).

4.  **`src/Views/Home/Contact.cshtml`:**
    -   **Split Layout:** `flex flex-col md:flex-row`.
    -   **Left (Info):** `bg-gwm-dark text-white p-10 md:w-5/12`.
    -   **Right (Map):** `w-full md:w-7/12`. Map iframe should have `grayscale` class.
    -   **Social Icons:** `rounded-full bg-gradient-to-br from-gwm-gold to-gwm-bronze`.

5.  **`src/Views/News/Index.cshtml`:**
    -   **News:** Grid (`grid-cols-1 md:grid-cols-3 gap-8`). Cards with `rounded-xl shadow-lg`.
    -   **Buttons:** Replace old classes with `bg-gradient-to-r from-gwm-gold to-gwm-bronze text-white hover:scale-105 transition`.

6.  **`src/Views/News/Details.cshtml`:**
    -   **Layout:** Two columns (`grid grid-cols-1 lg:grid-cols-12 gap-10`).
    -   **Main Content (Article):** Spans 8 columns (`lg:col-span-8`). Use semantic typography (H1 large, p leading-relaxed text-gray-700, blockquote with left border gold).
    -   **Sidebar:** Spans 4 columns (`lg:col-span-4`). Use `sticky top-24` so it stays visible while scrolling. Style the "Recent News" list cleanly.
    -   **Share Buttons:** Flex row with gold icons.

7.  **`src/Views/Home/About.cshtml` (Quem Somos):**
    -   **Internal Hero:** Shorter height (`h-64`), dark background with title centered.
    -   **Intro Section:** 2-column layout (Text left, Image placeholder right).
    -   **Mission/Vision Cards:** Grid (`grid-cols-1 md:grid-cols-3`). White cards, shadow-lg, border-t-4 border-gwm-gold.
    -   **Team/Board:** Grid of clean cards. Photos with `rounded-full` or `rounded-xl`, Name in `text-gwm-blue`.


**Constraint:** Use strictly Tailwind utility classes. Do not use custom CSS files. Ensure mobile responsiveness.