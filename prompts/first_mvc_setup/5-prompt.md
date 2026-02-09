Act as a UI/UX Front-end Developer refining the ASP.NET Core MVC project.

The current implementation of the News Cards (in `Views/News/Index.cshtml` and Home) has insufficient spacing; content is touching the edges.

**Task:** Refine the aesthetics of the news cards to look more premium and readable.

**Specific Requirements:**
1.  **Rounded Corners:** Apply subtle rounded corners to the card container and the image itself (e.g., Bootstrap's `rounded-3` or similar custom CSS).
2.  **Internal Spacing (Padding):** Add significant padding inside the card body so the title, date, and excerpt have "breathing room" and don't touch the borders.
3.  **Subtle Border:** Add a very light, sophisticated border (e.g., a light gray `#e5e7eb` or a very faint version of the primary blue) to define the card area without being harsh.

**Output the following in separate code blocks:**

1.  `CSS Update (site.css)`:
    - Provide a custom CSS class (e.g., `.premium-news-card`) that handles the subtle border, border-radius, and ensures the hover effect is still elegant.

2.  `HTML Snippet Example (Razor View)`:
    - Show the updated HTML structure for a single card column, demonstrating where to apply the new custom class and Bootstrap padding utility classes (like `.p-4`) to achieve the desired spacing.