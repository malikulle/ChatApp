var createRoomBtn = document.getElementById("create-room-btn")
var createRoomModal = document.getElementById("create-room-modal")
var closeModalBtn = document.getElementById("close-modal-btn")


closeModalBtn.addEventListener("click", function () {
    createRoomModal.classList.remove("active")
})

createRoomBtn.addEventListener("click", function () {
    createRoomModal.classList.add("active")
})




