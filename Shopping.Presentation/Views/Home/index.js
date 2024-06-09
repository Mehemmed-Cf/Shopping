
//#region Nivo Poinst

const Nivo_Points = document.querySelectorAll("#Nivo_Point");
const Nivo_Point_First = document.querySelector(".First_Nivo_Point");
const Nivo_Point_Second = document.querySelector(".Second_Nivo_Point");
const Bigon_Monitor = document.querySelector(".Bigon_Monitor");
const Bigon_SmartWatch = document.querySelector(".Bigon_SmartWatch");

Nivo_Point_First.classList.add("Active");

Nivo_Point_Second.addEventListener("click" , (e) => {
    e.stopPropagation();

    Nivo_Point_First.classList.remove("Active");
    Nivo_Point_Second.classList.add("Active");

    Bigon_SmartWatch.style.opacity = "1";
    Bigon_Monitor.style.opacity = "0";
})

Nivo_Point_First.addEventListener("click" , (e) => {
    e.stopPropagation();

    Nivo_Point_Second.classList.remove("Active");
    Nivo_Point_First.classList.add("Active");

    Bigon_Monitor.style.opacity = "1";
    Bigon_SmartWatch.style.opacity = "0";
})

//#endregion

//#region List-Elements-2

const Owl_Outer_2 = document.querySelector(".Owl_Stage_Outer_2"); 
const Owl_Stages_List_2 = Owl_Outer_2.querySelectorAll(".Owl_Stage_3")

const List_Element_4 = document.querySelector("#List_element_4");
const List_Element_5 = document.querySelector("#List_element_5");

List_Element_5.addEventListener("click" , () => {
  List_Element_4.classList.remove("Active-List");
  List_Element_5.classList.add("Active-List");

  Owl_Stages_List_2[0].classList.remove("Active-Stage");
  Owl_Stages_List_2[1].classList.add("Active-Stage");
});

List_Element_4.addEventListener("click" , () => {
  List_Element_5.classList.remove("Active-List");
  List_Element_4.classList.add("Active-List");

  Owl_Stages_List_2[1].classList.remove("Active-Stage");

  Owl_Stages_List_2[0].classList.add("Active-Stage");
});

//#endregion

//#region List-Elemnents-3

const Owl_Outer_3 = document.querySelector(".Owl_Stage_Outer_3"); 
const Owl_Stages_List_3 = Owl_Outer_3.querySelectorAll(".Owl_Stage_4")

const List_Element_6 = document.querySelector("#List_element_6");
const List_Element_7 = document.querySelector("#List_element_7");
const List_Element_8 = document.querySelector("#List_element_8");

List_Element_7.addEventListener("click" , () => {

  List_Element_6.classList.remove("Active-List");
  List_Element_8.classList.remove("Active-List");

  List_Element_7.classList.add("Active-List");
  
  Owl_Stages_List_3[0].classList.remove("Active-Stage");
  Owl_Stages_List_3[2].classList.remove("Active-Stage");

  Owl_Stages_List_3[1].classList.add("Active-Stage");
});

List_Element_8.addEventListener("click" , () => {

  List_Element_6.classList.remove("Active-List");
  List_Element_7.classList.remove("Active-List");

  List_Element_8.classList.add("Active-List");

  Owl_Stages_List_3[0].classList.remove("Active-Stage");
  Owl_Stages_List_3[1].classList.remove("Active-Stage");

  Owl_Stages_List_3[2].classList.add("Active-Stage");
});

List_Element_6.addEventListener("click" , () => {

  List_Element_7.classList.remove("Active-List");
  List_Element_8.classList.remove("Active-List");

  List_Element_6.classList.add("Active-List");

  Owl_Stages_List_3[0].classList.add("Active-Stage");

  Owl_Stages_List_3[1].classList.remove("Active-Stage");
  Owl_Stages_List_3[2].classList.remove("Active-Stage");
});

//#endregion

//#region  Ancle-1

const Owl_Items = document.querySelectorAll("#Owl_Item");
const OnSale_Items = document.querySelectorAll("#OnSale_Item");
const AnclePrev = document.querySelector(".Owl-Prev");
const AncleNext = document.querySelector(".Owl-Next");
const Owl_Stage = document.querySelector(".Owl_Stage");
const OnSale_Stage = document.getElementById("OnSale-Stage");
let activeIndex = 0;

AncleNext.addEventListener("click" , () => {
    if (Owl_Stage.classList.contains("Active-Stage") && activeIndex < Owl_Items.length - 5) {
    Owl_Stage.style.animation = "slideInFromRight 1s";
    Owl_Stage.addEventListener("animationend", () => {
        Owl_Stage.style.animation = ""; // Reset animation
    }, { once: true });
    Owl_Items[activeIndex].classList.remove("Owl_Active");
    activeIndex++;
    Owl_Items[activeIndex + 4].classList.add("Owl_Active");
    Owl_Stage.style.animation = "slideInFromRight 1s";
  }
  
    if (OnSale_Stage.classList.contains("Active-Stage")) {
    OnSale_Stage.style.animation = "slideInFromRight 1s";
    OnSale_Stage.addEventListener("animationend", () => {
        OnSale_Stage.style.animation = ""; // Reset animation
    }, { once: true });
    OnSale_Items[activeIndex].classList.remove("Owl_Active");
    activeIndex++;
    OnSale_Items[activeIndex + 4].classList.add("Owl_Active");
    OnSale_Stage.style.animation = "slideInFromRight 1s";
  }
})

