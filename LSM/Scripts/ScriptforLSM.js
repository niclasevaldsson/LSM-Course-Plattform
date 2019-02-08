

$(document).ready(function () {

    var tableCourseInfo = $("#tableCourseInfo");
    var tableSchedule = $("#tableSchedule");
    var buttonSchedule = $("#buttonSchedule");
    var buttonCourseInfo = $("#buttonCourseInfo");
    var tableModules = $("#tableModules");
    var tableStudents = $("#tableStudents");
    var buttonModulesInfo = $("#buttonModules");
    var buttonStudents = $("#buttonStudents");


    $('#message2').fadeIn('slow', function () {
        $('#message2').delay(3000).fadeOut('slow');
    });


    buttonCourseInfo.on("click", function () {
        Click(tableCourseInfo, tableSchedule, buttonSchedule, buttonCourseInfo);
    });

    buttonSchedule.on("click", function () {
        Click(tableSchedule, tableCourseInfo, buttonCourseInfo, buttonSchedule);
    });

    buttonModulesInfo.on("click", function () {
        Click(tableModules, tableStudents, buttonModulesInfo, buttonStudents);
    });

    buttonStudents.on("click", function () {
        Click(tableStudents, tableModules, buttonStudents, buttonModulesInfo);
    });


    function Click(tableShow, tableHide, buttonActive, buttonNonActive) {

        tableShow.show();
        tableHide.hide();
        buttonActive.addClass("active");
        buttonNonActive.removeClass("active");
    }

    $("#test").DataTable();


});