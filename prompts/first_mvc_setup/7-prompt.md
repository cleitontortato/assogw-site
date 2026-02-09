Act as a Senior .NET Developer. I am refactoring the "Associados" section to "Concessionárias" (Dealerships).

**Goal:** Create a page that lists GWM dealerships reading data from a local JSON file.

**Data Source (Raw Text to JSON):**
I have a raw list of dealerships. You must convert the text below into a clean JSON file.
*Raw Data:*
[PASTE THE RAW TEXT LIST OF DEALERSHIPS HERE - TORIBA, DAHRUJ, ETC]

**Tasks & Outputs (Separate Code Blocks):**

1.  `wwwroot/assets/concessionarias.json`:
    -   Parse the raw text into a valid JSON array.
    -   Schema: `[ { "Name": "string", "Address": "string", "City": "string", "State": "string", "Zip": "string", "Phone": "string", "Whatsapp": "string" } ]`.
    -   *Note:* The raw address format is usually "STREET, NUMBER, - NEIGHBORHOOD, CITY/STATE, ZIP". Parse this intelligently to separate City/State/Zip.

2.  `Models/DealershipModel.cs`:
    -   A simple C# class matching the JSON schema.

3.  `Controllers/ConcessionariasController.cs`:
    -   Action `Index()`.
    -   Use `System.IO.File.ReadAllText` and `System.Text.Json.JsonSerializer` to read `wwwroot/assets/concessionarias.json`.
    -   Return the `List<DealershipModel>` to the View.
    -   Handle potential file not found errors gracefully.

4.  `Views/Concessionarias/Index.cshtml`:
    -   **Layout:**
        -   Header: "Rede de Concessionárias" with a search bar input (id="searchDealer") to filter by City or Name via JavaScript.
        -   Grid: Responsive (3 columns).
    -   **Card Design (IMPORTANT - NO IMAGES):**
        -   Since we don't have photos, create a "Typographic Card" style.
        -   Header of the card: Solid Dark Blue background (#00447F) with the Dealership Name in White.
        -   Body: Clean white background.
        -   Display Address neatly.
        -   **Action Buttons:** Two full-width buttons at the bottom:
            -   "Ligar" (Outline Gold) links to `tel:...`
            -   "WhatsApp" (Solid Green or Gold) links to `https://wa.me/...`
    -   **JavaScript:** Include a simple script at the bottom of the view to filter the cards based on the search input in real-time.

**Design Context:** Keep using the established Premium Automotive palette defined in `site.css`.