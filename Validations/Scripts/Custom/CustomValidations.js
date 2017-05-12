//CustomValidations.js
$.validator.addMethod("notequalto",
    function(value, element, params) {
        if (params != null) {
            return $("#" + params).val() !== value;
        }
        return true;
    });
$.validator.unobtrusive.adapters.addSingleVal("notequalto", "dependentproperty");