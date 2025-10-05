// Cria animação de login

setTimeout(() => {
    const msg = document.getElementById("loginMessage");
    if (msg) {
        msg.style.transition = "opacity 1s ease";
        msg.style.opacity = "0";
        setTimeout(() => msg.remove(), 1000);
    }
}, 2000);

// Animação de fade in antiga

document.addEventListener("DOMContentLoaded", () => {
    const elements = document.querySelectorAll(".fade-in");

    const observer = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add("show");
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.2});

    elements.forEach(el => observer.observe(el));
});




