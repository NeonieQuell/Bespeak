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

function swalErrorDefault() {
    Swal.fire({
        icon: 'error',
        text: 'An error occured while processing your request',
        confirmButtonColor: mdbPrimaryColor
    });
}

$(document).ready(function () {
    // Data table
    $('#recent-tbl').DataTable();

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

    // Change input value of room type and floor number
    $(document).on('change', '#form-eb-room-id', function () {
        const roomType = $(this).find('option:selected').attr('data-room-type');
        const floorNum = $(this).find('option:selected').attr('data-floor-num');
        $('#form-eb-room-type').val(roomType);
        $('#form-eb-floor-num').val(floorNum);
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