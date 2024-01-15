import React, { useEffect, useRef } from "react";
import "./Scroll.css"; // Importe os estilos

const Scroll = (props) => {
    const scrollRef = useRef();

    const handleMouseMove = (e) => {
        const { top, bottom } = scrollRef.current.getBoundingClientRect();
        const mouseY = e.clientY - top;

        if (mouseY < top + (bottom - top) * 0.4) {
            scrollRef.current.scrollTop -= 10; // Scroll up
        } else if (mouseY > top + (bottom - top) * 0.6) {
            scrollRef.current.scrollTop += 10; // Scroll down
        }
    };

    useEffect(() => {
        scrollRef.current.addEventListener("mousemove", handleMouseMove);
        return () => {
            scrollRef.current.removeEventListener("mousemove", handleMouseMove);
        };
    }, []);


    return (
        <div className="Wrapper">
            <div ref={scrollRef} className="test">
                    {props.children}
            </div>
        </div>
    );
};

export default Scroll;
