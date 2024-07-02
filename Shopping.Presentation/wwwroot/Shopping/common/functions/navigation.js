

const settings = document.querySelector("#Settings");
const ancleDown = document.querySelector("#AncleDownIcon");
const settings_bar = document.querySelector("#Settings-Bar");
const body = document.querySelector('body');
const Page_LinksAndLogo = document.querySelector(".Page-LinksAndLogo");
const SignIn_Link = document.querySelector("#SignIn-Bar");
const MyWishlist_Bar = document.querySelector("#MyWishlist-Bar");
const Bars_Link = document.querySelector(".Bars_Link");
const Links_Bar = document.querySelector("#Links-Bar");
const SearchAndBasket = document.querySelector(".SearchAndBasket");
const BasketIcon = SearchAndBasket.querySelector("#Basket");


//#region  Settings Bar

settings.addEventListener("mouseover", () => {
    settings_bar.style.opacity = "1";
    settings_bar.style.visibility = "visible";
    Page_LinksAndLogo.style.zIndex = "-5";
});

settings_bar.addEventListener("mouseover", () => {
    Page_LinksAndLogo.style.zIndex = "-5";
});

settings.addEventListener("mouseout", () => {
    settings_bar.style.opacity = "0";
    settings_bar.style.visibility = "hidden";
    Page_LinksAndLogo.style.zIndex = "5"; 
});

settings_bar.addEventListener("mouseout", () => {
    settings_bar.style.opacity = "0";
    settings_bar.style.visibility = "hidden";
    Page_LinksAndLogo.style.zIndex = "5"; 
});

//#endregion    

//#region Links Bar

let isLinksBarVisible = false;

Bars_Link.addEventListener("click", () => {
    isLinksBarVisible = !isLinksBarVisible;
    
    if (!isLinksBarVisible) {
        Links_Bar.style.opacity = "1";
        Links_Bar.style.visibility = "visible";
        Page_LinksAndLogo.style.zIndex = "-5";
        SearchAndBasket.style.zIndex = "-5";
    } else {
        Links_Bar.style.opacity = "0";
        Links_Bar.style.visibility = "hidden";
        Page_LinksAndLogo.style.zIndex = "5";
        SearchAndBasket.style.zIndex = "5";
    }
});

 Bars_Link.addEventListener("mouseout", () => {
     Links_Bar.style.opacity = "0";
     Links_Bar.style.visibility = "hidden";
     Page_LinksAndLogo.style.zIndex = "5"; 
     SearchAndBasket.style.zIndex = "5";
 });

 Links_Bar.addEventListener("mouseove", () => {
     Links_Bar.style.opacity = "1";
     Links_Bar.style.visibility = "visible";
     Page_LinksAndLogo.style.zIndex = "-5";
     SearchAndBasket.style.zIndex = "-5";
 });

 Links_Bar.addEventListener("mouseout", () => {
     Links_Bar.style.opacity = "0";
     Links_Bar.style.visibility = "hidden";
     Page_LinksAndLogo.style.zIndex = "5"; 
     SearchAndBasket.style.zIndex = "5";
 });

//#endregion

