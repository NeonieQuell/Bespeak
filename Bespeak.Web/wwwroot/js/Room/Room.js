$(document).ready(function () {
    // Data tables
    $('#all-rooms-tbl').DataTable();
    $('#room-types-tbl').DataTable();

    // Change header on tab click
    $('.nav-link').click(function () {
        $('#header').html($(this).text());
    });

    // Submit for new room
    $('#form-create-room').submit(function (e) {
        e.preventDefault();

        var formData = new FormData($(this)[0]);

        $.ajax({
            type: 'POST',
            url: 'Room/CreateRoom',
            cache: false,
            processData: false,
            contentType: false,
            dataType: 'JSON',
            data: formData,
            beforeSend: function () {
                $('#create-room-modal').modal('hide');
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

    // Load edit room modal
    /*$('.btn-edit-room').click(function () {
        $.ajax({
            type: 'GET',
            url: 'Room/EditRoom',
            data: { roomId: $(this).closest('tr').attr('data-room-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                $('#modal-container').html(response);
                $('#edit-room-modal').modal('show');
            }
        });
    });*/
});