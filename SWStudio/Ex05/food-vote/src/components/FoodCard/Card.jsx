import React from "react";
import VoteButton from "../VoteButton/Button";
import "./Style.css";
class Card extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            vote: "MIN",
        };
        // var display_vote_result = 
        console.log("Hi")
        console.log(this.props.data);
    }
    
    handleCallback = (child) => {
        if (this.state.vote === 0) {
            this.setState({ vote: "MIN" });
        }
        else if (this.state.vote === 9 && child === 1) {
            this.setState({ vote: "MAX" });
        }
        else if (this.state.vote === "MIN" && child === -1) {
            alert("You can't unvote anymore");
        }
        else if (this.state.vote === "MAX" && child === 1) {
            return alert("You can't vote anymore");
        }
        else if (this.state.vote === "MIN" && child === 1) {
            this.setState({ vote: 1 });
        }
        else if (this.state.vote === "MAX" && child === -1) {
            this.setState({ vote: 9 });
        }
        else if (this.state.vote === 1 && child === -1) {
            this.setState({ vote: "MIN" });
        }
        else{
            this.setState({ vote: this.state.vote + child });
        }
        
        
    }
    render() {
        return (
            <div className="card">
                <div className="wrapper">
                    <div className="content">
                        <h2>{this.props.data.type} </h2>
                        <p className="food-name">{this.props.data.name}</p>
                        <p>{this.props.data.description}</p>
                    </div>
                    <img src={this.props.data.image} alt="pic" />
                </div>
                <div className="vote">
                    <VoteButton title="Click to Vote" parentCallback= {this.handleCallback} value={1}/>
                    <span class="display-vote">{this.state.vote}</span>
                    <VoteButton title="Click to Unvote" parentCallback= {this.handleCallback} value = {-1}/>
                </div>
                {/* console.log(this.props.data) */}
            </div>
        );
    }
}
export default Card;