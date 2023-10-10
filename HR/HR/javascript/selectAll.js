$(function() {
	$(function() {
		$("#choice").click(function() {
			var checkboxs = $(":checkbox");
			if ($(this).val() == "全选") {
				checkboxs.attr("checked", "checked");
				$(this).val("取消");
			} else {
				checkboxs.removeAttr("checked");
				$(this).val("全选");
			}
		});
	});
	$("#table_name").change(function() {
		$.ajax({
			cache : false,
			url : "/HR_Fist/criterionData/criterionDataAction!doChangeTableName",
			data : "configPrimaryKey.primaryKeyTable=" + $(this).val(),
			type : "POST",
			dataType : "xml",
			success : function(data) {
				var items = $(data).find("item");
				var tBody = $("#fields");
				tBody.html("<tr>");
				items.each(function(i) {
					if (i % 4 == 0) {
						tBody.append("</tr>");
						tBody.append("<tr>");
					}
					var checkbox = $("<input type='checkbox'/>");
					checkbox.val($(items[i]).attr("value")).attr("name", "field");
					var td = $("<td></td>");
					td.addClass("TD_STYLE2").append(checkbox).append($(items[i]).attr("name"))
					  .appendTo(tBody);				
				});
				tBody.append("</tr>");
				$("#choice").val("全选");
			}
		});
	});
	$("form:first").submit(function() {
		var checkboxs = $(":checkbox");
		var flag = false;
		checkboxs.each(function(i) {
			if ($(this).attr("checked") == "checked") {
				flag = true;
			};
		});
		if (!flag) {
			$.messager.show("消息提示", "请选择要导出的字段！", 2000);
		}
		return flag;
	});
});