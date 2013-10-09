var divNavigation = d3.select(".navigation");

var svgcanvas = divNavigation.append("svg:svg")
    .attr("width", "100%")
    .attr("height", "100%")
    .attr("id", "maisondulechat");

d3.select("#maisondulechat").append("circle").attr("r", 150).attr("transform", "translate(300,300)");

function polarToCartesian(centerX, centerY, radius, angleInDegrees) {
    var angleInRadians = (angleInDegrees - 90) * Math.PI / 180.0;

    return {
        x: centerX + (radius * Math.cos(angleInRadians)),
        y: centerY + (radius * Math.sin(angleInRadians))
    };
}

function describeArc(x, y, radius, startAngle, endAngle) {

    var start = polarToCartesian(x, y, radius, endAngle);
    var end = polarToCartesian(x, y, radius, startAngle);

    var arcSweep = endAngle - startAngle <= 180 ? "0" : "1";

    var d = [
        "M", start.x, start.y,
        "A", radius, radius, 0, arcSweep, 0, end.x, end.y
    ].join(" ");

    return d;
}

d3.select("#maisondulechat").append("path").attr("id", "arc1").attr("stroke", "#446688").attr("stroke-width", "20");


document.getElementById("arc1").setAttribute("d", describeArc(300, 300, 150, 0, 180));

d3.select("#maisondulechat").append("text").append("textPath").attr("xlink:href", "#arc1").text("Last night she said");