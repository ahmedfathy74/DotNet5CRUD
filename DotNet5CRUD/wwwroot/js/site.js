
$('body').delegate('.js-delete', 'click', function(){
                var btn = $(this);
    //console.log(btn.data('id'));
    //var result = confirm('Are you sure that you need to delete this movie?');

    bootbox.confirm({
        message: 'Are you sure that you need to delete this movie?',
    buttons: {
        confirm: {
        label: 'Yes',
    className: 'btn-danger'
                        },
    cancel: {
        label: 'No',
    className: 'btn-outline-secondary'
                        }
                    },
    callback: function (result) {
                        if (result) {
        $.ajax({
            url: '/movies/delete/' + btn.data('id'),
            success: function () {
                //btn.parents('.col-12').fadeOut();
                var movieContainer = btn.parents('.col-12');
                movieContainer.addClass('animate__animated animate__zoomOut');

                setTimeout(function () {
                    movieContainer.remove();
                }, 1000);

                toastr.success('Movies deleted');
            },
            error: function () {
                toastr.error('Something went Wrong!');
            }
        });
                        }
                    }
                });
    });
