const Sign_In = document.querySelector(".Sign-In");

const emailInput = document.querySelector("#customerEmail");
const passwordInput = document.querySelector("#customerPassword");

const emailErrorMessage = document.querySelector(".Email-Error-Message");
const passwordErrorMessage = document.querySelector(".Password-Error-Message");

EmailValidation();

function EmailValidation() {
  const EMAIL_REGEX =
    /[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?/i;

  emailInput.addEventListener("keyup", () => {
    const email = emailInput.value.trim();

    if (email === "") {
      emailErrorMessage.classList.remove("True");
      emailErrorMessage.classList.add("False");
      emailErrorMessage.textContent = `You have an invisible email? That's cool`;
      return;
    }

    if (!EMAIL_REGEX.test(email)) {
      emailErrorMessage.classList.remove("True");
      emailErrorMessage.classList.add("False");

      if (!/@/.test(email)) {
        emailErrorMessage.textContent = "Email should contain an @ symbol.";
      } else if (email.includes(" ")) {
        emailErrorMessage.textContent = "Email cannot contain spaces.";
      } else if (!/[a-zA-Z]/.test(email)) {
        emailErrorMessage.textContent = "Email should contain letters.";
      } else {
        emailErrorMessage.textContent = "Please enter a valid email address.";
      }
    } else {
      emailErrorMessage.classList.remove("False");
      emailErrorMessage.classList.add("True");
      emailErrorMessage.textContent = "We Will hack your Information, Thanks ;)";
    }
  });

  document.addEventListener("click", (e) => {
    e.stopPropagation();

    emailErrorMessage.textContent = "";
  });
}


async function LoginUser(email, password) {
  const response = await fetch("http://localhost:3000/api/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      email: email,
      password: password,
    }),
  });

  const data = await response.json();

  if (response.status >= 200 && response.status <= 300) {
    window.open("../Home/index.html", "_self");
  } else {
    Toastify({
      text: data.error,
      duration: 3000,
      destination: "https://github.com/apvarun/toastify-js",
      newWindow: true,
      close: true,
      gravity: "top",
      position: "right",
      stopOnFocus: true,
      style: {
        background: "red",
      },
    }).showToast();
  }
}

LoginValidation();

function LoginValidation() {
  Sign_In.addEventListener("click", () => {
    // showButtonLoader(true);

    email = emailInput.value;
    password = passwordInput.value;

    LoginUser(email, password);

    // showButtonLoader(false);
  });
}

// function showButtonLoader(show) {
//   buttonLoader.style.display = show ? "grid" : "none";
// }
