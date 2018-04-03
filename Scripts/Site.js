function isNumeric(value) {
    if (value == null || !value.toString().match(/^[-]?\d*\.?\d*$/)) return false;
    return true;
}

function deleteQuestOption(e) {
    //alert($(e).attr('name'));
    var st = confirm("Are you sure you want perform this action?");

    if (st) {
        $.ajax({
            type: "POST",
            url: "QuestionOptions.aspx/deleteQuestOption", //?zd=" + $(e).attr('id'),
            data: "{ 'id': '" + $(e).attr('id') + "' }", //,'qid':'" + $(e).attr('name') + "'
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                // Replace the div's content with the page method's return.
                if (data == 'success') {
                    alert('Option Deleted.');
                    location.href = "QuestionOptions.aspx?z=" + $(e).attr('name');
                } else {
                    alert(data);
                }
            }
        });

    }
}



function deleteQuest(e) {
    //alert($(e).attr('id'));
    var st = confirm("Are you sure you want perform this action?");

    if (st) {
        $.ajax({
            type: "POST",
            url: "QuestionsList.aspx/deleteQuest", //?zd=" + $(e).attr('id'),
            data: "{ 'id': '" + $(e).attr('id') + "' }", //,'qid':'" + $(e).attr('name') + "'
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                // Replace the div's content with the page method's return.
                if (data == 'success') {
                    alert('Question Deleted.');
                    location.href = "QuestionsList.aspx";
                } else {
                    alert(data);
                }
            }
        });

    }
}

function SwitchCandidateActivity(e) {
    //alert($(e).attr('id'));
    var st = confirm("Are you sure you want perform this action?");

    if (st) {
        $.ajax({
            type: "POST",
            url: "Candidate.aspx/SwitchCandidateActivity", //?zd=" + $(e).attr('id'),
            data: "{ 'id': '" + $(e).attr('id') + "' }", //,'qid':'" + $(e).attr('name') + "'
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                // Replace the div's content with the page method's return.
                if (data == 'success') {
                    alert('Status Changed.');
                    location.href = "Candidate.aspx";
                } else {
                    alert(data);
                }
            }
        });

    }
}

function SwitchCandidateActivity2(e) {
    //alert($(e).attr('id'));
    var st = confirm("Are you sure you want perform this action?");

    if (st) {
        $.ajax({
            type: "POST",
            url: "CandidateSearch.aspx/SwitchCandidateActivity", //?zd=" + $(e).attr('id'),
            data: "{ 'id': '" + $(e).attr('id') + "' }", //,'qid':'" + $(e).attr('name') + "'
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                // Replace the div's content with the page method's return.
                if (data == 'success') {
                    alert('Status Changed.');
                    location.href = "CandidateSearch.aspx";
                } else {
                    alert(data);
                }
            }
        });

    }
}

function SwitchQuestionActivity(e) {
    //alert($(e).attr('id'));
    var st = confirm("Are you sure you want perform this action?");

    if (st) {
        $.ajax({
            type: "POST",
            url: "QuestionsList.aspx/SwitchQuestionActivity", //?zd=" + $(e).attr('id'),
            data: "{ 'id': '" + $(e).attr('id') + "' }", //,'qid':'" + $(e).attr('name') + "'
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                // Replace the div's content with the page method's return.
                if (data == 'success') {
                    alert('Status Changed.');
                    location.href = "QuestionsList.aspx";
                } else {
                    alert(data);
                }
            }
        });

    }
}
function SwitchBatchActivity(e) {
    alert($(e).attr('id'));
    var st = confirm("Are you sure you want perform this action1?");

    if (st) {
        $.ajax({
            type: "POST",
            url: "Batches.aspx/SwitchBatchActivity", //?zd=" + $(e).attr('id'),
            data: "{ 'id': '" + $(e).attr('id') + "' }", //,'qid':'" + $(e).attr('name') + "'
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                // Replace the div's content with the page method's return.
                if (data == 'success') {
                    alert('Status Changed.');
                    location.href = "Batches.aspx";
                } else {
                    alert(data);
                }
            }
        });

    }
}
function SwitchEssayActivity(e) {
    //alert($(e).attr('id'));
    var st = confirm("Are you sure you want perform this action?");

    if (st) {
        $.ajax({
            type: "POST",
            url: "EssayQuestions.aspx/SwitchEssayActivity", //?zd=" + $(e).attr('id'),
            data: "{ 'id': '" + $(e).attr('id') + "' }", //,'qid':'" + $(e).attr('name') + "'
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                // Replace the div's content with the page method's return.
                if (data == 'success') {
                    alert('Status Changed.');
                    location.href = "EssayQuestions.aspx";
                } else {
                    alert(data);
                }
            }
        });

    }
}


Array.max = function (array) {
    return Math.max.apply(Math, array);
};

Array.min = function (array) {
    return Math.min.apply(Math, array);
}


