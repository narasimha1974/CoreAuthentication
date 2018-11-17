
$.validator.addMethod("dategreaterthan", function (value, element, params) {    
  $("#ParamsContent").val(recursiveIteration(params));
 //$("#ParamsContent").val($(params[0]).val() +"    "+$(params[1]).val());
if(Date.parse(value) < Date.parse($(params).val()))
{
 $("div.error span").html("message");
 $("div.error").show();
}
 else { 
 $("div.error").hide();
 }
  //return false;
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
jQuery.validator.unobtrusive.adapters.add('dategreaterthan',['otherb','otherpropertynameb','yankamma','otherb-abcd',], function (options) {
    $("#OptionsContents").val(recursiveIteration(options));
    msg="";
    
    options.messages['dategreaterthan'] = options.message+" Hello ";
    options.rules['dategreaterthan'] ='#'+options.params.otherb;//,'#'+options.params.otherpropertynameb];       
    
      
});

let count = 0;
let msg = "";
function recursiveIteration(obj) { 
  for (var property in obj) {
       if (obj.hasOwnProperty(property)) {
          if (typeof obj[property] == "object"){
              recursiveIteration(obj[property]);
          }else if(typeof obj[property] == "string"){

            msg += property+"->"+obj+" "+jQuery.type(obj)+"\n\r";
            count+=1;
            continue;
          }
          else{
            msg += property+"->"+obj[property]+" "+jQuery.type(obj)+"\n\r";
            count+=1;            
        }
      }     
  }
  obj=null;  
  return msg+count;
}

$("#testForm4").validate({
  invalidHandler: function(event, validator) {
    // 'this' refers to the form
    var errors = validator.numberOfInvalids();
    if (errors) {
      var message = errors == 1
        ? 'You missed 1 field. It has been highlighted'
        : 'You missed ' + errors + ' fields. They have been highlighted';
      $("div.error span").html(message);
      $("div.error").show();
    } else {
      $("div.error").hide();
    }
  }
});