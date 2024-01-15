import React from "react";
import {
    BrowserRouter as Router,
    Routes,
    Route,
} from "react-router-dom";

import Order from "./pages/order";
import Home from "./pages/home";
import End from "./pages/end";
import Scroll from "./components/scroll";
 
function App() {
    return (
        <Router>
            <Routes>
                <Route path="/home" element={<Home />} />
                <Route path="/order" element={<Order />} />
                <Route path="/end" element={<End />} />
            </Routes>
        </Router>
    );
}
 
export default App;