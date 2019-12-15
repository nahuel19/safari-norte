function fancy() {

    $(document).ready(function () {
        $("#iframe").fancybox({
            type: 'iframe',
            afterClose: function () { window.location.reload(); },
        });
    });

}