AnclePrev.addEventListener("click", () => {
  if (activeIndex > 0) {
    Owl_Stage.style.animation = "slideInFromRight 1s";
    Owl_Stage.addEventListener("animationend", () => {
      Owl_Stage.style.animation = ""; // Reset animation
    }, { once: true });
    Owl_Items[activeIndex + 4].classList.remove("Owl_Active");
    activeIndex--;
    Owl_Stage.style.animation = "slideOutToLeft 1s";
    Owl_Items[activeIndex].classList.add("Owl_Active");
  }
});

//#endregion

//#region List-Elements-1

const Owl_Outer_1 = document.querySelector(".Owl_Stage_Outer_1"); 
const Owl_Stages_List = Owl_Outer_1.querySelectorAll(".Owl_Stage");

const List_Element_1 = document.querySelector("#List_element_1");
const List_Element_2 = document.querySelector("#List_element_2");
const List_Element_3 = document.querySelector("#List_element_3");

List_Element_2.addEventListener("click" , () => {

    List_Element_3.classList.remove("Active-List");
    List_Element_1.classList.remove("Active-List");

    List_Element_2.classList.add("Active-List");
    
    Owl_Stages_List[0].classList.remove("Active-Stage");
    Owl_Stages_List[2].classList.remove("Active-Stage");

    Owl_Stages_List[1].classList.add("Active-Stage");
});

List_Element_3.addEventListener("click" , () => {

    List_Element_1.classList.remove("Active-List");
    List_Element_2.classList.remove("Active-List");

    List_Element_3.classList.add("Active-List");

    Owl_Stages_List[0].classList.remove("Active-Stage");
    Owl_Stages_List[1].classList.remove("Active-Stage");

    Owl_Stages_List[2].classList.add("Active-Stage");
});

List_Element_1.addEventListener("click" , () => {

    List_Element_2.classList.remove("Active-List");
    List_Element_3.classList.remove("Active-List");

    List_Element_1.classList.add("Active-List");

    Owl_Stages_List[0].classList.add("Active-Stage");

    Owl_Stages_List[1].classList.remove("Active-Stage");
    Owl_Stages_List[2].classList.remove("Active-Stage");
});

//#endregion

//#region Ancle-2

const Owl_Items_2 = document.querySelectorAll("#Owl_Item_2");
const AnclePrev_2 = document.querySelector(".Owl-Prev_2");
const AncleNext_2 = document.querySelector(".Owl-Next_2");
const Owl_Stage_2 = document.querySelector(".Owl_Stage_2");
let activeIndex_2 = 0;

AncleNext_2.addEventListener("click", () => {
    if (activeIndex_2 < Owl_Items_2.length) {
      Owl_Stage_2.style.animation = "slideInFromRight 1s";
      Owl_Stage_2.addEventListener("animationend", () => {
        Owl_Stage_2.style.animation = ""; // Reset animation
      }, { once: true });
      Owl_Items_2[activeIndex_2].classList.remove("Owl_Active");
      activeIndex_2++;
      Owl_Items_2[activeIndex_2].classList.add("Owl_Active");
      Owl_Stage_2.style.animation = "slideInFromRight 1s";
    }
  });
  
AnclePrev_2.addEventListener("click", () => {
  if (activeIndex_2 > 0) {
    Owl_Stage_2.style.animation = "slideInFromRight 1s";
    Owl_Stage_2.addEventListener("animationend", () => {
      Owl_Stage_2.style.animation = ""; // Reset animation
    }, { once: true });
    Owl_Items_2[activeIndex_2].classList.remove("Owl_Active");
    activeIndex_2--;
    Owl_Stage_2.style.animation = "slideOutToLeft 1s";
    Owl_Items_2[activeIndex_2].classList.add("Owl_Active");
  }
});

//#endregion

//#region Ancle-3

const Owl_Items_3 = document.querySelectorAll("#Owl_Item_3");
const AnclePrev_3 = document.querySelector(".Owl-Prev_3");
const AncleNext_3 = document.querySelector(".Owl-Next_3");
const Owl_Stage_3 = document.querySelector(".Owl_Stage_3.Active-Stage");
let activeIndex_3 = 0;

