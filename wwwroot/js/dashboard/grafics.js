/* Inspired by Lee Byron's test data generator. */
function stream_layers(n, m, o) {
    if (arguments.length < 3) o = 0;
    function bump(a) {
        var x = 1 / (.1 + Math.random()),
            y = 2 * Math.random() - .5,
            z = 10 / (.1 + Math.random());
        for (var i = 0; i < m; i++) {
            var w = (i / m - y) * z;
            a[i] += x * Math.exp(-w * w);
        }
    }
    return d3.range(n).map(function () {
        var a = [], i;
        for (i = 0; i < m; i++) a[i] = o + o * Math.random();
        for (i = 0; i < 5; i++) bump(a);
        return a.map(stream_index);
    });
}

/* Another layer generator using gamma distributions. */
function stream_waves(n, m) {
    return d3.range(n).map(function (i) {
        return d3.range(m).map(function (j) {
            var x = 20 * j / m - i / 3;
            return 2 * x * Math.exp(-.5 * x);
        }).map(stream_index);
    });
}

function stream_index(d, i) {
    return { x: i, y: Math.max(0, d) };
}


var test_data = stream_layers(3, 128, .1).map(function (data, i) {
    return {
        key: (i == 1) ? 'Non-stackable Stream' + i : 'Stream' + i,
        nonStackable: (i == 1),
        values: data
    };
});

nv.addGraph({
    generate: function () {
        var width = window.innerWidth - 50,
            height = 400;

        var chart = nv.models.multiBarChart()
            .width(width)
            .height(height)
            .stacked(true);

        chart.dispatch.on('renderEnd', function () {
            console.log('Render Complete');
        });

        var svg = d3.select('#grafic-notas svg').datum(test_data);
        console.log('calling chart');
        svg.transition().duration(0).call(chart);

        return chart;
    },
    callback: function (graph) {
        nv.utils.windowResize(function () {
            var width = nv.utils.windowSize().width;
            var height = nv.utils.windowSize().height;
            graph.width(width).height(height);

            d3.select('#grafic-notas svg')
                .attr('width', width)
                .attr('height', height)
                .transition().duration(0)
                .call(graph);

        });
    }
});





/// colunas simples
var historicalBarChart = [
    {
        key: "Cumulative Return",
        values: [
            {
                "label": "A",
                "value": 29.765957771107
            },
            {
                "label": "B",
                "value": 0
            },
            {
                "label": "C",
                "value": 32.807804682612
            },
            {
                "label": "D",
                "value": 196.45946739256
            },
            {
                "label": "E",
                "value": 0.19434030906893
            },
            {
                "label": "F",
                "value": 98.079782601442
            },
            {
                "label": "G",
                "value": 13.925743130903
            },
            {
                "label": "H",
                "value": 5.1387322875705
            }
        ]
    }
];

nv.addGraph(function () {
    var chart = nv.models.discreteBarChart()
        .x(function (d) { return d.label })
        .y(function (d) { return d.value })
        .staggerLabels(true)
        //.staggerLabels(historicalBarChart[0].values.length > 8)
        .showValues(true)
        .duration(250)
        ;

    d3.select('#grafic-falts svg')
        .datum(historicalBarChart)
        .call(chart);

    nv.utils.windowResize(chart.update);
    return chart;
});