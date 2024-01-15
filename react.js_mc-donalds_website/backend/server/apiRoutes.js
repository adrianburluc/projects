const express = require("express");
const categories = require('./data/categories.js').options;
const { addItemTocart, updateQuantity, cartItems } = require("./tools");

const app = express();
app.use(express.json());

app.get("/categories", (req, res) => {
    res.json({ categories });
});

app.get("/categories/:categoryId", (req, res) => {
    const { categoryId } = req.params;

    const category = categories.find(cat => cat.id == categoryId);

    res.json({ data: category.data.options });
});

app.get("/cart", (req, res) => {
    res.json({ cartItems });
});

app.delete('/cart', (req, res) => {
    cartItems.length = 0;

    categories.forEach(category => {
        category.data.options.forEach(item => {
            item.quantity = 0;
        });
    });

    res.json({ success: true, message: 'Cart emptied successfully', cartItems: [] });
});

app.put('/categories/:categoryId/:itemId/updateQuantity', (req, res) => {
    const { categoryId, itemId } = req.params;
    const { quantity } = req.body;

    const category = categories.find(cat => cat.id == categoryId);

    const updatedItem = updateQuantity(quantity, category, itemId);
    addItemTocart(updatedItem);

    res.json({ success: true, message: 'Quantity updated successfully', updatedItem: updatedItem, updatedcart: cartItems });
});

module.exports = app;
