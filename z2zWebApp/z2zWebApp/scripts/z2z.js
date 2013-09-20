//// *********** Draw a circle-pack diagram using data given 
var width = 494,
height = 496;

//Declare svg variable
var svg = d3.select("div.navColumn").append("svg:svg")
        .attr("width", width)
        .attr("height", height)
        .attr("id", "cpContainer");

//Calibrate pack layout 
var pack = d3.layout.pack()
        .sort(d3.descending)
        .size([width, height])
        .value(function (d) { return d.name.length; });

//Draw the pack layout given data from ajax call 
var drawCirclePack = function (ajaxMsg) {
 
    var data = new Object();
    data.children = ajaxMsg.d;
    var nodes = pack.nodes(data);

    //Enter
    var circles = svg.selectAll("circle").data(nodes);
    circles
    .enter()
    .append("circle")
    .attr("class", "node")
    .attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; })
    .attr("r", function (d) { return d.r; })
    .append("svg:title")
    .text(function (d) { return d.name; });
    //Exit
circles.exit().remove(); 
}

//Fetch all kinds of shit 
var ajaxData = function AjaxCall(d, i) {

    $.ajax({
        type: "POST",
        url: "default.aspx/" + d.methodName,
        data: "{}",
        contentType: "application/json",
        dataType: "json",
        success:
            function (msg) {
                // Feed the fetched data to the pack!
                drawCirclePack(msg);
            }
    });
}

// *********** Create/Hover/Click Functions for SubCategories

var clnSubCategories = [
  { name: "Documents", methodName: "AjaxClnDocCollection" },
  { name: "Jobs", methodName: "AjaxClnJobCollection" }
];
var conSubCategories = [
  { name: "Languages", methodName: "AjaxConLanCollection" }
];

var subConCategories = d3.select("#catContibutor")
    .selectAll("div.subCategory")
    .data(conSubCategories)
    .enter()
    .append("div")
    .attr("class", "subCategory")
    .append("h5")
    .text(function (d) { return d.name })
    .on("click", ajaxData);

var subClnCategories = d3.select("#catClient")
    .selectAll("div.subCategory")
    .data(clnSubCategories)
    .enter()
    .append("div")
    .attr("class", "subCategory")
    .append("h5")
    .text(function (d) { return d.name })
    .on("click", ajaxData);

// *********** Hover/Click Functions for Categories

function hoverOverCategory(d, i) {
    var category = d3.select("div.tramColumn").selectAll("div.category");
    var subcategory = d3.select(category[0][i]).selectAll("div.subCategory")
        .transition()
        .style("height","50px");
};

function hoverOutCategory(d, i) {
    var category = d3.selectAll("div.category");
    d3.select(category[0][i]).selectAll("div.subCategory")
        .transition()
        .style("height", "0px");
};


//Bind Category hover/click events to functions 
d3.selectAll("div.category")
    .on("mouseover", hoverOverCategory)
    .on("mouseout", hoverOutCategory);
//Bind categories to method names 
var languageData = [{ methodName: "AjaxLanCollection" }];
d3.select("#catLanguage").data(languageData).on("click", ajaxData);
var jobtypeData = [{ methodName: "AjaxJbtCollection" }];
d3.select("#catService").data(jobtypeData).on("click", ajaxData);