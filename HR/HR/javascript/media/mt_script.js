<!--
//Jump menu mod'd by Daniel Greene
function mt_JumpMenu(targ,selObj,restore){
 if (selObj.options[selObj.selectedIndex].value == 'ac')
  { eval(targ +
".location='https://accountcenter.mediatemple.net/login.php'"); }
}

//Jump menu by MM
function MM_jumpMenu(targ,selObj,restore){ //v3.0
  eval(targ+".location='"+selObj.options[selObj.selectedIndex].value+"'");
  if (restore) selObj.selectedIndex=0;
}

//Change status bar text (demian)
function makestatussay(txt) {
 self.status = txt
 }
function makestatusclear() {
 self.status = ""
 }

//Unsure what this is (demian)
function newImage(arg) {
	if (document.images) {
		rslt = new Image();
		rslt.src = arg;
		return rslt;
	}
}

function changeImages() {
	if (document.images && (preloadFlag == true)) {
		for (var i=0; i<changeImages.arguments.length; i+=2) {
			document[changeImages.arguments[i]].src = changeImages.arguments[i+1];
		}
	}
}

//var preloadFlag = false;
//function preloadImages() {
//	if (document.images) {
//		header_nav_02_over = newImage("/images/header_nav_02-over.gif");
//		header_nav_03_over = newImage("/images/header_nav_03-over.gif");
//		header_nav_04_over = newImage("/images/header_nav_04-over.gif");
//		header_nav_05_over = newImage("/images/header_nav_05-over.gif");
//		header_nav_06_over = newImage("/images/header_nav_06-over.gif");
//		preloadFlag = true;
//	}
//}

function MM_reloadPage(init) {  //reloads the window if Nav4 resized
  if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
    document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
  else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
}
MM_reloadPage(true);

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}
//-->