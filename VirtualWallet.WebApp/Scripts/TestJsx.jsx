import React from 'react';
import ReactDOM from 'react-dom';
import {constString, displayNumber} from '../Scripts/Utils.js'

class TestJsx extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            counter: 0
        };
    }

    incrementCounter = () => {
        let {counter} = this.state;
        counter = counter + 1;
        this.setState({ counter });
    }

    render() {

        const { counter } = this.state;

        return (
            <div>
                <h1>Test jsx {constString}</h1>
                <h2>Counter: {counter} and from utils {displayNumber(99)}</h2>
                <input type="button" onClick={this.incrementCounter} value="Increment" />
            </div>
        );
    }
}

ReactDOM.render(<TestJsx />, document.getElementById("root"));