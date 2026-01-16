Act as a Senior .NET Developer and SEO Specialist.
I need to implement the "News Details" (Single Post) page for the ASSOGW ASP.NET Core MVC project.

**Context:**
- Use the established "Premium Automotive" design system.
- The page must be responsive with a 2-column layout: Main Content (Left/Center) and Sidebar (Right).

**Requirements:**

1.  **Controller (`NewsController.cs`):**
    -   Add a `Details(int id)` action.
    -   It should create a dummy `NewsItem` object with rich content (Title, Author, Date, Body, ImageUrl) to serve as the template data.
    -   It should also generate a list of 3 "Recent News" items for the sidebar.

2.  **View (`Views/News/Details.cshtml`):**
    -   **Layout:** Use a Bootstrap Row. `col-lg-8` for the Article, `col-lg-4` for the Sidebar.
    -   **SEO & Taxonomy:** Use semantic HTML5 tags: `<article>`, `<header>`, `<h1>` for title, `<time>` for date, and `<address>` for author.
    -   **Meta Tags (SEO/Social):** Use a `section` or generic HTML block to define Open Graph (`og:title`, `og:image`, `og:description`) and Twitter Card tags. These are crucial for WhatsApp/LinkedIn previews.
    -   **Article Body:** Styled with comfortable typography (inter-line spacing) for reading.
    -   **Share Buttons:** A section at the bottom of the article with buttons for WhatsApp, LinkedIn, Facebook, and Twitter (use FontAwesome icons and placeholder `href`s).
    -   **Sidebar:** A "Sticky" sidebar displaying "Notícias Recentes" with small thumbnails and titles.

**Output the following in separate code blocks:**

1.  `NewsController.cs (Update)`: The specific `Details` method and dummy data generation.
2.  `Views/News/Details.cshtml`: The complete Razor view with the Meta Tags section at the top and the full layout.
3.  `CSS Snippet`: Any specific styling for the `.share-buttons`, `.article-content`, or `.sidebar-news` to keep it looking premium.