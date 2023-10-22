// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const currentDate = new Date().toISOString().split('T')[0];

function swalInfoWait() {
    Swal.fire({
        icon: 'info',
        text: 'Please wait...',
        showConfirmButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false
    });
}

function swalSuccess(text) {
    Swal.fire({
        icon: 'success',
        text: text,
        allowOutsideClick: false,
        allowEscapeKey: false,
        confirmButtonColor: '#3b71ca'
    }).then(() => {
        location.reload(true);
    });
}

function swalErrorDefault() {
    Swal.fire({
        icon: 'error',
        text: 'An error occured while processing your request',
        confirmButtonColor: '#3b71ca'
    });
}

function swalErrorCustom(text) {
    Swal.fire({
        icon: 'error',
        text: text,
        confirmButtonColor: '#3b71ca'
    });
}