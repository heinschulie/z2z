
//Fetch (yet to come) and draw the cat of the day on the navigation background

var divNavigation = d3.select(".navigation");

var svgcanvas = divNavigation.append("svg:svg")
    .attr("width", "100%")
    .attr("height", "100%")
    .attr("id", "maisondulechat");

var svgWidth = svgcanvas.width;
var svgHeight = svgcanvas.height;

// ********* Define events for circle pack
var hoverName = function (d, i) {
    var name = d.name;
    d3.select("label#circleName").text("" + name);
}

// Functions for drawing an arc based on a circle's data - to give text a path to sit upon 
function polarToCartesian(centerX, centerY, radius, angleInDegrees) {
    var angleInRadians = (angleInDegrees - 90) * Math.PI / 180.0;

    return {
        x: centerX + (radius * Math.cos(angleInRadians)),
        y: centerY + (radius * Math.sin(angleInRadians))
    };
}

function describeArc(x, y, r, startAngle, endAngle) {

    var start = polarToCartesian(x, y, r, endAngle);
    var end = polarToCartesian(x, y, r, startAngle);

    var arcSweep = endAngle - startAngle <= 180 ? "0" : "1";
    var d = [
        "M", start.x, start.y,
        "A", r, r, 0, arcSweep, 0, end.x, end.y
    ].join(" ");

    return d;
}

//// *********** Draw a circle-pack diagram using data given 
var width = 300,
height = 300;

//Append a group for the circle pack to the exising svg canvas
var circleGroup = svgcanvas
        .append("g")
        .attr("transform", "translate(200,20)");

//Calibrate pack layout 
var pack = d3.layout.pack()
    .size([width, height])
    .value(function (d) { return d.name.length; });

//Draw the pack layout given data from ajax call 
var drawCirclePack = function (ajaxMsg) {

    //Grey out le chat
    d3.select("#lechat")
        .transition()
        .duration(2000)
        .style("fill", "#E6E7E8");

    var data = new Object();
    data.children = ajaxMsg.d;

    // DATA JOIN
    // Join new data with old elements, if any.
    var node = circleGroup.selectAll("g")
                    .data(pack.nodes(data));

    //UPDATE
    node.select("circle").attr("class", "updatedCircle");
    node.select("title").text(function (d) { return d.name });
    node.select("text").text(function (d) { return d.name });
    node.select("path.paths")
        .transition()
        .duration(2000)
        .attr("d", function (d) { return describeArc(d.x, d.y, d.r, 180, 270); });
    node.select("textPath.pathText")
        .transition()
        .duration(2000)
        .text(function (d) { return d.name });

    //ENTER
    var nodeg = node.enter()
        .append("g")
        .on("mouseover", hoverName)
        .attr("class", function (d) { return d.children ? "node" : "leaf"; })
        .each(function (d) {
            if (d.depth > 0) {
                var pathid = this.__data__.r;
                d3.select(this).append("title")
                .text(function (d) { return d.name });
                d3.select(this).append("path")
                .attr("id", pathid)
                .attr("stroke", "#446688")
                .attr("stroke-width", function (d) { return 14 - (d.depth * 2) })
                .attr("transform", function (d) { return "translate(-" + d.x + ",-" + d.y + ")"; })
                .attr("transform", "translate(0,0)")
                .attr("class", "paths")
                d3.select(this).append("text")
                    .append("textPath")
                    .attr("class", "pathText")
                    .attr("xlink:href", "#" + pathid)
                    .text(function (d) { return d.name });
            }
        });

    nodeg.append("circle")
        .attr("r", 0)
        .transition()
        .duration(2000)
        .attr("r", function (d) { return d.r; })
    ;

    d3.selectAll("path.paths")
        .transition()
        .duration(2000)
        .attr("d", function (d) { return describeArc(d.x, d.y, d.r, 180, 270); })
        .attr("transform", function (d) { return "translate(-" + d.x + ",-" + d.y + ")"; });   

    //ENTER & UPDATE

    //Reflect DATA through POSITION
    node.transition()
        .duration(2000)
        .attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; });

    //Reflect DATA through SIZE
    node.select("circle")
        .transition()
        .duration(2000)
        .attr("r", function (d) { return d.r; });

    //EXIT
    node.exit()
        .transition()
        .attr("r", 0)
        .remove();
}

//Fetch all kinds of shit 
var ajaxData = function AjaxCall(d, i) {

    $.ajax({
        type: "POST",
        url: "default.aspx/" + d.methodName,
        data: "{}",
        contentType: "application/json",
        dataType: "json"
    })
    .done(function (msg) {
        // Feed the fetched data to the pack!
        drawCirclePack(msg);
    });
}


//Bind categories to method names 
var languageData = [{ methodName: "AjaxLanCollection" }];
d3.select("#languages").data(languageData).on("click", ajaxData);
var jobtypeData = [{ methodName: "AjaxJbtCollection" }];
d3.select("#services").data(jobtypeData).on("click", ajaxData);

