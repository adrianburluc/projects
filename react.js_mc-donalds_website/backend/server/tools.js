
let cartItems = [];

const addItemTocart = (item) => {
    const existingItemIndex = cartItems.findIndex((existingItem) => existingItem.id === item.id && existingItem.categoryId ===item.categoryId);

    if (existingItemIndex !== -1) {
        if (item.quantity === 0) {
            cartItems.splice(existingItemIndex, 1);
        } else {
            cartItems[existingItemIndex] = item;
        }
    } else {
        if (item.quantity > 0) {
            cartItems.push(item);
        }
    }

    return cartItems;
};

const updateQuantity = (quantity, category, itemId) => {

    const itemToUpdate = category.data.options.find(item => item.id == itemId);

    if (quantity >= 0)
        itemToUpdate.quantity = quantity;
    else
        itemToUpdate.quantity = 0;

    return itemToUpdate;
};

module.exports = {
    addItemTocart,
    updateQuantity,
    cartItems
};