AncleNext_3.addEventListener("click", () => {
    if (activeIndex_3 < Owl_Items_3.length) {
      Owl_Stage_3.style.animation = "slideInFromRight 1s";
      Owl_Stage_3.addEventListener("animationend", () => {
        Owl_Stage_3.style.animation = ""; // Reset animation
      }, { once: true });
      Owl_Items_3[activeIndex_3].classList.remove("Owl_Active");
      activeIndex_3++;
      Owl_Items_3[activeIndex_3 + 2].classList.add("Owl_Active");
      Owl_Stage_3.style.animation = "slideInFromRight 1s";
    }
  });
  
AnclePrev_3.addEventListener("click", () => {
  if (activeIndex_3 > 0) {
    Owl_Stage_3.style.animation = "slideInFromRight 1s";
    Owl_Stage_3.addEventListener("animationend", () => {
      Owl_Stage_3.style.animation = ""; // Reset animation
    }, { once: true });
    Owl_Items_3[activeIndex_3 + 2].classList.remove("Owl_Active");
    activeIndex_3--;
    Owl_Stage_3.style.animation = "slideOutToLeft 1s";
    Owl_Items_3[activeIndex_3].classList.add("Owl_Active");
  }
});

//#endregion

//#region Ancle-4

const Owl_Items_4 = document.querySelectorAll("#Owl_Item_4");
const AnclePrev_4 = document.querySelector(".Owl-Prev_4");
const AncleNext_4 = document.querySelector(".Owl-Next_4");
const Owl_Stage_4 = document.querySelector(".Owl_Stage_4.Active-Stage");
let activeIndex_4 = 0;

AncleNext_4.addEventListener("click", () => {
    if (activeIndex_4 < Owl_Items_4.length - 5) {
      Owl_Stage_4.style.animation = "slideInFromRight 1s";
      Owl_Stage_4.addEventListener("animationend", () => {
        Owl_Stage_4.style.animation = ""; // Reset animation
      }, { once: true });
      Owl_Items_4[activeIndex_4].classList.remove("Owl_Active");
      activeIndex_4++;
      Owl_Items_4[activeIndex_4 + 4].classList.add("Owl_Active");
      Owl_Stage_4.style.animation = "slideInFromRight 1s";
    }
  });
  
AnclePrev_4.addEventListener("click", () => {
  if (activeIndex_4 > 0) {
    Owl_Stage_4.style.animation = "slideInFromRight 1s";
    Owl_Stage_4.addEventListener("animationend", () => {
      Owl_Stage_4.style.animation = ""; // Reset animation
    }, { once: true });
    Owl_Items_4[activeIndex_4 + 4].classList.remove("Owl_Active");
    activeIndex_4--;
    Owl_Stage_4.style.animation = "slideOutToLeft 1s";
    Owl_Items_4[activeIndex_4].classList.add("Owl_Active");
  }
});

//#endregion

//#region Ancle 5 

// const Testimonial_Img = document.querySelectorAll("#testimonial_img");
// const Img = Testimonial_Img.querySelector("img"); 
// const AnclePrev_5 = document.querySelector(".Owl-Prev_5");
// const AncleNext_5 = document.querySelector(".Owl-Next_5");
// const Slick_Track = document.querySelector("Slick-Track");
// let activeIndex_5 = 0;

// if(Img.classList.contains("Active-Testimonial")) {
//   Img.style.opacity = "1";
// }

// AncleNext_5.addEventListener("click", () => {
//     Slick_Track
//   });
  
// AnclePrev_4.addEventListener("click", () => {
//   if (activeIndex_4 > 0) {
//     Owl_Stage_4.style.animation = "slideInFromRight 1s";
//     Owl_Stage_4.addEventListener("animationend", () => {
//       Owl_Stage_4.style.animation = ""; // Reset animation
//     }, { once: true });
//     Owl_Items_4[activeIndex_4 + 4].classList.remove("Owl_Active");
//     activeIndex_4--;
//     Owl_Stage_4.style.animation = "slideOutToLeft 1s";
//     Owl_Items_4[activeIndex_4].classList.add("Owl_Active");
//   }
// });

//#endregion

//#region Single-Products

const Single_Products = document.querySelectorAll(".Single-Product");

Single_Products.forEach(item => {
const AddToCart_Btn = item.querySelector(".Add-To-Cart");
const add_to_wishlist = item.querySelector("#add-to-wishlist");
const quickview = item.querySelector("#quickview");
const Product_Content = item.querySelector(".Product-Content");
const Price = item.querySelector("p");

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
});

//#endregion


//#region Swipper

// import Swiper JS
// import Swiper from '../../../node_modules/swiper/swiper-bundle.min.mjs';
// // import Swiper styles
// import '../../../node_modules/swiper/swiper-bundle.min.mjs';

// const swiper = new Swiper('.swiper', {
//   // Optional parameters

//   // If we need pagination
//   pagination: {
//     el: '.swiper-pagination',
//   },

//   // Navigation arrows
//   navigation: {
//     nextEl: '.swiper-button-next',
//     prevEl: '.swiper-button-prev',
//   },

//   // And if we need scrollbar
//   scrollbar: {
//     el: '.swiper-scrollbar',
//   },
// });

//#endregion