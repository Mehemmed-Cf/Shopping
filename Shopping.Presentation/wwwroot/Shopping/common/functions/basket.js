const basket = document.querySelector("#Basket");
const basketBadge = basket.querySelector("span");
const basketBtns = document.querySelectorAll(".Add-To-Cart");
const Like = document.querySelector("#Liked");
let count = 0;

basketBtns.forEach(btn => {
    btn.addEventListener("click", (e) => {
        e.stopPropagation();

        count++
    })
    fillBasketBadge(count);
});

function fillBasketBadge(count) {
    basketBadge.textContent = count;
  }




