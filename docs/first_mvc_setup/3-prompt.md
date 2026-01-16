Act as a Senior .NET Developer. Based on the previous ASP.NET Core MVC context, generate the code for the "Quem Somos" (About Us) page.

**Requirements:**
1.  **Visual Consistency:** Must strictly follow the previously defined "Premium Automotive" design system (Colors: #0B1A2B, #C6B18A; Fonts; Bootstrap 5 classes).
2.  **Page Structure:**
    -   **Internal Hero Section:** A shorter header with the title "Quem Somos" and a subtle background.
    -   **Introduction:** A 2-column layout (Text on left, Placeholder Image on right) describing the association's goal.
    -   **Mission, Vision, Values:** A row with 3 clean cards/columns using icons.
    -   **Leadership/Board Section:** A grid displaying the board members (Name, Role, Photo Placeholder) with a minimalist style.

**Output the following in separate code blocks:**

1.  `C# Controller Snippet`:
    - The C# method to add to `HomeController.cs` (or `QuemSomosController.cs`) to render this view.

2.  `Views/Home/About.cshtml` (or `QuemSomos.cshtml`):
    - The complete Razor view code.
    - Use `<div class="container">` for alignment.
    - Use the `.text-gold` or equivalent classes for accents.
    - Ensure it uses `ViewData["Title"] = "Quem Somos";`.

3.  `CSS Additions` (optional):
    - Only if new specific classes are needed for the timeline or team cards that weren't in the main `site.css`.