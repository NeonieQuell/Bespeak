const mdb_primary_color = '#3b71ca';

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
        confirmButtonColor: mdb_primary_color
    }).then(() => {
        location.reload(true);
    });
}

function swalError() {
    Swal.fire({
        icon: 'error',
        text: 'An error occured while processing your request',
        confirmButtonColor: mdb_primary_color
    });
}

function swalError(text) {
    Swal.fire({
        icon: 'error',
        text: text,
        confirmButtonColor: mdb_primary_color
    });
}

$(document).ready(function () {
    // Change header on tab click
    $('.nav-link').click(function() {
        $('#header').html($(this).text());
    });

    // Data tables
    $('#all-rooms-tbl').DataTable();
    $('#room-types-tbl').DataTable();

    // Submit for new room type
    $('#form-nrt').submit(function(e) {
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
                swalError();
            }
        });
    })
});