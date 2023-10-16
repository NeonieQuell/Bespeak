const mdbPrimaryColor = '#3b71ca';
const defaultSwalErrorMsg = 'An error occured while processing your request';

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
        confirmButtonColor: mdbPrimaryColor
    }).then(() => {
        location.reload(true);
    });
}

function swalError(text) {
    Swal.fire({
        icon: 'error',
        text: text,
        confirmButtonColor: mdbPrimaryColor
    });
}

$(document).ready(function () {
    // Data tables
    $('#all-rooms-tbl').DataTable();
    $('#room-types-tbl').DataTable();

    // Change header on tab click
    $('.nav-link').click(function () {
        $('#header').html($(this).text());
    });

    // Submit for new room
    $('#form-nr').submit(function (e) {
        e.preventDefault();

        var formData = new FormData($(this)[0]);

        $.ajax({
            type: 'post',
            url: 'rooms/createroom',
            cache: false,
            processData: false,
            contentType: false,
            dataType: 'json',
            data: formData,
            beforeSend: function () {
                $('#nr-modal').modal('hide');
                swalInfoWait();
            },
            success: function (response) {
                swalSuccess(response.text);
            },
            error: function () {
                swalError(defaultSwalErrorMsg);
            }
        });
    });

    // Submit for new room type
    $('#form-nrt').submit(function (e) {
        e.preventDefault();

        var formData = new FormData($(this)[0]);

        $.ajax({
            type: 'post',
            url: 'rooms/createroomtype',
            cache: false,
            processData: false,
            contentType: false,
            dataType: 'json',
            data: formData,
            beforeSend: function () {
                $('#nrt-modal').modal('hide');
                swalInfoWait();
            },
            success: function (response) {
                if (response.result) {
                    swalSuccess(response.text);
                } else {
                    swalError(response.text);
                }
            },
            error: function () {
                swalError(defaultSwalErrorMsg);
            }
        });
    })
});