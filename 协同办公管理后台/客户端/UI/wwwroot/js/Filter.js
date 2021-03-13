HasUrl();
function HasUrl() {
    if (sessionStorage.getItem('token') == null) {
        location.href ='/HomePage/Login'
    }
    var data = sessionStorage.getItem('Power').split(',');
    for (var i = 0; i < data.length; i++) {
        if (data[i] == location.href.substring(21)) {
            return;
        }
    }
    location.href = '/Home/Error';
}

