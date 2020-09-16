

function GenerateTransaction()
{

    var ammount = $("#ammount").val();
    var type = $("#type").val();
    $.ajax({
        url: '/Home/GenerateTransaction',
        type: 'POST',
        success: function (e)
        {
            if (e.result == true)
            {
                $("msgOk").show();
                $("msgBad").hide();
            }
            if (e.result == false)
            {
                $("msgOk").hide();
                $("msgBad").show();
            }
        },
        data: {ammount,type}
    });
}