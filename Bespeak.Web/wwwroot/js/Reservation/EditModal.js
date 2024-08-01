$(document).ready(function () {
    // Load edit reservation modal
    $('.btn-edit-reservation').click(function () {
        $.ajax({
            type: 'GET',
            url: 'Reservation/EditReservation',
            data: { reservationId: $(this).closest('tr').attr('data-reservation-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                $('#modal-container').html(response);
                $('#edit-reservation-modal').modal('show');
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });

    // Change input value of room type and floor number
    $(document).on('change', '#form-edit-reservation-room-id', function () {
        const roomType = $(this).find('option:selected').attr('data-room-type');
        const floorNum = $(this).find('option:selected').attr('data-floor-num');
        $('#form-edit-reservation-room-type').val(roomType);
        $('#form-edit-reservation-floor-num').val(floorNum);
    });

    // Start date validation for #form-edit-reservation
    $(document).on('click', '#form-edit-reservation-start-date', function () {
        $(this).attr('min', currentDate);

        if ($('#form-edit-reservation-end-date').val()) {
            $(this).attr('max', $('#form-edit-reservation-end-date').val());
        }
    });

    // End date validation for #form-edit-reservation
    $(document).on('click', '#form-edit-reservation-end-date', function () {
        $(this).attr('min', $('#form-edit-reservation-start-date').val());

        if (currentDate > $(this).val()) {
            $(this).attr('max', $(this).val());
        }
    });

    $(document).on('submit', '#form-edit-reservation', function (e) {
        e.preventDefault();

        var formData = new FormData($('#form-edit-reservation')[0]);

        $.ajax({
            type: 'POST',
            url: 'Reservation/UpdateReservation',
            cache: false,
            contentType: false,
            processData: false,
            dataType: 'JSON',
            data: formData,
            beforeSend: function () {
                $('#edit-reservation-modal').modal('hide');
                swalInfoWait();
            },
            success: function (response) {
                swalSuccessCustom(response.text);
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });
});