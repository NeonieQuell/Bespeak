$(document).ready(function () {
    $('#all-rooms-tbl').DataTable();

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

    $('.btn-view-room').click(function () {
        $.ajax({
            type: 'GET',
            url: 'Room/ViewRoom',
            data: { roomId: $(this).closest('tr').attr('data-room-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                $('#modal-container').html(response);
                $('#view-room-modal').modal('show');
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });

    $('.btn-edit-room').click(function () {
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
    });
});