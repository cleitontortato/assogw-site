Act as a UI/UX Developer and .NET Expert. I need the "Contact" page (`Contato`) for the ASSOGW project.

**Design Concept:**
Use a "Split Layout" design often found in luxury brands:
- **Left Column (Info):** Dark background (`#0B1A2B`), White text. Contains the contact details and social icons.
- **Right Column (Map):** A responsive Google Maps embed that fills the height of the section.

**Requirements:**

1.  **Controller (`HomeController.cs` or `ContatoController.cs`):**
    -   Add a simple `Contact()` action that returns the view.

2.  **View (`Views/Home/Contact.cshtml`):**
    -   **Layout:** A Bootstrap `row` where the left column is `col-lg-5` (Info) and right is `col-lg-7` (Map).
    -   **Contact Details:**
        -   Display Address, Phone, and Email vertically using icons (FontAwesome or Bootstrap Icons).
        -   *Address:* "Av. Europa, 68 - Jardim Europa, São Paulo - SP" (Placeholder).
        -   *Phone:* "(11) 4003-7213".
        -   *Email:* "contato@assogw.com.br".
    -   **Social Media:**
        -   A section labeled "Siga-nos".
        -   Icons for **LinkedIn**, **Instagram**, and **Facebook**.
        -   Style: Large icons, Gold color (`#C6B18A`), changing to White on hover.
    -   **Google Maps:**
        -   Embed a standard Google Maps iframe (pointing to Jardim Europa, SP as a placeholder).
        -   Apply a CSS filter to the map (grayscale: 100%) to make it match the monochromatic luxury theme (optional but recommended in the CSS).

3.  **CSS (`site.css`):**
    -   `.contact-panel`: Dark background, generous padding (p-5).
    -   `.contact-icon`: Gold color, font-size 1.5rem.
    -   `.map-container`: Ensure the iframe takes 100% height and min-height of 500px.

**Output the following in separate code blocks:**
1.  `C# Controller Action`.
2.  `Views/Home/Contact.cshtml`.
3.  `CSS Snippet`.