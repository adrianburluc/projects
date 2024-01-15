import React, { useState, useEffect } from "react";
import Popup from 'reactjs-popup';
import 'reactjs-popup/dist/index.css';
import "./styles/Order.css";
import { Link } from "react-router-dom";
import Scroll from "./../components/scroll.js";
import { useParams } from 'react-router-dom';
import { useRef } from 'react';
import moment from 'moment'

function Order()
{
    const [menuOptions, setMenuOptions] = React.useState(null);
    const [selectedCategory, setSelectedCategory] = useState(null);
    const [isLoadingCategory, setIsLoadingCategory] = useState(false);
    const [products, setProducts] = useState({ data: [] });
    const [err, setErr] = useState('');
    const [selectedProduct, setSelectedProduct] = useState(null);
    const [finishOrder, setfinishOrder] = useState(false);
    const [cancelOrder, setCancelOrder] = useState(false);
    const [isLoadingcart, setIsLoadingcart] = useState(false);
    const [cartItems, setcartItems] = useState([]);
    const [startTimeInt, setStartTimeInt] = useState(false);
    // var startTimeInt = null;
    React.useEffect(() =>
    {
        fetch("/categories")
            .then((res) => res.json())
            .then((data) => setMenuOptions(data.categories));
        getCart();
        setStartTimeInt(Date.now());
    }, []);

    // MEASURING THE TIME
    var currentURL = window.location.href;
    // var startTimeInt = parseInt(currentURL.substring(currentURL.indexOf("startTime") + 10));
    var startTimeStamp = moment(startTimeInt);

    const formatMilliseconds = (milliseconds) =>
    {
        // Use moment's duration to get minutes, seconds, and milliseconds
        const duration = moment.duration(milliseconds);

        // Extract components of the duration
        const minutes = Math.floor(duration.asMinutes());
        const seconds = Math.floor(duration.asSeconds()) % 60;
        const remainingMilliseconds = duration.milliseconds();

        // Build the formatted string
        const formattedString = `(${minutes} minutes, ${seconds} seconds, and ${remainingMilliseconds} milliseconds)`;

        return formattedString;
    };

    const handleSetEndTimeStamp = () =>
    {
        var endTimeStamp = Date.now();

        var formattedString = `endTime=${endTimeStamp}`;

        endTimeStamp = moment(Date.now());
        var miliseconds = endTimeStamp.diff(startTimeStamp);
        var elapsedTime = formatMilliseconds(miliseconds);

        formattedString = formattedString + `&elapsedTime=${miliseconds}`

        return formattedString;
    };

    // REST OF THE CODE
    const [startIndexCategory, setStartIndexCategory] = useState(0); // State to track number of products to display
    const [endIndexCategory, setEndIndexCategory] = useState(3); // State to track number of products to display

    const nextCategoriesClick = () =>
    {
        setStartIndexCategory(startIndexCategory => startIndexCategory + 3);
        setEndIndexCategory(endIndexCategory => endIndexCategory + 3);
    };

    const prevCategoriesClick = () =>
    {
        if (startIndexCategory > 0)
        {
            setStartIndexCategory(startIndexCategory => startIndexCategory - 3);
            setEndIndexCategory(endIndexCategory => endIndexCategory - 3);
        }
    };

    const [categoriesCount, setCategoriesCount] = useState(0);

    const renderCategories = () =>
    {
        return (
            <div className="categories-menu" >
                <div className="category-nav-container zoom-hover" onClick={prevCategoriesClick}>
                    {startIndexCategory > 0 && (
                        <button className="nav-button">▲</button>
                    )}
                </div>
                <div className="categories-container-2">
                    <div class="categories-alignment-2">
                        {!menuOptions ? "Loading..." : menuOptions.slice(startIndexCategory, endIndexCategory).map((category, index) =>
                            <div class="category-info-alignment-2 zoom-hover" key={index}>
                                <div className="category-info-2"
                                    // onClick={() => getProducts(category)}>
                                    onClick={() => getProducts(category)}>
                                    <div class="category-image-2">
                                        <img src={require(`${category.image}`)} alt={category.label} />
                                    </div>
                                    <span class="category-label-2">{category.label}</span>
                                </div>
                            </div>
                        )}
                    </div>
                </div>
                <div className="category-nav-container zoom-hover" onClick={nextCategoriesClick}>
                    {menuOptions && endIndexCategory < menuOptions.length &&
                        <button className="nav-button">▼</button>
                    }
                </div>
            </div >
        );
    };

    const [indexRange, setIndexRange] = useState({ start: 0, end: 6 });
    const navNextProducts = () =>
    {
        setIndexRange(nextRange => ({
            start: nextRange.start + 6,
            end: nextRange.end + 6
        }));
    };

    const navPrevProducts = () =>
    {
        setIndexRange(prevRange => ({
            start: prevRange.start - 6,
            end: prevRange.end - 6
        }));
    };

    const resetNavProducts = () =>
    {
        setIndexRange(range => ({
            start: 0,
            end: 6
        }))
    };

    const renderProducts = () =>
    {
        return (
            <div className="products-container">
                <div class="products-header">{selectedCategory && selectedCategory.label}</div>
                <div class="products-menu">
                    <div class="products-nav-container">
                        <div class="test-5">
                            {(indexRange.end > products.data.length && products.data.length > 6) &&
                                <div class="products-nav-hitbox zoom-hover" onClick={navPrevProducts}>
                                    <button class="nav-button">◀</button>
                                </div>
                            }
                        </div>
                    </div>
                    <div class="products-alignment">
                        <div class="products-row">
                            {
                                // products.data.slice(indexStart, indexEnd).map(product => (
                                products.data.slice(indexRange.start, indexRange.end).map(product => (
                                    <div class="product-info zoom-hover" key={product.id}
                                        onClick={() => setSelectedProduct(product)}>
                                        <div class="product-info-alignment">
                                            <div class="product-image">
                                                <img
                                                    src={require(`${product.image}`)}
                                                    alt={product.label}
                                                />
                                            </div>
                                            <div class="product-label">
                                                <div>{product.label}</div>
                                                <div>{product.price}</div>
                                            </div>
                                        </div>
                                    </div>
                                ))
                            }
                        </div >
                    </div >
                    <div class="products-nav-container">
                        <div class="test-5">
                            {indexRange.end < products.data.length &&
                                <div class="products-nav-hitbox zoom-hover" onClick={navNextProducts}>
                                    <button class="nav-button">▶</button>
                                </div>
                            }
                        </div>
                    </div>
                </div>
            </div>
        );
    };

    const renderConfirmOrder = () =>
    {
        return cartItems.map((item, index) => (
            <div key={index} className="confirm-product-container zoom-hover"
                onClick={() =>
                {
                    updateQuantity(item.categoryId, item.id, item.quantity - 1);
                }}>
                <img
                    className="confirm-image-container"
                    src={require(`${item.image}`)}
                    alt={item.label}
                />
                <div className="confirm-product-text-container">
                    <div>
                        <b>{item.quantity}x {item.label}</b>
                    </div>
                    {/* <div>Quantity: </div> */}
                    <div>${(parseFloat(item.price.replace('$', '')) * item.quantity).toFixed(2)}</div>
                </div>
            </div>
        ));
    };

    //UTILS FUNCTIONS
    const calculateTotalPrice = () =>
    {
        let totalPrice = 0;
        cartItems.forEach(item =>
        {
            totalPrice += parseFloat(item.price.replace('$', '')) * item.quantity;
        });
        return totalPrice.toFixed(2);
    };


    // API FUNCTIONS
    const getProducts = async (category) =>
    {
        setIsLoadingCategory(true);
        setSelectedCategory(category);
        try
        {
            const response = await fetch(`/categories/${category.id}`, {
                method: 'GET',
                headers: {
                    Accept: 'application/json',
                },
            });

            if (!response.ok)
            {
                throw new Error(`Error! status: ${response.status}`);
            }

            const result = await response.json();

            setProducts(result);
            // categoryProductsDict[category] = products;

            resetNavProducts();
        } catch (err)
        {
            setErr(err.message);
        } finally
        {
            setIsLoadingCategory(false);
        }
    }

    const updateQuantity = async (categoryId, productId, quantity) =>
    {
        try
        {
            const response = await fetch(`/categories/${categoryId}/${productId}/updateQuantity`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ categoryId, productId, quantity }),
            });

            if (!response.ok)
            {
                throw new Error('Network response was not ok.');
            }
            getProducts(selectedCategory)
            getCart();
        } catch (error)
        {
            console.error('There was a problem with the fetch operation:', error);
        }

    };

    const getCart = async () =>
    {
        setIsLoadingcart(true);

        try
        {
            const response = await fetch('/cart');
            if (!response.ok)
            {
                throw new Error('Network response was not ok.');
            }

            const cartData = await response.json();
            setcartItems(cartData.cartItems);

        } catch (error)
        {
            console.error('There was a problem fetching cart items:', error);
        } finally
        {
            setIsLoadingcart(false);
        }
    };

    const emptyCart = async () =>
    {
        try
        {
            const response = await fetch('/cart', {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json'
                }
            });

            if (!response.ok)
            {
                throw new Error('Failed to empty cart');
            }

            const data = await response.json();
            console.log(data);

        } catch (error)
        {
            console.error('Error emptying cart:', error);
        }

        getCart();
        getProducts(selectedCategory);

    };

    const myvar = null;


    return (
        < div className="page-layout">
            {renderCategories()}
            < div className="page-content" >
                {renderProducts()}
                < div ><Popup class="popup"
                    open={selectedProduct !== null}

                    onClose={() => setSelectedProduct(null)}
                    contentStyle={{
                        borderRadius: '8px',
                        border: 'none'
                    }}>
                    {selectedProduct && (
                        <div className="popup-layout">
                            <div class="popup-alignment">
                                <span style={{ fontSize: '35px' }}>
                                    <b>{selectedProduct.label}</b>
                                </span>
                                <img
                                    className="image-popup"
                                    src={require(`${selectedProduct.image}`)}
                                />
                                <div className="popup-buttons">
                                    <button
                                        style={{ width: '70%', backgroundColor: '#FF0000' }}
                                        className="button-popup zoom-hover"
                                        onClick={() => setSelectedProduct(null)}
                                    >
                                        Cancel
                                    </button>
                                    <button
                                        style={{ width: '70%', backgroundColor: '#459C2F' }}
                                        className="button-popup zoom-hover"
                                        onClick={() =>
                                        {
                                            updateQuantity(selectedProduct.categoryId, selectedProduct.id, selectedProduct.quantity + 1)
                                            setSelectedProduct(null)
                                        }}
                                    >
                                        Add to cart
                                    </button>
                                </div>
                            </div>
                        </div>
                    )}
                </Popup>
                    <Popup
                        open={finishOrder == true}
                        onClose={() => setfinishOrder(false)}
                        contentStyle={{
                            borderRadius: '8px',
                            // padding: '20px',
                            // border: 'none',
                            // height: '90vh',
                            display: 'flex',
                            flexDirection: 'column',
                        }}
                    >
                        <div className="confirm-popup-container">
                            <div class="confirm-popup-alignment">
                                <div className="confirm-popup-header">
                                    <span style={{ fontSize: '35px' }}>
                                        <b>Confirm Order</b>
                                    </span>

                                </div>
                                <div className="confirm-popup-content">
                                    {renderConfirmOrder()}
                                </div>

                                <div className="confirm-popup-footer">
                                    <div className="confirm-price">Total price: {calculateTotalPrice()}</div>
                                </div>
                            </div>
                            <div class="popup-buttons p-b-ajust">
                                <button
                                    onClick={() => setfinishOrder(false)}
                                    className="button-popup zoom-hover"
                                    style={{ backgroundColor: '#FF0000', color: '#FFFFFF', fontSize: '20px' }}
                                >
                                    BACK
                                </button>
                                <Link to={`/end?startTime=${startTimeInt}&${handleSetEndTimeStamp()}`}
                                    style={{ width: '100%' }}
                                >
                                    <button
                                        className="button-popup zoom-hover"
                                        style={{ backgroundColor: '#459C2F', color: '#FFFFFF', fontSize: '20px' }}
                                    >
                                        CONFIRM
                                    </button>
                                </Link>
                            </div>
                        </div>
                    </Popup>
                    <Popup
                        open={cancelOrder == true}
                        onClose={() => setCancelOrder(false)}
                        contentStyle={{
                            borderRadius: '8px',
                            border: 'none',
                            display: 'flex',
                            flexDirection: 'column',
                            justifyContent: 'center'
                        }}
                    >
                        <div style={{ fontSize: '40px', padding: '20px', alignSelf: 'center', marginBottom: '60px' }}>
                            Are you sure to cancel the order?
                        </div>
                        <div class="popup-buttons">
                            <button
                                style={{ backgroundColor: '#FF0000' }}
                                className="button-popup zoom-hover"
                                onClick={() => setCancelOrder(false)}
                            >
                                Cancel
                            </button>
                            <button
                                style={{ backgroundColor: '#459C2F' }}
                                className="button-popup zoom-hover"
                                onClick={() =>
                                {
                                    emptyCart()
                                    setCancelOrder(false)
                                }}
                            >
                                Empty Cart
                            </button>
                        </div>
                    </Popup></div >
                <div className="footer">
                    <span style={{ fontSize: '25px' }}>Total: €{calculateTotalPrice()}</span>
                    <div className="test-3">
                        <button className="order-button zoom-hover"
                            style={{ backgroundColor: '#FFFFFF', color: '#FF0000', fontSize: '25px' }}
                            onClick={() => setCancelOrder(true)}>Cancel Order</button>
                        <button className="order-button zoom-hover"
                            style={{ backgroundColor: '#459C2F', color: '#FFFFFF', fontSize: '25px' }}
                            onClick={() => setfinishOrder(true)}>Confirm Order</button>
                    </div>
                </div>
            </div >
        </div >
    );

}

export default Order;