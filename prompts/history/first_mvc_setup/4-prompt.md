
Act as a Senior .NET Developer. Based on the "ASSOGW" ASP.NET Core MVC project, I need to implement the News (Notícias) section.

**Design Context:**
- Continue using the "Premium Automotive" style (#00447F Blue, #C6B18A Gold).
- The layout should look like a high-end corporate blog or press room.

**Tasks:**

1.  **Create the News Page (`Views/News/Index.cshtml`):**
    -   **Internal Hero:** Clean header with title "Notícias e Comunicados".
    -   **Search/Filter Bar:** A sleek input field to search news (visual only).
    -   **News Grid:** A responsive grid (3 columns on desktop) displaying news cards.
    -   **Card Style:** Image on top, Date badge (gold), Title (dark blue), Excerpt, and a "Ler Mais" link.
    -   **Pagination:** A simple pagination component at the bottom.

2.  **Update the Home Page (`Views/Home/Index.cshtml` snippet):**
    -   Provide the HTML snippet to add a "Ver Todas as Notícias" button immediately after the existing news section on the home page.
    -   This button should be styled as a secondary outline button (Gold border, transparent background) and link to the new News page.

**Output the following in separate code blocks:**

1.  `C# Controller & Model`:
    -   Create a simple `NewsItem` class (Model).
    -   Create a `NewsController` with an `Index` action that returns a list of dummy news data to the view.

2.  `Views/News/Index.cshtml`:
    -   The complete Razor view iterating over the Model.

3.  `Home Button Snippet`:
    -   Just the HTML/Razor code for the "Ver Todas" button to be pasted into the Home View.