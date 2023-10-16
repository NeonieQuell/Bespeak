const mdbPrimaryColor = '#3b71ca';

function swalInfoWait() {
    Swal.fire({
        icon: 'info',
        text: 'Please wait...',
        showConfirmButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false
    });
}

function swalError() {
    Swal.fire({
        icon: 'error',
        text: 'An error occured while processing your request',
        confirmButtonColor: mdbPrimaryColor
    });
}

$(document).ready(function () {
    // Data table
    $('#bookings-tbl').DataTable();

    // Start & end date validation
    $('#form-br-start-date').on({
        // Set minimum start date as current date
        click: function () {
            const currentDate = new Date().toISOString().split('T')[0];
            $(this).attr('min', currentDate);
        }, change: function () {
            // Set minimum end date depending not later than start date
            const startDate = $(this).val();
            $('#form-br-end-date').attr('min', startDate);
        }
    });

    // Submit for booking a room
    $('#form-br').submit(function (e) {
        e.preventDefault();

        var formData = new FormData($(this)[0]);

        $.ajax({
            type: 'post',
            url: 'bookings/createbook',
            cache: false,
            processData: false,
            contentType: false,
            data: formData,
            dataType: 'json',
            beforeSend: function () {
                $('#br-modal').modal('hide');
                swalInfoWait();
            },
            success: function (response) {
                Swal.fire({
                    icon: 'success',
                    title: response.title,
                    text: response.text,
                    allowOutsideClick: false,
                    allowEscapeKey: false,
                    confirmButtonColor: mdbPrimaryColor
                }).then(() => {
                    location.reload(true);
                });
            },
            error: function () {
                swalError();
            }
        });
    });
});