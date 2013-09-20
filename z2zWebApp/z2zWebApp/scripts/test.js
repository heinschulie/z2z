

//var testAjax = d3.json("path/to/file.json", function (error, json) {
//    if (error) return console.warn(error);
//    data = json;
//    visualizeit();
//});

function AjaxCall() {
    d3.json('default.aspx/testMethod', function (result) { alert(result); })
}; 


//First define the svg drawing area:

//var screenHeight = 400,
//	screenWidth = 800,
//	vis = d3.select("body").append("svg")
//    .attr("width", screenWidth)
//    .attr("height", screenHeight)
//    .attr("color", "red"),
//    padding = 20;

//Next, call the function to import the data and set up a couple of scales to transform the raw (x,y) coordinates (given in ft) to 
//screen coordinates:


var click = function () {
    d3.json("default.aspx/testMethod", function (shots) {
        var scaleScreenX = d3.scale.linear()
                    .domain([0, 100])
                    .range([padding, screenWidth - padding]),
            scaleScreenY = d3.scale.linear()
                    .domain([0, 50])
                    .range([padding, screenHeight - padding]);

        //Draw a filled circle for each shot by binding the data to svg elements:


        vis.selectAll("circle")
            .data(shots)
            .enter()
            .append("circle")
            .attr("cx", function (d) {
                return scaleScreenY(d.y) + 5 * (Math.random() - 0.5);
            })
        .attr("cy", function (d) {
            return scaleScreenX(d.x) + 5 * (Math.random() - 0.5);
        })
        .attr("r", function () { return 2 * Math.random() + 6; })
        .attr("fill", function (d) { return d.desc.match(/Made/) ? "steelblue" : "red" })
        .attr("opacity", 0.60)
        .attr("stroke-width", 2)
        .attr("stroke", "black")
        .append("svg:title")
        .text(function (d) { return d.player_name + " " + d.desc; });

        //And do the same thing for adding the text labels to each shot:


        vis.selectAll("text")
    .data(shots)
    .enter()
    .append("text")
    .text(function (d) {
        return d.home;
    })
    .attr("x", function (d) {
        return scaleScreenY(d.y) - 2;
    })
    .attr("y", function (d) {
        return scaleScreenX(d.x) + 3;
    })
    .attr("font-family", "serif")
    .attr("font-size", "12px")
    .attr("fill", "black");
    });
};


var testClickTwo = function (jsonData) {

    var parsedJson = JSON.stringify(jsonData);
    alert(parsedJson);
    
    var data = {
        children: [
          { value: 1.94 },
          { value: 0.42 },
          { value: 0 },
          { value: 3.95 },
          { value: 0.06 },
          { value: 0.91 }
        ]
    };

    var width = 960,
    height = 500;

    var pack = d3.layout.pack()
        .sort(d3.descending)
        .size([width, height]);

    var svg = d3.select("body").append("svg")
        .attr("width", width)
        .attr("height", height);

    svg.data([data]).selectAll(".node")
        .data(pack.nodes)
      .enter().append("circle")
        .attr("class", "node")
        .attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; })
        .attr("r", function (d) { return d.r; });


    //var svgContainer = d3.select("body").append("svg")
    //                                    .attr("width", 800)
    //                                    .attr("height", 800)
    //;

    //var circles = svgContainer.selectAll("circle")
    //                          .data(jsonData)
    //                          .enter()
    //                          .append("circle");

    //var circleAttributes = circles
    //                       .attr("cx", function (d) { return d.ClnKey * 50; })
    //                       .attr("cy", function (d) { return d.ClnKey * 50; })
    //                       .attr("r", function (d) { return d.ClnKey * 10; })
    //                       .style("fill", "red")
    //                       .append("svg:title")
    //                       .text(function (d) { return d.ClnName; });
}

var testClick = function () { alert("I was clicked"); }; 


var writeText = function (jsonData) {
    //var json = JSON.parse(jsonData);
    //var j = $.parseJSON(jsonData);
    //var st = JSON.stringify(jsonData); 
    d3.select("h1").text(jsonData.ClnName);
};

var jqclick = function AjaxCall() {

    $.ajax({
        type: "POST",
        url: "default.aspx/testMethod",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        dataFilter: function (data) {
                // This boils the response string down 
                //  into a proper JavaScript Object().
                var msg = eval('(' + data + ')');

                // If the response has a ".d" top-level property,
                //  return what's below that instead.
                if (msg.hasOwnProperty('d'))
                    return msg.d;
                else
                    return msg;
            },
        success: 
            function (msg) {
            // Replace the div's content with the page method's return.
                testClickTwo(msg); 
            }
    });

    //$.ajax(
    //{
    //    type: 'POST',
    //    contentType: "application/json; charset=utf-8",
    //    url: 'default.aspx/testMethod',
        //datatype: 'json',
        //data: {},
        //success: function (result) { alert(result.d); }
        //dataFilter: function (data) {
        //    // This boils the response string down 
        //    //  into a proper JavaScript Object().
        //    var msg = eval('(' + data + ')');

        //    // If the response has a ".d" top-level property,
        //    //  return what's below that instead.
        //    if (msg.hasOwnProperty('d'))
        //        return msg.d;
        //    else
        //        return msg;
        //},
       
    //    success: testClickTwo
    //})
}

//var testAjax = d3.json("default.aspx/testMethod", function (error, json) {
//    if (error) return alert("error"); 
//    alert(json);
//});

d3.select("div.testDiv").on("click", jqclick);