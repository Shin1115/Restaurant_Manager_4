// document.querySelector('.img-btn').addEventListener('click', function() {
//     document.querySelector('.cont').classList.toggle('s-signup')
// });


const classForm = document.getElementById('sign-up');
const username = document.getElementById('username');
const email = document.getElementById('email2');
const password = document.getElementById('password2');
const rePassword = document.getElementById('rePassword');
classForm.addEventListener('onblur', (e) => {
    e.preventDefault();
    checkInput();
});

function checkInput() {
    const usernameValue = username.value.trim()
    const emailValue = email.value.trim()
    const passwordValue = password.value.trim()
    const rePasswordValue = rePassword.value.trim()

    if (usernameValue === '') {
        setErrorFor(username);
        //setErrorFor.classList.add('invalid');
    } else {
        setSuccessFor(username);
    }
}

function setErrorFor(inputElement) {
    const errorE = inputElement.parentElement.querySelector('.error');
    console.log(errorE)
    inputElement.className(' sign-up invalid');
}