var d1 = [[1, 300], [2, 600], [3, 550], [4, 400], [5, 300]];
 
$(document).ready(function () {
    $.plot($("#placeholder"), [d1]);
//    skill bar
    jQuery('.skillbar').each(function(){
		jQuery(this).find('.skillbar-bar').animate({
			width:jQuery(this).attr('data-percent')
		},6000);
	});
//    end of skill bar
    
});