
$.validator.addMethod("dategreaterthan", function (value, element, params) {
    return Date.parse(value) > Date.parse($(params).val());
});

/// <param name="adapterName" type="String">The name of the adapter to be added. This matches the name used
/// in the data-val-nnnn HTML attribute (where nnnn is the adapter name).</param>

/// <param name="params" type="Array" optional="true">[Optional] An array of parameter names (strings) that will
/// be extracted from the data-val-nnnn-mmmm HTML attributes (where nnnn is the adapter name, and
/// mmmm is the parameter name).</param>

/// <param name="fn" type="Function">The function to call, which adapts the values from the HTML
/// attributes into jQuery Validate rules and/or messages.</param>
/// <returns type="jQuery.validator.unobtrusive.adapters" />

// and an unobtrusive adapter

// $.validator.unobtrusive.adapters.add("dategreaterthan", function (options) {
//     options.rules["dategreaterthan"] = '#'+params.otherpropertyname;
//     options.messages["dategreaterthan"] = "Client Side Reporting " + options.message + '';   
// });

// and an unobtrusive adapter
jQuery.validator.unobtrusive.adapters.add('dategreaterthan', ['otherb', 'otherpropertyname', 'yankamma', 'otherb-abcd',], function (options) {
    $("#OptionsContents").val(recursiveIteration(options));
    msg = "";

    options.messages['dategreaterthan'] = options.message + " Hello ";
    options.rules['dategreaterthan'] = '#' + options.params.otherpropertyname;//,'#'+options.params.otherpropertynameb];       


});


