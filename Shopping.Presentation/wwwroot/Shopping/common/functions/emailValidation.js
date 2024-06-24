EmailValidation();

function EmailValidation() {
  const EMAIL_REGEX =
    /[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?/i;

    const emailInput = document.querySelector("#Email-Subscribe");
    const errorMessage = document.querySelector("#subscribe-error-message");
    const Submit_Btn = document.querySelector("#submit-subscription");
    // const Submit_Form = document.querySelector(".Subscribe-Form");

    emailInput.addEventListener("keyup", () => {
      const email = emailInput.value.trim();

      if (email === "") {
        errorMessage.classList.remove("True");
        errorMessage.classList.add("False");
        errorMessage.textContent = `You have an invisible email? That's cool`;
        return;
      }

      if (!EMAIL_REGEX.test(email)) {
        errorMessage.classList.remove("True");
        errorMessage.classList.add("False");

        if (!/@/.test(email)) {
          errorMessage.textContent = "Email should contain an @ symbol.";
        } else if (email.includes(" ")) {
          errorMessage.textContent = "Email cannot contain spaces.";
        } else if (!/[a-zA-Z]/.test(email)) {
          errorMessage.textContent = "Email should contain letters.";
        }

        errorMessage.textContent = "Please enter a valid email address.";
      } else {
        errorMessage.classList.remove("False");
        errorMessage.classList.add("True");
        errorMessage.textContent = "Email perfection! You must have a black belt in typing (unless you are a robot) ;)";
      }
    });

    Submit_Btn.addEventListener("click", () => {
      if (errorMessage.classList.contains("True")) {
        Toastify({
          text: "We will sell your info to Mark Zuckerberg ;)",
          duration: 3000,
          close: true,
          gravity: "top",
          position: "right",
          stopOnFocus: true,
          style: {
            background: "green",
          },
        }).showToast();
      } else {
        Toastify({
          text: "Wrong Email Format ;(",
          duration: 3000,
          close: true,
          gravity: "top",
          position: "right",
          stopOnFocus: true,
          style: {
            background: "red",
          },
        }).showToast();
      }
    });

    document.addEventListener("click", (e) => {
      e.stopPropagation();

      errorMessage.textContent = "";
    });
}