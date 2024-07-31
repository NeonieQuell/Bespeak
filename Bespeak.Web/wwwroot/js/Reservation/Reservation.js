$(document).ready(function () {
    // Data table
    $('#reservations-tbl').DataTable();

    // Start date validation for #form-reserve-room
    $('#form-reserve-room-start-date').click(function () {
        $(this).attr('min', currentDate);

        if ($('#form-reserve-room-end-date').val()) {
            $(this).attr('max', $('#form-reserve-room-end-date').val());
        }
    });

    // End date validation for #form-reserve-room
    $('#form-reserve-room-end-date').click(function () {
        if ($('#form-reserve-room-start-date').val()) {
            $(this).attr('min', $('#form-reserve-room-start-date').val());
        } else {
            $(this).attr('min', currentDate);
        }
    });

    $('#form-reserve-room').submit(function (e) {
        e.preventDefault();

        var formData = new FormData($(this)[0]);

        $.ajax({
            type: 'POST',
            url: 'Reservation/Reserve',
            cache: false,
            processData: false,
            contentType: false,
            data: formData,
            dataType: 'JSON',
            beforeSend: function () {
                $('#reserve-room-modal').modal('hide');
                swalInfoWait();
            },
            success: function (response) {
                if (response.result) {
                    Swal.fire({
                        icon: 'success',
                        title: response.title,
                        text: response.text,
                        allowOutsideClick: false,
                        allowEscapeKey: false,
                        confirmButtonColor: '#3b71ca'
                    }).then(() => {
                        location.reload(true);
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: response.title,
                        text: response.text,
                        allowOutsideClick: false,
                        allowEscapeKey: false,
                        confirmButtonColor: '#3b71ca'
                    }).then(() => {
                        location.reload(true);
                    });
                }
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });
});