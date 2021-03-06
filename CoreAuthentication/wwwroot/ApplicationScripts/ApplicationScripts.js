﻿function FetchStatesOfCountry(val) {
    if (val) {
        // `a` is falsey, which includes `undefined` and `null`
        // (and `""`, and `0`, and `NaN`, and [of course] `false`)

        $.getJSON("/Address/FetchStatesOfCountry", { selectedCountryId: val }, function (data) {
            var html = '';
            var len = data.length;
            for (var i = 0; i < len; i++) {
                html += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
            }
            $('#selectedStateId').append(html);
        });
    }
    else {
        //do nothing
    }             
}
function SetHiddenCountry(val) {
    if (val) {
        $('#referer').val(val.value);
    }
    else {
        $('#referer').val('-1');
    }
    
}
function FetchStatesOfCountryFromHidden() {
    FetchStatesOfCountry($('#referer').val());
}
