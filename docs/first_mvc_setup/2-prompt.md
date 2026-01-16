Act as a Senior .NET Developer and UI/UX Designer. Generate the front-end code for an ASP.NET Core MVC (.NET 8) project for "ASSOGW" (Association of GWM Dealerships).

The design must be "Premium Automotive", minimalist, and sophisticated.
Use Bootstrap 5 (CDN) as the base framework, but heavily override it with custom CSS to achieve a unique luxury look.

**Strict Color Palette (Use these as CSS Variables):**
- Primary Dark Blue: #00447F
- Midnight Blue (Backgrounds): #0B1A2B
- Gold (Accents/Buttons): #C6B18A
- Dark Gold (Hover): #9E8A64
- Off-White (Body): #F7F6F3

**Output the following 3 files in separate code blocks:**

1.  `wwwroot/css/site.css`:
    - Define the root variables.
    - Create a custom `.btn-gold` class for premium CTAs.
    - Style the `.navbar` to be dark (#0B1A2B) with white text and gold active states.
    - Create a `.hero-section` class with a dark gradient overlay.
    - Style cards to be minimal (no borders, soft shadows).

2.  `Views/Shared/_Layout.cshtml`:
    - Standard MVC layout structure.
    - Include Bootstrap 5 via CDN in `<head>`.
    - Navbar links: Home, Quem Somos, Notícias, Associados, Contato.
    - Navbar CTA: "Área do Associado" (using the gold button style).
    - Footer: Dark background (#0B1A2B), 3 columns (Links, Contact, Copyright).

3.  `Views/Home/Index.cshtml`:
    - **Hero Section:** Full width, heavy typography, headline "Unindo Forças, Conduzindo o Futuro".
    - **News Section:** A container with a "Últimas Notícias" header and a row of 3 placeholder cards.
    - **Partners Section:** A simple gray-scale strip for logos.

Please provide only the necessary code for these files, ensuring high-quality HTML5 and semantic markup.