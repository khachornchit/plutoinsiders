var YMIN = 2;
var YMAX = 22;

function getDisplayDate() {
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "/TaxableBond/DisplayDateLastMonth", false);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
    return JSON.parse(xhttp.responseText);
}

function getAverageData() {
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "/TaxableBond/AverageDataLastMonth", false);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
    return JSON.parse(xhttp.responseText);
}

var config = {
    type: 'line',
    data: {
        labels: getDisplayDate(),
        datasets: [{
            label: "Taxable Bond ",
            data: getAverageData(),
            backgroundColor: window.chartColors.blue,
            borderColor: window.chartColors.blue,
            fill: false,
            borderDash: [0, 0],
            pointRadius: 0,
            pointHoverRadius: 5,
        }]
    },
    options: {
        responsive: true,
        legend: {
            display: false,
            position: 'bottom',
        },
        hover: {
            mode: 'index'
        },
        scales: {
            fontSize: 14,
            fontStyle: 'normal',
            fontFamily: 'Helvetica Neue',
            xAxes: [{
                display: true,
                scaleLabel: {
                    display: false,
                    labelString: 'Month'
                }
            }],
            yAxes: [{
                display: true,
                ticks: {
                    //min: YMIN,
                    //max: YMAX,
                    callback: function (label, index, labels) {
                        return Number(label).toFixed(1) + ' %';
                    }
                },
                scaleLabel: {
                    display: false,
                    labelString: 'Value'
                }
            }]
        },
        title: {
            display: false,
            text: ''
        }
    }
};

Chart.plugins.register({
    afterDatasetsDraw: function (chart, easing) {
        // To only draw at the end of animation, check for easing === 1
        var ctx = chart.ctx;

        chart.data.datasets.forEach(function (dataset, i) {
            var meta = chart.getDatasetMeta(i);
            if (!meta.hidden) {
                meta.data.forEach(function (element, index) {
                    if (index == dataset.data.length - 1) {
                        // Draw the text in black, with the specified font
                        ctx.fillStyle = 'rgb(0, 0, 0)';

                        var fontSize = 14;
                        var fontStyle = 'normal';
                        var fontFamily = 'Helvetica Neue';
                        ctx.font = Chart.helpers.fontString(fontSize, fontStyle, fontFamily);

                        // Just naively convert to string for now 
                        var dataString = Number(dataset.data[index].toString()).toFixed(2) + ' %';

                        // Make sure alignment settings are correct
                        ctx.textAlign = 'center';
                        ctx.textBaseline = 'middle';

                        var padding = 5;
                        var position = element.tooltipPosition();
                        ctx.fillText(dataString, position.x, position.y - (fontSize / 2) - padding);
                    }
                });
            }
        });
    }
});

window.onload = function () {
    var ctx = document.getElementById("canvas").getContext("2d");
    window.myLine = new Chart(ctx, config);
};