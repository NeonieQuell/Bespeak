$(document).ready(function () {
    $('#form-create-room-type').submit(function (e) {
        e.preventDefault();

        var formData = new FormData($(this)[0]);

        $.ajax({
            type: 'POST',
            url: 'Room/CreateRoomType',
            cache: false,
            processData: false,
            contentType: false,
            dataType: 'JSON',
            data: formData,
            beforeSend: function () {
                $('#create-room-type-modal').modal('hide');
                swalInfoWait();
            },
            success: function (response) {
                if (response.result) {
                    swalSuccessCustom(response.text);
                } else {
                    swalErrorCustom(response.text);
                }
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });

    $('.btn-view-room-type').click(function () {
        $.ajax({
            type: 'GET',
            url: 'Room/ViewRoomType',
            data: { roomTypeId: $(this).closest('tr').attr('data-room-type-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                $('#modal-container').html(response);
                $('#view-room-type-modal').modal('show');
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });

    $('.btn-edit-room-type').click(function () {
        $.ajax({
            type: 'GET',
            url: 'Room/EditRoomType',
            data: { roomTypeId: $(this).closest('tr').attr('data-room-type-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                $('#modal-container').html(response);
                $('#edit-room-type-modal').modal('show');
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });

    $(document).on('submit', '#form-edit-room-type', function (e) {
        e.preventDefault();

        var formData = new FormData($(this)[0]);

        $.ajax({
            type: 'PUT',
            url: 'Room/UpdateRoomType',
            cache: false,
            processData: false,
            contentType: false,
            dataType: 'JSON',
            data: formData,
            beforeSend: function () {
                $('#edit-room-type-modal').modal('hide');
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                swalSuccessDefault();
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });

    $('.btn-delete-room-type').click(function () {
        $.ajax({
            type: 'DELETE',
            url: 'Room/DeleteRoomType',
            data: { roomTypeId: $(this).closest('tr').attr('data-room-type-id') },
            beforeSend: function () {
                swalInfoWait();
            },
            success: function (response) {
                Swal.close();
                swalSuccessDefault();
            },
            error: function () {
                swalErrorDefault();
            }
        });
    });
});