$(function() {
	getTime("#create_time");
	$("#create_time").mouseover(function() {
		getTime("#create_time");
		$("#lastly_change_time").val($(this).val());
	});
	$("#birthday").click(function() {
		displayDatePicker('humanFile.humanBirthday', false, 'ymd', '')
	});
	$("form:first")[0].onreset = function() {
		if (confirm("是否全部清除？")) {
			return true;
		}
		return false;
	};
});