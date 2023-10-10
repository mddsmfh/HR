$(function() {
	$("form:first").submit(function() {
		var reg = /^[\u4e00-\u9fa5]{2,}$/;
		if (!reg.test($("#roleName").val())) {
			$("#roleName")[0].select();
			$.messager.show("消息提示", "角色名称格式不正确！必须为2个以上的中文汉字！", 2000);
			return false;
		}
		return true;
	});
});