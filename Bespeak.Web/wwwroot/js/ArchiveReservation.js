$(document).ready(function () {
    $(document).on('click', '.btn-archive-reservation', function () {
        var baseUrl = window.location.origin;
        var controller = $(this).attr('data-controller');

        $.ajax({
            type: 'POST',
            url: baseUrl + '/Reservation/ArchiveReservation',
            cache: false,
            dataType: 'JSON',
            data: { reservationId: $(this).closest('tr').attr('data-reservation-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                var redirectUrl = baseUrl + '/' + controller;
                window.location.href = redirectUrl
            },
            error: function () {
                swalErrorDefault();
            }
        });
    })
});
