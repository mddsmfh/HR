function aa(startTime) {
			displayDatePicker(startTime,false,"ymd","");
		}
function getDateTime(myName)
{
var now = new Date();
var hour = now.getHours( );  
var minute = now.getMinutes( );
var second = now.getSeconds( );
	 if (hour < 10) 
	   hour="0"+hour;
	 if (minute < 10) 
	   minute="0"+minute;
	 if (second < 10) 
	   second="0"+second;
var dateString = now.getFullYear()+"-"+(now.getMonth()+1)+"-"+now.getDate()+" ";
var timeString = hour + ":" + minute + ":" + second;
myName.value=dateString+timeString;
}