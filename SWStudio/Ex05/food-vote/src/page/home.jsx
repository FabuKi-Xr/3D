import React from "react"
import Card from "../components/FoodCard/Card"
import "./home.css"
import "../asset/global.css"
import food from "../data/food.json"
const Homepage = () => {
    var arr= [];
    Object.values(food).forEach((value) => {
        console.log(value.name);
        arr.push(value)
    });
    return (
        <div className="container">
            <header>
                <h1 className="font-config">โหวตอาหาร</h1>
            </header>
            {
                arr.map((item) => {
                    return <Card data={item} />
                })
            }
        </div>
    )
}

export default Homepage