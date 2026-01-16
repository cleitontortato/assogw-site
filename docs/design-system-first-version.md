Act as a Senior Front-end Developer specializing in Tailwind CSS and UI Systems.

**Goal:**
Create a comprehensive **Design System / Style Guide** page for the ASSOGW project.
This page will serve as a living documentation of our visual identity (Colors, Typography, Components).

**Context:**
- Project uses **ASP.NET Core MVC**.
- Styling: **Tailwind CSS**.
- Fonts: **Unna** (Serif/Headings) and **Lato** (Sans/Body).
- Custom Colors: `gwm-blue`, `gwm-dark`, `gwm-gold`, `gwm-bronze`, `gwm-light`.

**Tasks & Deliverables (Output in separate code blocks):**

1.  **`src/Controllers/DesignSystemController.cs`:**
    -   Create a simple controller with an `Index` action returning the view.

2.  **`src/Views/DesignSystem/Index.cshtml`:**
    -   **Layout Structure:** Use a clean, single-column layout with a sticky table of contents (optional) or clear section dividers.
    -   **Sections Required:**

    **A. Typography:**
    -   Display `h1` through `h6` using the **Unna** font. Show their Tailwind class sizes (e.g., `text-5xl`).
    -   Display Body text paragraphs using **Lato**, demonstrating `leading-relaxed`.

    **B. Color Palette & Scales:**
    -   Create a grid showing our core colors (`gwm-blue`, `gwm-dark`, `gwm-gold`, `gwm-bronze`).
    -   **Crucial:** For each color, generate a "Scale Strip" using Tailwind opacity modifiers to simulate tints:
        -   100% (Base), 80%, 60%, 40%, 20%, 10%, 5%.
        -   Example class: `bg-gwm-blue/80`.
    -   Show the hex code and variable name on the card.

    **C. UI Variables (Radius & Shadows):**
    -   **Border Radius:** A row of boxes showing `rounded-sm`, `rounded-md`, `rounded-lg`, `rounded-xl`, `rounded-full`.
    -   **Shadows:** A row of white cards on a light gray bg showing `shadow-sm` up to `shadow-2xl`.

    **D. Components Library:**
    -   **Buttons:**
        -   Primary (Gold Gradient): `bg-gradient-to-r from-gwm-gold to-gwm-bronze`.
        -   Secondary (Outline): Border gold, text gold.
        -   Ghost/Text Link.
        -   Show states: Normal, Hover, Active, Disabled.
    -   **Badges:**
        -   Pill-shaped badges for status (Success/Green, Warning/Gold, Error/Red, Info/Blue).
    -   **Alerts:**
        -   Standard notification boxes (Success, Warning, Error) with icons.
    -   **Cards (Show 3 Distinct Variations):**
        1.  **News Card:** Image top, Date badge, Title, "Read More" link.
        2.  **Dealership Card (Typographic):** The style we defined earlier (White bg, Gold top border, Icon centered).
        3.  **Partner Card (Tiered):** A visual example of the Gold Tier card (Large, Gold Border).

**Design Constraint:**
-   Make the Design System page itself look premium (`bg-gwm-light`).
-   Use `container mx-auto py-12` for spacing.
-   Ensure all text uses the correct font families defined in `tailwind.config.js`.