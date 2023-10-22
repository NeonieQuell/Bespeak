$(document).ready(function () {
    $('.btn-view-booking').click(function () {
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
})