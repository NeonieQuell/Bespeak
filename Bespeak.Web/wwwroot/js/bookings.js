$(document).ready(function () {
    // Data table
    $('#bookings-tbl').DataTable();

    // Start date validation for #form-br
    $('#form-br-start-date').click(function () {
        $(this).attr('min', currentDate);

        if ($('#form-br-end-date').val()) {
            $(this).attr('max', $('#form-br-end-date').val());
        }
    });

    // End date validation for #form-br
    $('#form-br-end-date').click(function () {
        if ($('#form-br-start-date').val()) {
            $(this).attr('min', $('#form-br-start-date').val());
        } else {
            $(this).attr('min', currentDate);
        }
    });

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
                    confirmButtonColor: '#3b71ca'
                }).then(() => {
                    location.reload(true);
                });
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });
});