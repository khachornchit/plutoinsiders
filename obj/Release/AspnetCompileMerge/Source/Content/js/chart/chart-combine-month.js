var YMIN = 2;
var YMAX = 22;

function getDisplayDate(controller) {
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "/Home/MaxDisplayDateLastMonth", false);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
    return JSON.parse(xhttp.responseText);
}

function getAverageData(controller) {
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", "/" + controller + "/AverageDataLastMonth", false);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
    return JSON.parse(xhttp.responseText);
}

var DisplayDate = getDisplayDate();
var BuyWriteData = getAverageData("BuyWrite");
var TaxableBondData = getAverageData("TaxableBond");
var TaxFreeBondData = getAverageData("TaxFreeBond");
var ForeignData = getAverageData("Foreign");
var EquityData = getAverageData("Equity");

var config = {
    type: 'line',
    data: {
        labels: DisplayDate,
        datasets: [{
            label: "Buy-Write Sub-Index",
            data: BuyWriteData,
            backgroundColor: window.chartColors.red,
            borderColor: window.chartColors.red,
            fill: false,
            borderDash: [0, 0],
            pointRadius: 0,
            pointHoverRadius: 5,
        }, {
            label: "Taxable Bond Sub-Index",
            data: TaxableBondData,
            backgroundColor: window.chartColors.blue,
            borderColor: window.chartColors.blue,
            fill: false,
            borderDash: [0, 0],
            pointRadius: 0,
            pointHoverRadius: 5,
        }, {
            label: "Tax-Free Bond Sub-Index",
            data: TaxFreeBondData,
            backgroundColor: window.chartColors.yellow,
            borderColor: window.chartColors.yellow,
            fill: false,
            borderDash: [0, 0],
            pointRadius: 0,
            pointHoverRadius: 5,
        }, {
            label: "Foreign Sub-Index",
            data: ForeignData,
            backgroundColor: window.chartColors.green,
            borderColor: window.chartColors.green,
            fill: false,
            borderDash: [0, 0],
            pointRadius: 0,
            pointHoverRadius: 5,
        }, {
            label: "Equity Sub-Index",
            data: EquityData,
            backgroundColor: window.chartColors.purple,
            borderColor: window.chartColors.purple,
            fill: false,
            borderDash: [0, 0],
            pointRadius: 0,
            pointHoverRadius: 5,
        }]
    },
    options: {
        responsive: true,
        legend: {
            display: true,
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