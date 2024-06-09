const FooterLinks = document.querySelectorAll('a');
FooterLinks.forEach(link => {
    link.addEventListener("mouseover", () => {
        link.style.color = "#4380DB";
    });
});

FooterLinks.forEach(link => {
    link.addEventListener("mouseout", () => {
        link.style.color = "white";
    });
});
