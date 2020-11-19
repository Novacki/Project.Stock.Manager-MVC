// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function() {
    $(".userForm").submit(function() {
        var password = $(".password").val();
        var confirmPassword = $(".password_again").val();

        if(password !== confirmPassword) { 
            $(".confirmError").text("Password do not match");
            return false;
        }

        return true;
    })
});
