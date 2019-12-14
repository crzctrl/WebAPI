// favicon
$("link[href$='images/favicon-32x32-png']").attr("href", "/images/favicon-32x32.png");
$("link[href$='images/favicon-16x16-png']").attr("href", "/images/favicon-16x16.png");

// footer
$(".footer > h4").empty().text("[api version: v1]");

// header text
$(".logo__title").text("Head in the Clouds");

// href
$(".swagger-ui-wrap > a").attr("href", "https://christopherlifinancialportal.azurewebsites.net/");

// title
$("head title").text("Head in the Clouds");