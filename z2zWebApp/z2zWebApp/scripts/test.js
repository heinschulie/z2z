
//var data1 = {
//    "name": "Names",
//    "children": [
//        { "name": "John", "size": 100 },
//        { "name": "Peter", "size": 200 },
//        { "name": "Arnold", "size": 300 },
//        { "name": "Rasmus", "size": 400 }
//    ]
//}


//var data2 = {
//    "name": "Names",
//    "children": [
//        { "name": "John", "size": 1000, "children": [{ "name": "1LevelDeeper", "size": 200 }, { "name": "1LevelDeeper2", "size": 150 }] },
//        { "name": "Rasmus", "size": 200 },
//        { "name": "Benjamin", "size": 300 },
//        { "name": "James", "size": 400 }
//    ]
//}

//var diameter = 960,
//    format = d3.format(",d");

//var pack = d3.layout.pack()
//    .size([diameter - 4, diameter - 4])
//    .value(function (d) { return d.size; });

//var svg = d3.select("body").append("svg")
//    .attr("width", diameter)
//    .attr("height", diameter)
//  .append("g")
//    .attr("transform", "translate(2,2)");

//var node;
//var currentJson = data1;

//var getNewData = function () {

//    if (currentJson == data1) {
//        currentJson = data2;
//    }
//    else {
//        currentJson = data1;
//    }
//   refresh();
//}

//var refresh = function () {

//    node = svg.selectAll(".node")
//                    .data(pack.nodes(currentJson));

//    node.enter().append("g")
//            .classed("node", true)
//            .attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; })
//            .append("circle")
//            .attr("r", 0)
//            .on("click", getNewData)
//            .transition()
//            .duration(2000)
//            .attr("r", function (d) { return d.r; });

//    node.transition()
//        .duration(2000)
//        .attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; });

//    node.select("circle")
//        .transition()
//        .duration(2000)
//        .attr("r", function (d) { return d.r; });

//    node.exit().remove(); 
//}

//d3.select(self.frameElement).style("height", diameter + "px");

//getNewData();

//d3.select("div.testDiv").on("click", getNewData);

//var divElem = d3.select("#svgpathSVGdata");

//var svgcanvas = divElem.append("svg:svg")
//    .attr("width", 500)
//    .attr("height", 500);

//// (1) Specifying path data the SVG way
//svgcanvas.append("svg:path")
//    .attr("d", "M245.451 129.166l4.86065 -12.4149c0.8972,-21.4431 -3.645,-51.4253 -7.15197,-73.39 -0.853819,-5.34475 8.29466,-62.9894 -16.3014,-36.379 -2.56441,2.77442 -5.80025,7.72085 -7.57197,11.6843l-18.3482 1.4651c-3.39851,-6.01716 -8.6003,-11.7513 -18.1964,-10.3927 -1.32608,5.50841 1.02439,11.6932 3.14907,16.5952 2.99527,6.91041 -1.06678,8.80439 -1.52721,17.03 -0.809452,14.4745 8.8034,19.2553 12.614,29.7752 -2.38103,4.26811 -13.0055,12.4711 -17.804,16.3231 -11.0789,8.89312 -19.6122,-0.550151 -47.1385,22.0327 -6.23998,5.11996 -10.0408,12.545 -16.4148,18.5198 -2.27948,2.1375 -5.57053,6.47266 -7.84212,9.28257 -2.86217,3.54049 -4.86854,6.10392 -7.42605,9.6799 -16.3704,22.8934 -27.8812,46.2827 -27.7915,77.0517 -12.8477,1.11115 -26.2446,1.79243 -39.111,2.5023 -6.52984,0.359866 -12.9029,0.730577 -19.3273,1.54299 -6.01321,0.759169 -13.4403,1.01946 -14.1225,7.42803 7.60549,4.54417 35.8515,2.63836 46.1102,2.48948 16.0283,-0.23268 30.0138,3.86979 46.9176,-0.193243 4.11825,-0.989878 5.59912,-2.73695 8.84876,-1.63566 4.18923,1.41974 5.67997,1.7451 10.4509,2.10596 14.4844,1.09833 34.6802,0.107467 49.4308,-0.81241 7.55817,-0.471276 16.9344,0.144932 20.4838,-4.92868 1.80722,-11.0306 -9.98653,-11.6942 -19.5688,-11.9692 6.78027,-6.54956 4.05317,-0.164651 13.7124,-13.178 2.20553,-2.97161 10.8058,-11.2722 14.0091,-12.7974 0.976075,5.13376 2.85921,11.4299 4.26318,16.5686 1.51242,5.53996 2.70442,11.5759 4.54516,17.032 4.64769,13.7834 26.8805,9.44032 31.9423,7.17957 1.76186,-10.0516 -2.02905,-12.8477 -11.0474,-11.0918 -3.29203,-9.22341 -7.25253,-14.6056 -6.55548,-26.7159 0.432825,-7.52958 5.00953,-19.7532 7.73662,-26.3373 5.88997,-14.2172 4.50177,-11.2919 12.3735,-21.8473 3.17865,-4.26318 10.4617,-16.3902 11.7987,-22.2052z")
//    .attr("id", "lechat")
//    .style("stroke-width", 1)
//    .style("stroke", "none")
//    .style("fill", "lightgray");

