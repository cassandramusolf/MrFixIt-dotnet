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
            type: 'POST',
            dataType: 'json',
            url: 'Jobs/Completed/',
            success: function (result) {
                $('#result1').html(result);
            }
        });
    });

    $('.edit-form').click(function (event) {
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: '/Jobs/Edit/' + this.value,
            success: function (result) {
                console.log(this.value);
                $('.return-edit').html(result);
            }
        });
    });

    $('.edit-cupcake').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: 'Jobs/Edit',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                var editedJob = result.name;
                var jobId = result.id.toString();
                $('#result1').text(editedJob);
            }
        });
    });

});