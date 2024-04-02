const imageLoader = document.getElementById("image_loader")
const canvas = document.getElementById("canvas")
const ctx = canvas.getContext('2d')
let offsetX, offsetY = 0
let isDragging = false

canvas.onmousedown = function(event) {
    if (event.button === 0) {
        isDragging = true
        offsetX = event.clientX - canvas.getBoundingClientRect().left
        offsetY = event.clientY - canvas.getBoundingClientRect().top
        canvas.style.position = 'absolute'

        MoveTo(event.pageX, event.pageY)
        function MoveTo(x, y) {
            canvas.style.left = x - offsetX + 'px'
            canvas.style.top = y - offsetY + 'px'
        }

        function OnMouseMove(event) {
            MoveTo(event.pageX, event.pageY)
        }

        document.addEventListener('mousemove', OnMouseMove)

        function RemoveMouseMove() {
            document.removeEventListener('mousemove', OnMouseMove)
            canvas.onmouseup = null
        }

        function StopMove() {
            document.removeEventListener('mousemove', OnMouseMove)
            canvas.onmouseup = null
        }

        canvas.onmouseup = StopMove

        document.onmouseleave = StopMove

        window.onblur = StopMove
    }
}

function drawCheckerboard() {
    canvas.style.backgroundImage = "url(images/png_bg.jpg)"
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
                ctx.save();
                drawCheckerboard();
                ctx.globalCompositeOperation = 'destination-over';
                ctx.restore();
            }
            ctx.drawImage(img, 0, 0, img.width, img.height)
        }
    }
    reader.readAsDataURL(event.target.files[0]);
}

imageLoader.addEventListener('change', () => {
    LoadImage()
})