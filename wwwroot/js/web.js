setTimeout(() => {
    const msg = document.getElementById("loginMessage");
    if (msg) {
        msg.style.transition = "opacity 1s ease";
        msg.style.opacity = "0";
        setTimeout(() => msg.remove(), 1000);
    }
}, 5000);