$(document).ready(function () {
    $('.btn-archive-reservation').click(function () {
        var sourceController = $(this).attr('data-source-controller');

        $.ajax({
            type: 'POST',
            url: 'Reservation/ArchiveReservation',
            data: { reservationId: $(this).closest('tr').attr('data-reservation-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                window.location.href = sourceController + '/Index';
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });
});

/* Steps to Replicate:
1. Create a Reservation
2. Archive the Reservation
3. Create a new Reservation with the same dates as previous one 
4. Save > Encounter error */