$(document).ready(function(){$("#owl-demo").owlCarousel({navigation:!1,slideSpeed:500,autoPlay:3e3,paginationSpeed:400,singleItem:!0})}),jQuery(function(n){function t(t){var o=n(this);t=n.extend({},t||{},o.data("countToOptions")||{}),o.countTo(t)}n(".timer").data("countToOptions",{formatter:function(t,o){return t.toFixed(o.decimals).replace(/\B(?=(?:\d{3})+(?!\d))/g,",")}}),n("#testimonials").waypoint(function(){n(".timer").each(t)})}),$(document).ready(function(){$(".navbar a, footer a[href='#myPage']").on("click",function(t){t.preventDefault();var o=this.hash;$("html, body").animate({scrollTop:$(o).offset().top},900,function(){window.location.hash=o})})});