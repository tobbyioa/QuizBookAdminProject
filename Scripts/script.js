$(function () {


    var time = $.trim($("#<%=minutes.ClientID %>").val());
    var ts = getDateFromFormat(time, "M/d/yyyy hh:mm:ss a");
    var note = $('#note');
    if ((new Date()) > ts) {
        // The ticket's TAT has been esceeded.
        return;
    }
    //            var substr = time.split(',');
    //            var min = "";
    //            var secs = "";
    //            if (substr.length == 1) {
    //                min = substr[0];
    //                secs = 0;
    //            } else {

    //                min = substr[0];
    //                secs = substr[1];
    //            }
    //            var note = $('#note'),
    //		ts = addTime(min, secs), //new Date(2012, 0, 1),new Date(today.get, 0, 1)
    //		newYear = false;

    //            if ((new Date()) > ts) {
    //                // The new year is here! Count towards something else.
    //                // Notice the *1000 at the end - time must be in milliseconds
    //                ts = (new Date()).getTime() + 10 * 24 * 60 * 60 * 1000;
    //                newYear = false;
    //    }

    $('#countdown').countdown({
        timestamp: ts,
        callback: function (days, hours, minutes, seconds) {

            var message = "You have ";

            message += days + " day" + (days == 1 ? '' : 's') + ", ";
            message += hours + " hour" + (hours == 1 ? '' : 's') + ", ";
            message += minutes + " minute" + (minutes == 1 ? '' : 's') + " and ";
            message += seconds + " second" + (seconds == 1 ? '' : 's') + " <br />";

            //                    if (newYear) {
            //                        message += "left until the new year!";
            //                        
            //                    }
            //                    else {
            //				message += "left to 10 days from now!";
            message += "left for this test";
            //   }

            //                    var minutes = ((days * 24 * 60) + (hours * 60) + minutes);
            //                    var st = minutes + "," + seconds;
            ////                    $("#minutes").html(st);
            //                    $("#").val(st);
            note.html(message);

            if (days == 0 && hours == 0 && minutes == 0 && seconds == 0) {
                location.href = "CandidateSearch.aspx";
            }

        }
    });

});

function addTime(min, sec) {
    var format = "dd/MM/yyyy HH:mm:ss";
    var date1 = new Date();
    // var date2 = f.elements['date2'];
    //            if (f.y.value > 0 || f.y.value < 0) {
    //                date1.add('y', f.y.value);
    //            }
    //            if (f.M.value > 0 || f.M.value < 0) {
    //                date1.add('M', f.M.value);
    //            }
    //            if (f.d.value > 0 || f.d.value < 0) {
    //                date1.add('d', f.d.value);
    //            }
    //            if (f.w.value > 0 || f.w.value < 0) {
    //                date1.add('w', f.w.value);
    //            }
    //            if (f.h.value > 0 || f.h.value < 0) {
    //                date1.add('h', f.h.value);
    //            }
    if (min > 0 || min < 0) {
        date1.add('m', min);
    }
    if (sec > 0 || sec < 0) {
        date1.add('s', sec);
    }
    //            date2.value = date1.format(format);
    return date1;
}
