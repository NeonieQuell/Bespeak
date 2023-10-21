const mdbPrimaryColor = '#3b71ca';
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

function swalErrorDefault() {
    Swal.fire({
        icon: 'error',
        text: 'An error occured while processing your request',
        confirmButtonColor: mdbPrimaryColor
    });
}

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
                    confirmButtonColor: mdbPrimaryColor
                }).then(() => {
                    location.reload(true);
                });
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });

    // View booking modal
    $('.btn-view').click(function () {
        $.ajax({
            type: 'get',
            url: 'bookings/getbooking',
            data: { bookingId: $(this).closest('tr').attr('data-booking-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                $('#modal-container').html(response);
                $('#view-booking-modal').modal('show');
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });

    // Edit booking modal
    $('.btn-edit').click(function () {
        $.ajax({
            type: 'get',
            url: 'bookings/editbooking',
            data: { bookingId: $(this).closest('tr').attr('data-booking-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                $('#modal-container').html(response);
                $('#edit-booking-modal').modal('show');
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });

    // Start date validation for #form-eb
    $(document).on('click', '#form-eb-start-date', function () {
        $(this).attr('min', currentDate);

        if ($('#form-eb-end-date').val()) {
            $(this).attr('max', $('#form-eb-end-date').val());
        }
    });

    // End date validation for #form-eb
    $(document).on('click', '#form-eb-end-date', function () {
        $(this).attr('min', $('#form-eb-start-date').val());
    });
});