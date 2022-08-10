

////$(function () {

////    $('button[data-toggle="ajax-modal"]').click(function (event) {
////        var url = $(this.data('url'));
////        var PlaceHolder = $('#PlaceHolder');
////        $.get(url).done(function (data) {
////            PlaceHolder.html(data);
////            PlaceHolder.find('.modal').modal('show');

////        })

////    })
////})

$(function () {
    var PlaceHolder = $('#PlaceHolder');
    $('button[data-toggle="ajax-modal"]').click(function (event) {

        var url = $(this).data('url');
        // alert(url);


        $.get(url).done(function (data) {
            PlaceHolder.html(data);
            PlaceHolder.find('.modal').modal('show');

        })

    })
    
    PlaceHolder.on('click', '[data-save="modal"]', function (event) {
   // $('button[data-save="modal"]').click(function (event) {
        //alert('hello');
        var form = $(this).parents('.modal').find('form');
        var actUrl = form.attr('action');
        var data = form.serialize();
        $.post(actUrl, data).done(function (data) {
          //  alert(data);
            PlaceHolder.html(data);
            PlaceHolder.find('.modal').modal('show');
            //PlaceHolder.find('.modal').modal('hide');
            //PlaceHolder.fin
            //PlaceHolder.empty;
         //   PlaceHolder.html(data);

           // location.reload(true);

         //   PlaceHolder.find('.modal').modal('show');

        })

    })

})