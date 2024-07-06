
//#region Single-Products

const Single_Products = document.querySelectorAll(".Single-Product");

Single_Products.forEach(item => {
    const AddToCart_Btn = item.querySelector(".Add-To-Cart");
    const add_to_wishlist = item.querySelector("#add-to-wishlist");
    const quickview = item.querySelector("#quickview");
    const Product_Content = item.querySelector(".Product-Content");
    const Price = item.querySelector("p");
    let IsClicked = false;

    if (screen.width > 1000) {

        item.addEventListener("mouseover", () => {
            Product_Content.style.transform = "translateY(-20px)";

            Price.style.opacity = 0;

            AddToCart_Btn.classList.add("Appear");
            add_to_wishlist.classList.add("Appear");
            quickview.classList.add("Appear");
        });

        item.addEventListener("mouseout", () => {
            Product_Content.style.transform = "translateY(0px)"
            Price.style.opacity = 1;

            AddToCart_Btn.classList.remove("Appear");
            add_to_wishlist.classList.remove("Appear");
            quickview.classList.remove("Appear");
        });

    } else if (screen.width <= 991) {

        item.addEventListener("click", () => {
            IsClicked = !IsClicked;

            AddToCart_Btn.classList.add("Appear");
            add_to_wishlist.classList.add("Appear");
            quickview.classList.add("Appear");
        });

        item.addEventListener("mouseout", () => {
            AddToCart_Btn.classList.remove("Appear");
            add_to_wishlist.classList.remove("Appear");
            quickview.classList.remove("Appear");
        });

    } else if (screen.width <= 762)

        item.addEventListener("mouseover", () => {
            AddToCart_Btn.classList.add("Appear");
            add_to_wishlist.classList.add("Appear");
            quickview.classList.add("Appear");

            Price.style.opacity = 1;
        });

    item.addEventListener("mouseout", () => {
        AddToCart_Btn.classList.remove("Appear");
        add_to_wishlist.classList.remove("Appear");
        quickview.classList.remove("Appear");
    });

});

//#endregion


