const imageLoader = document.getElementById("image_loader")
const canvas = document.getElementById("canvas")
const ctx = canvas.getContext('2d')
const saveButton = document.getElementById("save-button")
const newButton = document.getElementById("new-button")
let currentImage = null


function drawCheckerboard() {
    canvas.style.backgroundImage = "url(images/png_bg.jpg)"
}

function SetCanvasOptions() {
    canvas.classList.add("canvas-shadow")
    canvas.style.position = "absolute"
    canvas.style.top = "50%"
    canvas.style.left = "50%"
    canvas.style.transform = "translate(-50%, -50%)"
}

const LoadImage = () => {
    const file = event.target.files[0]
    const reader = new FileReader()
    reader.onload = (event) => {
        const img = new Image()
        img.src = reader.result
        img.onload = () => {
            canvas.width = img.width
            canvas.height = img.height
            if (file.type === 'image/png') {
                ctx.save()
                drawCheckerboard()
                ctx.globalCompositeOperation = 'destination-over'
                ctx.restore()
            }

            SetCanvasOptions()

            ctx.drawImage(img, 0, 0, img.width, img.height)
        }
        currentImage = img
    }

    reader.readAsDataURL(file)

    imageLoader.value = ""
}

imageLoader.addEventListener('change', () => {
    LoadImage()
})

function SaveImage() {
    if (currentImage) {
        const link = document.createElement('a')

        link.download = `image.png`
        link.href = canvas.toDataURL()
        document.body.appendChild(link)
        link.click()
        document.body.removeChild(link)
    }
}

saveButton.addEventListener('click', SaveImage)

function CreateEmptyCanvas(event) {
    event.preventDefault()
    const width = 800
    const height = 650

    canvas.width = width
    canvas.height = height

    ctx.clearRect(0, 0, width, height)

    canvas.style.backgroundImage = "none"
    SetCanvasOptions()

    currentImage = null
}

newButton.addEventListener('click', CreateEmptyCanvas)

let isDrawing = false

canvas.addEventListener('mousedown', (event) => {
    if (event.button === 0) {
        isDrawing = true
        ctx.beginPath()
    }
});

canvas.addEventListener('mousemove', (event) => {
    if (isDrawing) {

        ctx.lineTo(event.offsetX, event.offsetY)
        ctx.stroke()
    }
});

canvas.addEventListener('mouseup', () => {
    isDrawing = false
    currentImage = canvas.toDataURL()
});

canvas.addEventListener('mouseout', () => {
    isDrawing = false
});