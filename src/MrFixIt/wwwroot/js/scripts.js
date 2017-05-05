$(document).ready(function () {
//    $(".click-claim").click(function () {
//        $.ajax({
//            type: 'POST',
//            dataType: 'html',
//            url: 'Jobs/Claim/' + this.JobId,
//            success: function (result) {
//                console.log(this.JobId);
//                var resultMessage = 'It worked!';
//                $('#results').html(resultMessage);
//            }
//        });
    //    });

    //$(".completed").submit(function () {
    //    $.ajax({
    //        type: 'POST',
    //        url: 'JOBS/' 
    //    })
    //})

    $('.completed').click(function () {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: 'Jobs/Completed',
            success: function (result) {
                $('#result1').html(result);
            }
        });
    });

});