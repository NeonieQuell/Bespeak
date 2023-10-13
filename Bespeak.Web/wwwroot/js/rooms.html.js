$(document).ready(function() {
    $('.nav-link').on('click', function() {
        $('#header').html($(this).text());
    });

    $('#all-rooms-tbl').DataTable();
    $('#room-types-tbl').DataTable();
});