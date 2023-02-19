// button click event show update time by second
let updateDisplay;
let count = 1;
const display_background = {
    color1: "#434247",
    color2: "#5c5a66",
    color3: "#febc68",
    color4: "#fcdb8c",
    color5: "#1f9589",
    color6: "#41c0b5",
    color7: "#faa41b",
    color8: "#cc222b",
}
const display_color = {
    color1: "#A8E10C",
    color2: "#8A6FDF",
    color3: "#FF5765",
    color4: "#FA26A0",
    color5: "#01DEE6",
    color6: "#3D91E0",
    color7: "#44EE77",
    color8: "#4DB3E4",
}
const display = () => {
    self.onmessage = (event) => {
        postMessage(post())
        let display_button_clicked = event.data;
        if (!display_button_clicked) {
            clearInterval(updateDisplay);
        }
        else {
            console.log("enter!")
            let dt = new Date();
            updateDisplay = setInterval(() => {
                count++;
                if (count > 8) {
                    count = 1;
                }
                post();
            }, 1000);
        }
    }
}

display();
function post() {
    dt = new Date();
    postMessage(
        {
            "date": dt,
            "background": display_background["color" + count.toString()],
            "color": display_color["color" + count.toString()],
            "style": "font-size: 20px;position: fixed;top: 0%;right: 0%; "
        }
    );
}

