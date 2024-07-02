
//#region sidebar

const Widget_List = document.querySelector(".Widget-List");
const Widget_Ul = Widget_List.querySelector("ul");


const Input_Elements = document.querySelectorAll("input[type='checkbox']");

Input_Elements.forEach(input => {

    const Active_List = document.querySelector(".Active")
    const widget = input.closest(".Widget-Collapse"); //travels the parent elements of the input seeking for the nearest ancestor with the class name
    const filterValue = widget.querySelector(".Filter-Value");
    const selectedCount = filterValue.querySelector("span");
    const resetLink = filterValue.querySelector("a");
    const Collapse_Ul = widget.querySelector("ul");

    function updateSelectedCount() {
        const checkedCount = Collapse_Ul.querySelectorAll("input[type='checkbox']:checked").length;
        selectedCount.textContent = `${checkedCount} Selected`;
    };

    Active_List.addEventListener("click", () => {
        const listItems = Widget_List.querySelectorAll("li");

        listItems.forEach(li => {
            if (!li.classList.contains("Active")) {
                li.remove();
            }
        });

        Input_Elements.forEach(input => {
            input.checked = false;
        });

        updateSelectedCount();

    });

    resetLink.addEventListener("click", () => {

        const checkboxes = Collapse_Ul.querySelectorAll("input[type='checkbox']");
        checkboxes.forEach(checkbox => {
            checkbox.checked = false;
            const filterListItem = Collapse_Ul.querySelector(`li[data-id='${checkbox.id}']`);
            if (filterListItem) {
                filterListItem.remove();
            }
        });

        const Filter_List_Item = Widget_Ul.querySelector(`li[data-id='${input.id}']`);

        if (Filter_List_Item) {
            Filter_List_Item.remove();
        }

        updateSelectedCount();
    });

    const label = document.querySelector(`label[for='${input.id}']`);

    input.addEventListener("change", () => { //Change => inout check / unceck

        if (input.checked) {

            if (label) {
                const Filter_List_Item = document.createElement("li");
                Filter_List_Item.setAttribute("data-id", input.id); // Set data-id attribute

                const Filter_Item = document.createElement("a");

                Cancel_Icon = document.createElement("img");
                Cancel_Icon.src = "../../assets/icons/CancelIcon.svg";
                Cancel_Icon.addEventListener("click", () => {
                    input.checked = false;
                    Filter_List_Item.remove();
                    updateSelectedCount();
                });

                Filter_Item.textContent = label.textContent;
                Filter_Item.append(Cancel_Icon);

                Filter_List_Item.append(Filter_Item);
                Widget_Ul.insertBefore(Filter_List_Item, Active_List);
            }

        } else {

            const Filter_List_Item = Widget_Ul.querySelector(`li[data-id='${input.id}']`);

            if (Filter_List_Item) {
                Filter_List_Item.remove();
            }

        }

        updateSelectedCount();
    });

    updateSelectedCount();
});

const Group_Titles = document.querySelectorAll(".Group-Title");

Group_Titles.forEach(Group_Title => {
    const AncleUp = Group_Title.querySelector("img");
    const Widget_Collapse = Group_Title.nextElementSibling;

    let IsCollapsed = false;

    AncleUp.addEventListener("click", () => {
        IsCollapsed = !IsCollapsed //Toggling the state

        if (IsCollapsed) {
            AncleUp.style.transform = "rotate(180deg)";
            Widget_Collapse.style.height = "0px";
        } else {
            AncleUp.style.transform = "rotate(0deg)";
            Widget_Collapse.style.height = "auto";
        }

    });
});

//#endregion

//#region Change Page

//const List_Prev = document.querySelector(".List-Prev");
//const List_Next = document.querySelector(".List-Next");
//const list_inline = document.querySelector("#list-inline");
//const List_Elements = list_inline.querySelectorAll("li");
//const Tab_Contents = document.querySelectorAll(".Tab-Content");


//List_Next.addEventListener("click", () => {
//    List_Elements[0].classList.remove("Active-List");
//    List_Elements[1].classList.add("Active-List");

//    List_Prev.classList.remove("Disable-Ancle");
//    List_Next.classList.add("Disable-Ancle");

//    Tab_Contents[0].classList.add("Deactive-Tab");
//    Tab_Contents[1].classList.remove("Deactive-Tab");
//});

//List_Elements[1].addEventListener("click", () => {
//    List_Elements[0].classList.remove("Active-List");
//    List_Elements[1].classList.add("Active-List");

//    List_Prev.classList.remove("Disable-Ancle");
//    List_Next.classList.add("Disable-Ancle");

//    Tab_Contents[0].classList.add("Deactive-Tab");
//    Tab_Contents[1].classList.remove("Deactive-Tab");
//});

//List_Elements[0].addEventListener("click", () => {
//    List_Elements[1].classList.remove("Active-List");
//    List_Elements[0].classList.add("Active-List");

//    List_Next.classList.remove("Disable-Ancle");
//    List_Prev.classList.add("Disable-Ancle");

//    Tab_Contents[1].classList.add("Deactive-Tab");
//    Tab_Contents[0].classList.remove("Deactive-Tab");
//});

//List_Prev.addEventListener("click", () => {
//    List_Elements[1].classList.remove("Active-List");
//    List_Elements[0].classList.add("Active-List");

//    List_Next.classList.remove("Disable-Ancle");
//    List_Prev.classList.add("Disable-Ancle");

//    Tab_Contents[1].classList.add("Deactive-Tab");
//    Tab_Contents[0].classList.remove("Deactive-Tab");
//})

//#endregion