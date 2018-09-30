function FetchStatesOfCountry(val) {

   
    $.getJSON("/Address/FetchStatesOfCountry", { selectedCountryId: val }, function (data) {
        var html = '';
        var len = data.length;
        for (var i = 0; i < len; i++) {
            html += '<option value="' + data[i].value + '">' + data[i].text + '</option>';
        }
        $('#selectedStateId').append(html);
    });
}

