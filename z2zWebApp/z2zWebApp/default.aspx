<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Z2Z._default" %>

<!DOCTYPE html>
<html lang="en" class="no-js demo-4">
	<head>
		<meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"> 
		<meta name="viewport" content="width=device-width, initial-scale=1.0"> 
		<title>Lit Translation Services</title>
		<meta name="description" content="Lots In Translation" />
		<meta name="keywords" content="javascript, jquery, plugin, css3, flip, page, 3d, booklet, book, perspective" />
		<meta name="author" content="Codrops" />
		<link rel="shortcut icon" href="../favicon.ico"> 
		<link rel="stylesheet" type="text/css" href="styles/default.css" />
		<link rel="stylesheet" type="text/css" href="styles/bookblock.css" />
		<!-- custom demo style -->
		<link rel="stylesheet" type="text/css" href="styles/morebookblock.css" />
		<link rel="stylesheet" type="text/css" href="styles/litcss.css" />
		<script src="scripts/modernizr.custom.js"></script>
	</head>
	<body>
        <div class ="header">
            <div class="headerlogo"></div>
            <nav class="headerlinks">
                <p id="home">Home</p>
                <p id="about">About Us</p>
                <p id="whatwedo">Services</p>
                <p id="clients">Clients</p>
                <p id="login">Account</p>
            </nav>
        </div>
		<div class="container">
			<div class="bb-custom-wrapper">			
				<div id="bb-bookblock" class="bb-bookblock">
					<div class="bb-item">
						<div class="bb-custom-firstpage">
							<!--<h1>BookBlock <span>A Content Flip Plugin</span></h1>	
							<nav class="codrops-demos">
								<a class="current-demo" href="index4.html">Demo 4</a>
							</nav>-->
                            <img class="litlogo" src="images/litlogo.png"/>
						</div>
						<div class="bb-custom-side">
							<p>Welcome to Lit. We are a language company that specialises in translation, interpretation, composition and editing of documents in the 11 official South African languages. We take tremendous pride in quality of our work as well as the speed and affordability of our service.</p>
						</div>
					</div>
					<div class="bb-item">
						<div class="bb-custom-side">
							<p>Lit is run by two brothers, Vana and Hein, who both share a love for language and technology. In this case, Vana overseas the language side of things while Hein handles the tech. Our linguists are all highly qualified and reliable... Hover over the folks opposite to learn more.</p>
						</div>
						<div class="bb-custom-side">
							<!--<p>Pics to be added here plus something endearing</p>-->
                            <div class="imgcontainer">
                                <div class="brothers" id="van"></div> 
                                <div class="brothers" id="hein"></div>
                            </div> 
						</div>
					</div>
					<div class="bb-item">
						<div class="bb-custom-side">
							<p>Lit specialises in the translation, editing and composition of written documents in the 11 official South African languages as well as German. What Lit offers its clients, above just great service, is unrivalled communication and feedback about the state of the project within the scope of its duration. </p>
						</div>
						<div class="bb-custom-side">
                            <div class="innerHeading" id="services"><h2>Services</h2></div>
                            <div class="innerHeading" id="languages"><h2>Languages</h2></div> 
                            <div class="navigation"></div>                    
							<!--<p>Some D3 trickery here to make illustrate language and service relationships</p>-->
						</div>
					</div>
					<div class="bb-item">
						<div class="bb-custom-side">
							<p>We at Lit believe we can offer you and your company a great service and enjoyable experience - but don't take our word for it... hover over some of our past and present clients opposite to see what they have to say about Lit Language Services.</p>
						</div>
						<div class="bb-custom-side">
							<p>D3 client bubbles with hover event that transforms above text to customer review.</p>
						</div>
					</div>
					<div class="bb-item">
						<div class="bb-custom-side">
							<p>Heard enough? Let's get started. Sign up in 30 seconds to access your private dashboard of unrivalled technological tools with which to communicate your business needs and track your project's progress.</p>
						</div>
						<div class="bb-custom-side">
							<div id="loginform" class="animate form">
                                <form autocomplete="on"> 
                                    <h1>Log in</h1> 
                                    <p> 
                                        <label for="username" class="uname" data-icon="u" > Your email </label>
                                        <input id="username" name="username" required="required"  type="email" placeholder="eg. mymail@mail.com"/>
                                    </p>
                                    <p> 
                                        <label for="password" class="youpasswd" data-icon="p"> Your password </label>
                                        <input id="password" name="password" required="required" type="password" placeholder="eg. X8df!90EO" /> 
                                    </p>
                                    <p class="keeplogin"> 
                                        <input type="checkbox" name="loginkeeping" id="loginkeeping" value="loginkeeping" /> 
                                        <label for="loginkeeping">Keep me logged in</label>
                                    </p>
                                    <p class="login button"> 
                                        <input type="submit" id="btnLogon" value="Fan" /> 
                                        <input type="submit" id="btnUsrLogon" value="User" onclick="return logonuser()" /> 
                                    </p>
                                    <p class="change_link">
                                        Not a member yet ?
                                        <a id="toregister" class="to_register">Join us</a>
                                    </p>
                                </form>
                            </div>
                             <%-- **********************************************--%>
                            <div id="registerform" class="animate form">
                                <form autocomplete="on"> 
                                    <h1> Sign up </h1> 
                                    <p> 
                                        <label for="emailsignup" class="youmail" data-icon="e" > Your email</label>
                                        <input id="emailsignup" name="emailsignup" required="required" type="email" placeholder="eg. mysupermail@mail.com"/> 
                                    </p>
                                    <p> 
                                        <label for="passwordsignup" class="youpasswd" data-icon="p">Your password </label>
                                        <input id="passwordsignup" name="passwordsignup" required="required" type="password" placeholder="eg. X8df!90EO"/>
                                    </p>
                                    <p> 
                                        <label for="passwordsignup_confirm" class="youpasswd" data-icon="p">Please confirm your password </label>
                                        <input id="passwordsignup_confirm" name="passwordsignup_confirm" required="required" type="password" placeholder="eg. X8df!90EO"/>
                                    </p>
                                    <p class="signin button"> 
                                        <input type="submit" id="btnRegister" value="Sign up"/> 
                                    </p>
                                    <p class="change_link">  
                                        Already a member ?
                                        <a id="tologin" class="to_register"> Go and log in </a>
                                    </p>
                                </form>
                            </div>
						</div>
					</div>					
				</div>

               

                
				<%--<nav>
					<a id="bb-nav-first" href="#" class="bb-custom-icon bb-custom-icon-first">First page</a>
					<a id="bb-nav-prev" href="#" class="bb-custom-icon bb-custom-icon-arrow-left">Previous</a>
					<a id="bb-nav-next" href="#" class="bb-custom-icon bb-custom-icon-arrow-right">Next</a>
					<a id="bb-nav-last" href="#" class="bb-custom-icon bb-custom-icon-last">Last page</a>
				</nav>--%>
                <!--<div id="quote"> 
                    <p>Get a free quote!</p>
                </div>-->
			</div>

		</div><!-- /container -->
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
		<script src="scripts/jquerypp.custom.js"></script>
		<script src="scripts/jquery.bookblock.js"></script>
        <script src="http://d3js.org/d3.v3.min.js" charset="utf-8"></script>
        <script type="text/javascript" src="scripts/lit.js"></script>
        <script type="text/javascript" src="scripts/logon.js"></script> 

		<script>
		    var Page = (function () {

		        var config = {
		            $bookBlock: $('#bb-bookblock'),
		            $navNext: $('#bb-nav-next'),
		            $navPrev: $('#bb-nav-prev'),
		            $navFirst: $('#bb-nav-first'),
		            $navLast: $('#bb-nav-last'),
		            //this is where I stepped in 
		            $navHome: $('#home'),
		            $navAbout: $('#about'),
		            $navServices: $('#whatwedo'),
		            $navClients: $('#clients'),
		            $navLogin: $('#login')
		        },
					init = function () {
					    config.$bookBlock.bookblock({
					        speed: 1000,
					        shadowSides: 0.8,
					        shadowFlip: 0.4
					    });
					    initEvents();
					},
					initEvents = function () {

					    var $slides = config.$bookBlock.children();

					    // add navigation events
					    config.$navNext.on('click touchstart', function () {
					        config.$bookBlock.bookblock('next');
					        return false;
					    });

					    config.$navPrev.on('click touchstart', function () {
					        config.$bookBlock.bookblock('prev');
					        return false;
					    });

					    config.$navFirst.on('click touchstart', function () {
					        config.$bookBlock.bookblock('first');
					        return false;
					    });

					    config.$navLast.on('click touchstart', function () {
					        config.$bookBlock.bookblock('last');
					        return false;
					    });

					    config.$navHome.on('click touchstart', function () {
					        config.$bookBlock.bookblock('jump', 1);
					        return false;
					    });

					    config.$navAbout.on('click touchstart', function () {
					        config.$bookBlock.bookblock('jump', 2);
					        return false;
					    });

					    config.$navServices.on('click touchstart', function () {
					        config.$bookBlock.bookblock('jump', 3);
					        return false;
					    });

					    config.$navClients.on('click touchstart', function () {
					        config.$bookBlock.bookblock('jump', 4);
					        return false;
					    });

					    config.$navLogin.on('click touchstart', function () {
					        config.$bookBlock.bookblock('jump', 5);
					        return false;
					    });

					    // add swipe events
					    $slides.on({
					        'swipeleft': function (event) {
					            config.$bookBlock.bookblock('next');
					            return false;
					        },
					        'swiperight': function (event) {
					            config.$bookBlock.bookblock('prev');
					            return false;
					        }
					    });

					    // add keyboard events
					    $(document).keydown(function (e) {
					        var keyCode = e.keyCode || e.which,
								arrow = {
								    left: 37,
								    up: 38,
								    right: 39,
								    down: 40
								};

					        switch (keyCode) {
					            case arrow.left:
					                config.$bookBlock.bookblock('prev');
					                break;
					            case arrow.right:
					                config.$bookBlock.bookblock('next');
					                break;
					        }
					    });
					};

		        return { init: init };

		    })();
		</script>
		<script>
		    Page.init();
		</script>
	</body>
</html>
