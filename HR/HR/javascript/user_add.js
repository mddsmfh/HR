$(function() {
	$("form:first").submit(function() {
		var userName = $("#userName");
		var userPassword = $("#userPassword");
		var userTrueName = $("#userTrueName");
		var reg1 = /^\S{6,}$/;
		var reg2 = /^\S{2,}$/;
		if (!reg1.test(userName.val())) {
			userName[0].select();
			$.messager.show("消息提示", "用户名称格式不正确！不能有空格且长度必须大于等于6位！", 2000);
			return false;
		}
		if (!reg1.test(userPassword.val())) {
			userPassword[0].select();
			$.messager.show("消息提示", "用户密码格式不正确！不能有空格且长度必须大于等于6位！", 2000);
			return false;
		}
		if (!reg2.test(userTrueName.val())) {
			userTrueName[0].select();
			$.messager.show("消息提示", "真实姓名格式不正确！不能有空格且长度必须大于等于2位！", 2000);
			return false;
		}
		return true;
	});
});