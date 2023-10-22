$(document).ready(function () {
    // Load edit booking modal
    $('.btn-edit-booking').click(function () {
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
                $('#eb-modal').modal('show');
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

    $(document).on('submit', '#form-eb', function (e) {
        e.preventDefault();

        var formData = new FormData($('#form-eb')[0]);

        $.ajax({
            type: 'post',
            url: 'bookings/updatebooking',
            cache: false,
            contentType: false,
            processData: false,
            dataType: 'json',
            data: formData,
            beforeSend: function () {
                $('#eb-modal').modal('hide');
                swalInfoWait();
            },
            success: function (response) {
                swalSuccess(response.text);
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });
});