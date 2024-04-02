var newButton = document.getElementById("new-bt")
var imageLoader = document.getElementById("image_loader")

function openImage() {
    imageLoader.click()
}

newButton.addEventListener("click", openImage)