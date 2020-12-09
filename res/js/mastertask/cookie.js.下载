/**
 * 写入Cookie
 * @param name 名字
 * @param value 值
 * @param endtime 结束时间 (天数)
 * @param isPub 是否全局cookie
 */
function setCookie(name,value,endtime, isPub){
    var Days = endtime;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days*24*60*60*1000);
    cookieStr = name + "="+ escape (value) + ";expires=" + exp.toGMTString() + ";";
    if (isPub) {
      cookieStr += "path=/;";
    }
    document.cookie = cookieStr;
}

/**
 * 获取Cookie
 * @param name
 * @returns {string|null}
 */
function getCookie(name){
    var arr,reg=new RegExp("(^| )"+name+"=([^;]*)(;|$)");
    if(arr=document.cookie.match(reg))
        return unescape(arr[2]);
    else
        return null;
}

/***
 * 删除Coolie
 * @param name
 */
function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval=getCookie(name);
    if(cval!=null){
        document.cookie= name + "="+cval+";expires="+exp.toGMTString();
    }
}

/**
 * 获取url字段
 * @param keys 参数字段（"***"）
 * @param url 整个链接
 * @returns {string}
 */
function geturl(keys, url) {
    var new_reg = new RegExp('(^|[&?])' + keys + '=([^&]*)(&|$)');
    var new_index = url.indexOf('?');
    var new_str = url.substring(new_index, url.length);
    var new_r = new_str.match(new_reg);
    if (new_r != null) return unescape(new_r[2]);
    return '';
}

function setSession(key, value) {
  //检测浏览器支持
  if (typeof(sessionStorage) === undefined) return false;
  sessionStorage.setItem(key, value);
}

function getSession(key) {
  //检测浏览器支持
  if (typeof(sessionStorage) === undefined) return false;
  return sessionStorage.getItem(key);
}

function GetQueryValue(queryName) {
    var query = decodeURI(window.location.search.substring(1));
    var vars = query.split("&");
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split("=");
        if (pair[0] == queryName) { return pair[1]; }
    }
    return null;
}