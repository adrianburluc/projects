import React from "react";
import "./styles/Home.css";
import { useParams } from 'react-router-dom';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import moment from 'moment'

const Home = () =>
{
    var currentURL = window.location.href;
    var startTimeStamp = parseInt(currentURL.substring(currentURL.indexOf("startTime") + 10, currentURL.indexOf("&endTime")));
    var endTimeStamp = parseInt(currentURL.substring(currentURL.indexOf("&endTime") + 9, currentURL.indexOf("&elapsedTime")));
    var elapsedTime = parseInt(currentURL.substring(currentURL.indexOf("&elapsedTime") + 13));

    var endTimeStampTest = Date.now();

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

    return (
        <div className="home">
            <div class="container" style={{ height: '100%' }}>
                <div style={{ fontSize: '60px', fontWeight: 'bolder' }}>THANK YOU</div>
                <div style={{ fontSize: '42px' }}>FOR YOUR ORDER!</div>
                <img src={require("./images/mainMenu-0.png")} />
            </div>
            <div className="order-status"
                style={{ position: 'absolute', bottom: '0', right: '0', margin: '60px' }}>
                <table border="1">
                    <tr>
                        <td>Total time:</td>
                        <td>{elapsedTime} miliseconds {formatMilliseconds(elapsedTime)}</td>
                    </tr>
                    <tr>
                        <td>Start TimeStamp</td>
                        <td>{moment(startTimeStamp).format('YYYY-MM-DD HH:mm:ss')}</td>
                    </tr>
                    <tr>
                        <td>End TimeStamp</td>
                        <td>{moment(endTimeStamp).format('YYYY-MM-DD HH:mm:ss')} [../order/ (generated on Confirm Order)]<br></br>{moment(endTimeStampTest).format('YYYY-MM-DD HH:mm:ss')} [../end/ (generated on page load)]</td>
                    </tr>
                </table>
            </div>
        </div>
    );
};


export default Home;