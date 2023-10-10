function changelocation(select2,locationid)
{
  select2.length = 0; 
   var locid=locationid;
  select2.options[select2.length]=new Option("",""); 
  for (var i=0;i < subcat.length; i++)
  {
 	if(locid==""||locid==null){select2.options[select2.length]=
 			 new Option(subcat[i][1],subcat[i][3]);}//如果select1为空，则select2选择全部值
    else if (subcat[i][2] == locid)
    { 
        select2.options[select2.length] = new Option(subcat[i][1],subcat[i][3]);
    } 
  } 
}
 
 function changelocation1(select3,locationid1)
  {
  select3.length = 0; 
  var locid1=locationid1;
  select3.options[select3.length]=new Option("",""); 
  for (var j=0;j < subcat1.length; j++)
  {
 		 if(locid1==""||locid1==null)
 		 {select3.options[select3.length]=new Option(subcat1[j][2],subcat1[j][1]);}
  else if (subcat1[j][3] == locid1){ 
   select3.options[select3.length] = new Option(subcat1[j][2],subcat1[j][1]);
  } 
  } 
 }
 
 function changelocation2(select5,locationid)
  {
	select5.length = 0; 
 
  var locid=locationid;
  select5.options[select5.length]=new Option("",""); 
  for (var k=0;k < subcat2.length; k++)
  {
 		 if(locid==""||locid==null){select5.options[select5.length]=
 			 new Option(subcat2[k][2],subcat2[k][1]);}//如果select1为空，则select5选择全部值
  else if (subcat2[k][3] == locid)
  { 
   select5.options[select5.length] = new Option(subcat2[k][2], 
 subcat2[k][1]);
  } 
  } 
 }