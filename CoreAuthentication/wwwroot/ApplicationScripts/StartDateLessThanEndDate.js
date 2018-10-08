//date greater than is on enddate hence accessing start date here
/*
 The actual method implementation, returning true if an element is valid. First argument: Current value. Second argument: Validated element. Third argument: Parameters.
 */
$.validator.addMethod("dategreaterthan", function (value, element, params) {
    return Date.parse(value) > Date.parse($(params).val());
});

$.validator.unobtrusive.adapters.add("dategreaterthan", ["StartDate"], function (options) {
    options.rules["dategreaterthan"] = "#" + options.params.otherpropertyname;
    options.messages["dategreaterthan"] = options.message +'tring ding ';
});
