$(document).ready(function () {
    $('.btn-view-reservation').click(function () {
        $.ajax({
            type: 'GET',
            url: 'Reservation/GetReservation',
            data: { reservationId: $(this).closest('tr').attr('data-reservation-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                $('#modal-container').html(response);
                $('#view-reservation-modal').modal('show');
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });
})