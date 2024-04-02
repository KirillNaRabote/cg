let svg = document.getElementById('house')
let offsetX, offsetY = 0
let isDragging = false

svg.addEventListener('mousedown', (event) => {
    if (event.button === 0) {
        isDragging = true
        offsetX = event.clientX - svg.getBoundingClientRect().left
        offsetY = event.clientY - svg.getBoundingClientRect().top
    }
})

svg.addEventListener('mousemove', (event) => {
    if (isDragging) {
        let newX = event.clientX - offsetX
        let newY = event.clientY - offsetY

        svg.style.left = newX + 'px'
        svg.style.top = newY + 'px'
    }
})

svg.addEventListener('mouseup', (event) => {
    isDragging = false
})