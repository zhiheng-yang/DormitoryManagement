if(document.getElementById('cse-search-box')){
document.getElementById('cse-search-box').action='/search';
}

$(function(){	
	var url = getCookie('firsturl');
	if(!url){
		setCookie('firsturl',location.href,999,true);
	}
	
	var infoid = $('#infoid').val();	
	if(infoid){
		var downbtn = $('.btn-down');	
		downbtn.on('click',function(){
			setCookie('ordertplid',infoid,999,true);
		});	
	}
	
	$('#go').click(function(){
		var searchTxt=$('#q').val();
		if(searchTxt!=""&&searchTxt!=undefined)
		{
			setCookie('ssword',searchTxt,999,true);
		}
		_czc.push(['_trackEvent', 'ssword',searchTxt]);
	})
});




var _hmt = _hmt || [];
(function() {
  var hm = document.createElement("script");
  hm.src = "https://hm.baidu.com/hm.js?a5ba743d0ea57bb0c5a7ad25181e4f7b";
  var s = document.getElementsByTagName("script")[0]; 
  s.parentNode.insertBefore(hm, s);
})();

// <script type="text/javascript" src="https://v1.cnzz.com/z_stat.php?id=1278890537&web_id=1278890537"></script>
document.write('<div style="display: none">');
document.write('<script type="text/javascript" src="https://v1.cnzz.com/z_stat.php?id=1278890537&web_id=1278890537"><\/script>');
document.write('</div>');


// var url = window.location.href;
// if (url.match(RegExp('/tags.asp'))){
//   $(".page-header").before('<div><a href="http://www.cssmoban.com/item/Getclick.asp?Action=Count&GetFlag=0&m=1&ID=4" rel="nofollow" target="_blank"><img src="http://img.cssmoban.com/uploadFiles/2020/2/20200204151049.jpg" title="" alt="" border="0" height="90" width="970"></a></div>')
// }

// 2020-09-03
// var url = window.location.href;
// if (url.match(RegExp('/tags.asp'))){
//   $(".page").prepend('<div><a href="http://www.cssmoban.com/item/Getclick.asp?Action=Count&GetFlag=0&m=1&ID=21" onclick="_czc.push([\'_trackEvent\', \'AD4\', \'AD4\'])" style="display: block;width: 100%;margin: 0px auto 10px;text-align: center;" rel="nofollow" target="_blank"><img src="http://www.cssmoban.com/images/ads/20190705.jpg" title="" alt="" border="0" height="90" width="970"></a></div>')
// }

