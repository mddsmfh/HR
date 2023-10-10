$(function() {
	$("#date_start").click(function() {
		displayDatePicker('utilBean.startDate', false, 'ymd', '')
	});
	$("#date_end").click(function() {
		displayDatePicker('utilBean.endDate', false, 'ymd', '')
	});
	$("#firstKind").change(function() {
		$.ajax({
			cache : false,
			type : "POST",
			dataType : "xml",
			url : "/HR_Fist/humanResources/humanResourcesAction!doChangeFirstKind",
			data : "configFileSecondKind.firstKindId=" + $(this).val() + "&configFileThirdKind.firstKindId=" + $(this).val(),
			success : function(data) {
				var secondKinds = $(data).find("secondKind");
				var thirdKinds = $(data).find("thirdKind");
				var oSecondKind = $("#secondKind");
				var oThirdKind = $("#thirdKind");
					
				var allOption = $("<option></option>");
				allOption.val("").attr("selected", "selected").html("全部");
				var allOption2 = $("<option></option>");
				allOption2.val("").attr("selected", "selected").html("全部");
				
				oSecondKind.html("");
				oThirdKind.html("");
				oSecondKind.append(allOption);
				oThirdKind.append(allOption2);
					
				secondKinds.each(function(i) {
					var option = $("<option></option");
					option.attr("value", $(secondKinds[i]).attr("id")).html($(secondKinds[i]).attr("name"));
					oSecondKind.append(option);
				});
					
				thirdKinds.each(function(i) {
					var option = $("<option></option");
					option.attr("value", $(thirdKinds[i]).attr("id")).html($(thirdKinds[i]).attr("name"));
					oThirdKind.append(option);
				});
					
				oSecondKind[0].selectedIndex = 0;
				oThirdKind[0].selectedIndex = 0;
				
			}
		});
	});
	$("#secondKind").change(function() {
		var secondKindName = $(this)[0].options[$(this)[0].selectedIndex].innerHTML;
		if ($.trim(secondKindName) == "全部") {
			secondKindName = "";
		}
		$.ajax({
			cache : false,
			type : "POST",
			dataType : "xml",
			url : "/HR_Fist/humanResources/humanResourcesAction!doChangeSecondKind",
			data : "configFileThirdKind.secondKindId=" + $(this).val() + "&configFileThirdKind.firstKindId=" + $("#firstKind").val() + "&configFileThirdKind.secondKindName=" + secondKindName,
			success : function(data) {
				var thirdKinds = $(data).find("thirdKind");
				var oThirdKind = $("#thirdKind");
				
				var allOption = $("<option></option>");
				allOption.val("").attr("selected", "selected").html("全部");
				oThirdKind.html("");
				oThirdKind.append(allOption);
				thirdKinds.each(function(i) {
					var option = $("<option></option");
					option.attr("value", $(thirdKinds[i]).attr("id")).html($(thirdKinds[i]).attr("name"));
					oThirdKind.append(option);
				});
				oThirdKind[0].selectedIndex = 0;
			}
		});
	});
	$("#majorKind").change(function() {
		$.ajax({
			cache : false,
			type : "POST",
			dataType : "xml",
			url : "/HR_Fist/humanResources/humanResourcesAction!doChangeMajorKind",
			data : "configMajor.majorKindId=" + $(this).val(),
			success : function(data) {
				var configMajors = $(data).find("configMajor");
				var oMajorName = $("#majorName");
				var allOption = $("<option></option>");
				allOption.val("").attr("selected", "selected").html("全部");
				oMajorName.html("").append(allOption);
				configMajors.each(function(i) {
					var option = $("<option></option");
					option.attr("value", $(configMajors[i]).attr("id")).html($(configMajors[i]).attr("name"));
					oMajorName.append(option);
				});
			}
		});
	});
});