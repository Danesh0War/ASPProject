document.addEventListener("DOMContentLoaded", () => {
    const commentBox = document.getElementById("newcomment");
    const commentError = document.getElementById("comment-error");
    const form = document.querySelector("form");
    let isFormValid = false;
    commentBox.addEventListener("input", validateForm);

    form.addEventListener("submit", (event) => {
        validateForm();
        if (!isFormValid) {
            event.preventDefault();
        }
    });

    function validateForm() {
        if (commentBox.value.trim() === "") {
            commentError.textContent = "Please enter a comment"
            commentError.style.display = "inline";
            isFormValid = false;
        }
        else if (commentBox.value.length > 120) {
            commentError.textContent = "Comment must be under 120 characters"
            commentError.style.display = "inline";
            isFormValid = false;
        }
        else {
            commentError.style.display = "none";
            isFormValid = true;
        }
    }
});