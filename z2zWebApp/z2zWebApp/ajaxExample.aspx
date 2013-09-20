<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxExample.aspx.cs" Inherits="Z2Z.AjaxExample" %>

<!DOCTYPE html>
<html>
<head>
  <title>Calling page methods with jQuery</title>
  <style type="text/css">
    #Result {
      cursor: pointer;
    }
  </style>
        <link href="styles/testCss.css" rel="stylesheet" />
</head>
<body>
  <div id="Result">Click here for the time.</div>
    
  <script src="http://d3js.org/d3.v3.min.js" charset="utf-8"></script>
    <script src="http://mbostock.github.com/d3/d3.layout.js?2.7.1"></script>
  <script type="text/javascript" src="scripts/jquery-1.10.1.min.js"></script>
  <script>
    $('#Result').click(function() {
      $.ajax({
        type: "POST",
        url: "ajaxExample.aspx/HelloWorld",
        data: "{}",
        contentType: "application/json",
        dataType: "json",
        success: function (msg) {

            var svgContainer = d3.select("body").append("svg")
                                                .attr("width", 800)
                                                .attr("height", 800)
            ;

            var circles = svgContainer.selectAll("circle")
                                      .data(msg.d)
                                      .enter()
                                      .append("circle");

            var circleAttributes = circles
                                   .attr("cx", function (d) { return d.ClnKey * 50; })
                                   .attr("cy", function (d) { return d.ClnKey * 50; })
                                   .attr("r", function (d) { return d.ClnKey * 10; })
                                   .style("fill", "red")
                                   .append("svg:title")
                                   .text(function (d) { return d.ClnName; });

            // Replace the div's content with the page method's return.
            //var data =
            //  //  msg.d;
            //    {
            //    children: [
            //      { value: 1.94 },
            //      { value: 0.42 },
            //      { value: 0 },
            //      { value: 3.95 },
            //      { value: 0.06 },
            //      { value: 0.91 }
            //    ]
            //};

            //var width = 960,
            //height = 500;

            //var pack = d3.layout.pack()
            //    .sort(d3.descending)
            //    .size([width, height]);

            //var svg = d3.select("body").append("svg")
            //    .attr("width", width)
            //    .attr("height", height);

            //svg.data([data]).selectAll(".node")
            //    .data(pack.nodes)
            //  .enter().append("circle")
            //    .attr("class", "node")
            //    .attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; })
            //    .attr("r", function (d) { return d.r; });
        }
      });
    });
  </script>
</body>
</html>