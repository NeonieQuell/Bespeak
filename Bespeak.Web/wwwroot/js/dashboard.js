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
                swalError(defaultSwalErrorMsg);
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
                swalError(defaultSwalErrorMsg);
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
});