function fileSelected() {
    var file = document.getElementById('fileToUpload').files[0];
    if (file) {
        var fileSize = 0;
        if (file.size > 1024 * 1024)
            fileSize = (Math.round(file.size * 100 / (1024 * 1024)) / 100).toString() + 'MB';
        else
            fileSize = (Math.round(file.size * 100 / 1024) / 100).toString() + 'KB';

        document.getElementById('fileName').innerHTML = 'Name: ' + file.name;
        document.getElementById('fileSize').innerHTML = 'Size: ' + fileSize;
        document.getElementById('fileType').innerHTML = 'Type: ' + file.type;
    }
}

function uploadProgress(evt) {
    if (evt.lengthComputable) {
        var percentComplete = Math.round(evt.loaded * 100 / evt.total);
        document.getElementById('progressNumber').innerHTML = percentComplete.toString() + '%';
    }
    else {
        document.getElementById('progressNumber').innerHTML = 'unable to compute';
    }
}

function uploadComplete(evt) {
    /* This event is raised when the server send back a response */
    alert(evt.target.responseText);
}

function uploadFailed(evt) {
    alert(evt.target.responseText);
}

function uploadCanceled(evt) {
    alert("The upload has been canceled by the user or the browser dropped the connection.");
}


var ajaxPost = function () {

    //$.ajax({
    //    type: "POST",
    //    url: "default.aspx/UploadDocument",
    //    data: data,
    //    contentType: "application/plain",
    //    dataType: "json",
    //    success: function(r){
    //        alert(r.responseText);
    //    },
    //    statusCode: {
    //        404: function () {
    //           alert('Could not contact server.');
    //        },
    //        500: function () {
    //            alert('A server-side error has occurred.');
    //        }
    //    },
    //    error: function (r) {
    //        alert('A problem has occurred.    ' + r.responseText);
    //    },
    //});
    var data = {'json':'niall'};
    //$.ajax({
    //    type: "POST",
    //    url: "default.aspx/UploadDocument", //Direccion del servicio web segido de /Nombre del metodo a llamar
    //    beforeSend: function () { alert('I am sending'); },
    //    //data: "{BizName:'" + x + "'}",
    //    data: JSON.stringify(person),
    //    contentType: "application/json",
    //    dataType: "json",
    //    success: function(r){
    //                alert(r.responseText);
    //    },
    //    error: function (r) {
    //        alert('A problem has occurred.    ' + r.responseText);
    //    }
    //});

    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        dataType: 'json',
        url: 'default.aspx/UploadDocument',
        data: JSON.stringify(data),
        success: function (r) {
            alert(r.responseText);
        },
        error: function (r) {
            alert('A problem has occurred.    ' + r.responseText);
        }
    });
}



function uploadFile() {
    var fd = new FormData();
    fd.append("fileToUpload", document.getElementById('fileToUpload').files[0]);

    ajaxPost(); 
    //var xhr = new XMLHttpRequest();

    //xhr.upload.addEventListener("progress", uploadProgress, false);
    //xhr.addEventListener("load", uploadComplete, false);
    //xhr.addEventListener("error", uploadFailed, false);
    //xhr.addEventListener("abort", uploadCanceled, false);

    //xhr.onprogress = uploadProgress;
    //xhr.onerror = uploadFailed;
    //xhr.onabort = uploadCanceled;

    //xhr.open("POST", "default.aspx/UploadDocument");
    //xhr.send(fd);
}
