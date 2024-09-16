async function addBook(bookId) {
    try {
        const response = await fetch(`/Cart/AddItem?bookId=${bookId}`);
        if (response.status === 200) {
            await loadCartCount();
        }
    } catch (err) {
        console.error(err);
    }
}

async function loadCartCount() {
    try {
        const response = await fetch(`/Cart/GetCartItemCount`);
        if (response.status === 200) {
            const result = await response.json();
            const cartCountEl = document.getElementById("cartCount");
            if (cartCountEl) {
                cartCountEl.innerHTML = result;
            }
        }
    } catch (err) {
        console.error(err);
    }
}

async function increaseItem(bookId) {
    try {
        const response = await fetch(`/Cart/AddItem?bookId=${bookId}`);
        if (response.status === 200) {
            await loadCartCount();
            location.reload();
        }
    } catch (err) {
        console.error(err);
    }
}

async function decreaseItem(bookId) {
    try {
        const response = await fetch(`/Cart/DecreaseItem?bookId=${bookId}`);
        if (response.status === 200) {
            await loadCartCount();
            location.reload();
        }
    } catch (err) {
        console.error(err);
    }
}

async function removeItem(bookId) {
    try {
        const response = await fetch(`/Cart/RemoveItem?bookId=${bookId}`);
        if (response.status === 200) {
            await loadCartCount();
            location.reload();
        }
    } catch (err) {
        console.error(err);
    }
}

//document.addEventListener("DOMContentLoaded", function () {
//    loadCartCount();
//});