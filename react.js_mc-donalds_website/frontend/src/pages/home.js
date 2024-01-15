import React from "react";
import { Link } from "react-router-dom";
import "./styles/Home.css";

var currentTimestamp = Date.now();
const Home = () =>
{
    return (
        <Link to={`/order?startTime=${currentTimestamp}`} style={{ textDecoration: 'none', color: 'inherit' }}>
            <div className="home">
                <div class="container">
                    <div style={{ fontSize: '60px' }}>ORDER</div>
                    <div style={{ fontSize: '80px', fontWeight: 'bolder' }}>HERE</div>
                    <img src={require("./images/mainMenu-0.png")} />
                    <div class="footer-home">
                        TOUCH TO START
                    </div>
                </div>
            </div>
        </Link>
    );
};


export default Home;