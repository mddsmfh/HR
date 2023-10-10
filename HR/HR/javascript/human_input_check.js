$(function() {
	$("form:first").submit(function() {
		var humanName = $("#humanName");
		var humanIdCard = $("#humanIdCard");
		var humanAge = $("#humanAge");
		var humanEmail = $("#humanEmail");
		var humanTelephone = $("#humanTelephone");
		var humanQq = $("#humanQq");
		var humanMobilephone = $("#humanMobilephone");
		var reg1 = /^\s+/;
		var reg2 = /\s+$/;
		var reg3 = /^\d{17}[0-9X]$/;
		var reg4 = /^\d{1,2}$/;
		var reg5 = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
		var reg6 = /^\d{3}-\d{8}|\d{4}-\d{7}$/;
		var reg7 = /^[1-9][0-9]{4,}$/;
		var reg8 = /^[1-9]{2}\d{9}$/;
		if ($("#firstKind").val() == "0") {
			$.messager.show("消息提示", "请选择Ⅰ级机构！", 2000);
			return false;
		}
		if (reg1.test(humanName.val()) || reg2.test(humanName.val())) {
			$.messager.show("消息提示", "姓名不能以空格开头或结尾！", 2000);
			humanName[0].select();
			return false;
		}
		if (humanName.val() == "") {
			$.messager.show("消息提示", "姓名不能为空！", 2000);
			humanName[0].select();
			return false;
		}
		if (!reg3.test(humanIdCard.val())) {
			$.messager.show("消息提示", "身份证号码格式不正确！", 2000);
			humanIdCard[0].select();
			return false;
		}
		if (!reg4.test(humanAge.val()) && humanAge.val() != "") {
			$.messager.show("消息提示", "年龄格式不正确！", 2000);
			humanAge[0].select();
			return false;
		}
		if (!reg5.test(humanEmail.val()) && humanEmail.val() != "") {
			$.messager.show("消息提示", "EMAIL格式不正确！", 2000);
			humanEmail[0].select();
			return false;
		}
		if (!reg6.test(humanTelephone.val()) && humanTelephone.val() != "") {
			$.messager.show("消息提示", "电话格式不正确！", 2000);
			humanTelephone[0].select();
			return false;
		}
		if (!reg7.test(humanQq.val()) && humanQq.val() != "") {
			$.messager.show("消息提示", "QQ格式不正确！", 2000);
			humanQq[0].select();
			return false;
		}
		if (!reg8.test(humanMobilephone.val()) && humanMobilephone.val() != "") {
			$.messager.show("消息提示", "手机格式不正确！", 2000);
			humanMobilephone[0].select();
			return false;
		}
		return true;
	});
});