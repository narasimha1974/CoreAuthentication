$(document).ready(function () {
    // model validation method
    $.validator.addMethod("noNameInSubject", function (value, element, params) {
        return value.indexOf($("#" + params[0]).val()) < 0;
    }, "Pleae do NOT put your name in the Subject"
    );

    // validation
    $("#EmailForm").validate({
        rules: {
            Name: {
                required: true,
                minlength: 2
            },
            Email: {
                required: true,
                email: true
            },
            Subject: {
                required: true,
                noNameInSubject: ["Name"]
            },
            Body: "required"
        },
        messages: {
            Name: {
                required: "  Please enter your name",
                minlength: "  Please enter at least 2 characters"
            },
            Email: {
                required: "  Please enter your email",
                email: "  Please enter an valid email"
            },
            Subject: {
                required: "  Please enter the subject"
            },
            Body: "  Please enter the message"
        }
    });

    // Reset button: click event
    $("#resetBtn").click(function () {
        $(":text").val(null);
        $("textarea").val(null);
    });
});