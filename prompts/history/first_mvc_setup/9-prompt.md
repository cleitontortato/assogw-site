Act as a UI/UX Front-end Developer. Update the CSS in `site.css` to refine the "Gold" elements, making them look more modern and premium using gradients.

**Color References (from palette):**
- Gold Light: #C6B18A
- Gold Dark: #9E8A64

**Tasks (CSS Snippet):**

1.  **Refine `.btn-gold`:**
    -   Instead of a solid color, use a `linear-gradient(135deg, #C6B18A, #9E8A64)`.
    -   Add a subtle `box-shadow` to give it depth.
    -   Text color should be White or very dark blue (#0B1A2B) depending on contrast (White usually looks more premium on gold gradients).
    -   **Hover State:** Reverse the gradient or slightly darken the filter/brightness to create an interactive "shine" effect.
    -   Remove default borders.

2.  **Refine Social Icons (Contact Page):**
    -   Create a class like `.social-icon-wrapper`.
    -   Make them circular (50% border-radius).
    -   Apply the same Gold Gradient background.
    -   Center the icon (white color) inside.
    -   Add a transition transform to scale up slightly on hover.

**Output:**
Provide only the updated CSS block for `site.css` to replace the old gold styles.