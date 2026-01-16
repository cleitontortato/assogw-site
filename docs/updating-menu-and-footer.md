Act as a .NET Front-end Developer. Update `src/Views/Shared/_Layout.cshtml`.

**Task:** Add the new "Parceiros" link to the Navigation Bar and Footer.

1.  **Navbar:**
    -   Insert a new link: `<a asp-controller="Parceiros" asp-action="Index" ...>Parceiros</a>`.
    -   Position it immediately after the "Concessionárias" (or "Associados") link.
    -   Ensure it uses the same Tailwind classes as the adjacent links (hover effects, colors).

2.  **Footer:**
    -   Add the same link (`Parceiros`) to the "Links Rápidos" (Quick Links) column.
    -   Maintain the existing list styling.

**Output:** Provide **only** the updated `src/Views/Shared/_Layout.cshtml` code (or the relevant sections if you prefer not to print the whole file).