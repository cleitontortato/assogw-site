// Scroll-aware navbar: add subtle shadow on scroll + hero-aware transparency
(function () {
    const nav = document.getElementById('main-nav');
    if (!nav) return;

    const heroCarousel = document.getElementById('hero-carousel');
    let ticking = false;

    function updateNav() {
        const scrolled = window.scrollY > 10;
        const inHeroZone = heroCarousel && window.scrollY < (heroCarousel.offsetHeight - 80);

        if (inHeroZone && !scrolled) {
            // Transparent over hero
            nav.classList.add('hero-nav');
            nav.classList.remove('shadow-sm', 'bg-white/95', 'border-b');
        } else if (scrolled) {
            nav.classList.remove('hero-nav', 'border-b');
            nav.classList.add('shadow-sm', 'bg-white/95');
        } else {
            nav.classList.remove('hero-nav', 'shadow-sm');
            nav.classList.add('border-b', 'bg-white/95');
        }
        ticking = false;
    }

    window.addEventListener('scroll', function () {
        if (!ticking) {
            requestAnimationFrame(updateNav);
            ticking = true;
        }
    });

    updateNav();
})();

// Hero Carousel
(function () {
    const carousel = document.getElementById('hero-carousel');
    if (!carousel) return;

    const slides = carousel.querySelectorAll('.hero-slide');
    const dots = carousel.querySelectorAll('.hero-dot');
    const prevBtn = document.getElementById('hero-prev');
    const nextBtn = document.getElementById('hero-next');
    const currentEl = document.getElementById('hero-current');
    const totalSlides = slides.length;

    let current = 0;
    let interval = null;
    let isTransitioning = false;

    function goTo(index) {
        if (isTransitioning || index === current) return;
        isTransitioning = true;

        slides[current].classList.remove('is-active');
        dots[current].classList.remove('is-active');

        current = ((index % totalSlides) + totalSlides) % totalSlides;

        slides[current].classList.add('is-active');
        dots[current].classList.add('is-active');

        if (currentEl) {
            currentEl.textContent = String(current + 1).padStart(2, '0');
        }

        setTimeout(function () {
            isTransitioning = false;
        }, 1000);
    }

    function next() { goTo(current + 1); }
    function prev() { goTo(current - 1); }

    function startAutoplay() {
        stopAutoplay();
        interval = setInterval(next, 6000);
    }

    function stopAutoplay() {
        if (interval) clearInterval(interval);
    }

    // Initialize first slide
    slides[0].classList.add('is-active');
    dots[0].classList.add('is-active');

    // Navigation
    if (prevBtn) prevBtn.addEventListener('click', function () { stopAutoplay(); prev(); startAutoplay(); });
    if (nextBtn) nextBtn.addEventListener('click', function () { stopAutoplay(); next(); startAutoplay(); });

    dots.forEach(function (dot) {
        dot.addEventListener('click', function () {
            stopAutoplay();
            goTo(parseInt(dot.dataset.dot, 10));
            startAutoplay();
        });
    });

    // Pause on hover
    carousel.addEventListener('mouseenter', stopAutoplay);
    carousel.addEventListener('mouseleave', startAutoplay);

    // Touch support
    let touchStartX = 0;
    carousel.addEventListener('touchstart', function (e) {
        touchStartX = e.changedTouches[0].screenX;
        stopAutoplay();
    }, { passive: true });

    carousel.addEventListener('touchend', function (e) {
        const diff = e.changedTouches[0].screenX - touchStartX;
        if (Math.abs(diff) > 50) {
            if (diff > 0) prev(); else next();
        }
        startAutoplay();
    }, { passive: true });

    // Keyboard
    document.addEventListener('keydown', function (e) {
        const rect = carousel.getBoundingClientRect();
        if (rect.bottom < 0 || rect.top > window.innerHeight) return;
        if (e.key === 'ArrowLeft') { stopAutoplay(); prev(); startAutoplay(); }
        if (e.key === 'ArrowRight') { stopAutoplay(); next(); startAutoplay(); }
    });

    startAutoplay();
})();

// Scroll-reveal: IntersectionObserver for .reveal elements
(function () {
    var els = document.querySelectorAll('.reveal');
    if (!els.length) return;

    if (window.matchMedia('(prefers-reduced-motion: reduce)').matches) {
        els.forEach(function (el) { el.classList.add('is-visible'); });
        return;
    }

    var observer = new IntersectionObserver(function (entries) {
        entries.forEach(function (entry) {
            if (entry.isIntersecting) {
                entry.target.classList.add('is-visible');
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.15 });

    els.forEach(function (el) { observer.observe(el); });
})();
