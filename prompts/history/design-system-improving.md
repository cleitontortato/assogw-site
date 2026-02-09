Act as a Senior UI/UX Developer using Tailwind CSS.
We need to expand the `src/Views/DesignSystem/Index.cshtml` file to include Gradients, Forms, Data Tables, and Accordions.

**Objective:**
Update the Design System page to showcase our brand gradients and premium UI components.

**Tasks & Deliverables (Output the HTML snippets to be added to the View):**

1.  **Update "Color Palette" Section - Add "Gradients" Subsection:**
    -   Create a grid showing visual swatches for:
        -   **Premium Gold:** `bg-gradient-to-r from-gwm-gold to-gwm-bronze`.
        -   **Deep Ocean:** `bg-gradient-to-br from-gwm-blue to-gwm-dark`.
        -   **Midnight Depth:** `bg-gradient-to-b from-gwm-dark to-black`.
        -   **Soft Pearl:** `bg-gradient-to-tr from-gwm-light to-white`.

2.  **Update "Components Library" Section:**

    **A. Forms & Inputs:**
    -   Display premium-styled form elements (Lato font, rounded-md):
        -   **Input Text:** Focus state must use `focus:border-gwm-gold focus:ring-1 focus:ring-gwm-gold`.
        -   **Select Dropdown:** Clean style.
        -   **Textarea:** With `rows="4"`.
        -   **Checkbox/Radio:** Accent with `text-gwm-gold`.

    **B. Data Tables (Two Variations):**
    -   Create a "Data Display" subsection with two examples of tables.
    -   **Variation 1 (Corporate Blue):**
        -   Header: `bg-gwm-blue text-white`.
        -   Rows: White background with `hover:bg-gray-50`.
        -   Border: Subtle `border-gray-200`.
    -   **Variation 2 (Premium Gold):**
        -   Header: `bg-gradient-to-r from-gwm-gold to-gwm-bronze text-white`.
        -   Rows: White background.
        -   **Feature:** Add a gold bottom border to each row (`border-b border-gwm-gold/20`).

    **C. Accordion:**
    -   Create an example of an Accordion component (FAQ style).
    -   **Closed Item:** White bg, shadow-sm, rounded. Title in `text-gwm-dark`. Chevron icon on right.
    -   **Open Item:**
        -   Header: `text-gwm-blue font-bold`.
        -   Left Border: Add a vertical accent bar `border-l-4 border-gwm-gold`.
        -   Content: `p-4 text-gray-600` visible below.

**Output:**
Provide the HTML code blocks for these sections so I can paste them into the `DesignSystem/Index.cshtml`.