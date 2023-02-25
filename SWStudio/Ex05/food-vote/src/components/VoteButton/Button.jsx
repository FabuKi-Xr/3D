import React from 'react';
import './VoteButton.css';
class VoteButton extends React.Component {
    constructor (props) {
        super(props)
        this.value = this.props.value
    }
    
    onTrigger = () => {
        this.props.parentCallback(this.value);
    }
    render() {
        return (
            <button className='votebutt' onClick={this.onTrigger}>{this.props.title}</button>
        )
    }
}

export default VoteButton