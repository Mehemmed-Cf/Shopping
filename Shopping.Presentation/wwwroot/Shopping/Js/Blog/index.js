IBlogPostRepository blogPostRepository;

//#region Change Page

const List_Prev = document.querySelector(".List-Prev");
const List_Next = document.querySelector(".List-Next");
const list_inline = document.querySelector("#list-inline");
const List_Elements = list_inline.querySelectorAll("li");
const Col_Content = document.querySelector(".Col-Content");
const Rows = Col_Content.querySelectorAll(".Row");

console.log(Col_Content);
console.log(Rows[0]);
console.log(Rows[1]);

List_Next.addEventListener("click", () => {
    List_Elements[0].classList.remove("Active-List");
    List_Elements[1].classList.add("Active-List");

    List_Prev.classList.remove("Disable-Ancle");
    List_Next.classList.add("Disable-Ancle");

    Rows[0].classList.remove("Active-Row");
    Rows[1].classList.add("Active-Row");
});

List_Elements[1].addEventListener("click", () => {
    List_Elements[0].classList.remove("Active-List");
    List_Elements[1].classList.add("Active-List");

    List_Prev.classList.remove("Disable-Ancle");
    List_Next.classList.add("Disable-Ancle");

    Rows[0].classList.remove("Active-Row");
    Rows[1].classList.add("Active-Row");
});

List_Elements[0].addEventListener("click" , () => {
    List_Elements[1].classList.remove("Active-List");
    List_Elements[0].classList.add("Active-List");

    List_Next.classList.remove("Disable-Ancle");
    List_Prev.classList.add("Disable-Ancle");

    Rows[1].classList.remove("Active-Row");
    Rows[0].classList.add("Active-Row");
});

List_Prev.addEventListener("click", () => {
    List_Elements[1].classList.remove("Active-List");
    List_Elements[0].classList.add("Active-List");

    List_Next.classList.remove("Disable-Ancle");
    List_Prev.classList.add("Disable-Ancle");

    Rows[1].classList.remove("Active-Row");
    Rows[0].classList.add("Active-Row");
})

//#endregion


//#region  Fill Blogs


//#endregion