$(function() {
	$(".grandfather_ck").click(function() {
		if ($(this)[0].checked) {
			$(this).parents(".grandfather").find(":checkbox").attr("checked", "checked");
		} else {
			$(this).parents(".grandfather").find(":checkbox").removeAttr("checked");
		}
	});
	$(".parent_ck").click(function() {
		var flag = false;
		if ($(this)[0].checked) {
			$(this).nextAll(".children").find(".children_ck").attr("checked", "checked");
		} else {
			$(this).nextAll(".children").find(".children_ck").removeAttr("checked");
		}
		$(this).parents(".grandfather").find(".parent_ck").each(function(i) {
			if ($(this)[0].checked) {
				flag = true;
			}
		});
		$(this).parents(".grandfather").find(".grandfather_ck")[0].checked = flag;
	});
	$(".children_ck").click(function() {
		var flag = false;
		$(this).parents(".children").find(".children_ck").each(function(i) {
			if ($(this)[0].checked) {
				flag = true;
			}
		});
		$(this).parents(".children").prevAll(".parent_ck")[0].checked = flag;
		var flag2 = false;
		$(this).parents(".grandfather").find(".parent_ck, .children_ck").each(function(i) {
			if ($(this)[0].checked) {
				flag2 = true;
			}
		});
		$(this).parents(".grandfather").find(".grandfather_ck")[0].checked = flag2;
	});
});