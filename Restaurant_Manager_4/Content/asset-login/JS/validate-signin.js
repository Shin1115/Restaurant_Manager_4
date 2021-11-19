document.querySelector('.img-btn').addEventListener('click', function() {
    document.querySelector('.cont').classList.toggle('s-signup')
});

function validator(options) {

    function validate(inputElement, rule) {
        var errorElement = inputElement.parentElement.querySelector(options.errorSelector);
        var error = rule.test(inputElement.value);
        if (error) {
            errorElement.classList.add('invalid');
        } else {
            errorElement.classList.remove('invalid');
        }
    }

    // lấy element của class cần validate
    var contElement = document.querySelector(options.class);
    if (contElement) {
        options.rules.forEach(function(rule) {
            var inputElement = contElement.querySelector(rule.selector);
            var errorElement = inputElement.parentElement.querySelector(options.errorSelector);
            if (inputElement) {
                inputElement.onblur = function() {
                    validate(inputElement, rule);
                }

                inputElement.oninput = function() {
                    errorElement.classList.remove('invalid');
                }
            }

        });
    }

}

validator.isRequired = function(selector) {
    return {
        selector: selector,
        test: function(value) {
            return value.trim() ? undefined : 'Vui lòng nhập trường này';
        }
    };
}
validator.isEmail = function(selector) {
    return {
        selector: selector,
        test: function(value) {
            var regexEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return regexEmail.test(value.trim()) ? undefined : ' ';
        }
    }
}
validator.minLength = function(selector, min) {
    return {
        selector: selector,
        test: function(value) {
            return value.length >= min ? undefined : 'Phải đủ 8 kí tự';
        }
    }
}
validator.isConfirmed = function(selector, getConfirmValue) {
    return {
        selector: selector,
        test: function(value) {
            return value === getConfirmValue() ? undefined : 'Phải trùng với trường password';
        }
    }
}