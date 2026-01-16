Atue como um Arquiteto de Software Sênior especialista em .NET 8 e Front-end.
Preciso que você crie o código front-end para um projeto ASP.NET Core MVC.

Contexto:
O site é para a "ASSOGW" (Associação de Concessionárias GWM Brasil).
O estilo deve ser "Automotive Premium", minimalista e sofisticado.

Stack Tecnológica:
- ASP.NET Core MVC (.NET 8)
- Razor Views (.cshtml)
- Framework CSS: Bootstrap 5 (via CDN) + CSS Customizado para o visual premium.
- Ícones: FontAwesome ou Bootstrap Icons.

Paleta de Cores Obrigatória (CSS Variables):
- --primary-blue: #00447F (GWM Blue)
- --primary-gold: #C6B18A (Premium Accent)
- --secondary-gold: #9E8A64 (Darker Gold for hover)
- --dark-bg: #0B1A2B (Midnight Blue - Header/Footer)
- --light-bg: #F7F6F3 (Off-white - Body background)

Entregáveis:

1. Código do `Views/Shared/_Layout.cshtml`:
   - Navbar fixa com efeito "Glass" ou fundo --dark-bg.
   - Links: Home, Quem Somos, Notícias, Associados, Contato.
   - Botão "Área do Associado" (Outline Dourado) na direita.
   - Footer estruturado com 3 colunas.

2. Código do `Views/Home/Index.cshtml`:
   - Hero Section: Full-width, imagem de fundo (placeholder), Título "Unindo Forças, Conduzindo o Futuro", Subtítulo e CTA.
   - Seção de Notícias: Grid com 3 cards (use Cards do Bootstrap mas remova as bordas padrão para ficar clean).
   - Seção de Parceiros: Faixa simples para logos.

3. CSS Customizado (`wwwroot/css/site.css`):
   - Implemente as classes para sobrescrever o visual padrão do Bootstrap.
   - Use fontes modernas (Montserrat ou Inter).
   - Botões com transições suaves e raios de borda refinados (não totalmente redondos, nem quadrados).

Gere o código completo e limpo, pronto para colar no Visual Studio.