// Scroll-aware navbar: add subtle shadow on scroll
(function () {
    const nav = document.getElementById('main-nav');
    if (!nav) return;

    let ticking = false;

    function updateNav() {
        if (window.scrollY > 10) {
            nav.classList.add('shadow-sm');
            nav.classList.remove('border-b');
        } else {
            nav.classList.remove('shadow-sm');
            nav.classList.add('border-b');
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
