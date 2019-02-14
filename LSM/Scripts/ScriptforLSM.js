

$(document).ready(function () {

    const tableCourseInfo = $("#tableCourseInfo");
    const tableSchedule = $("#tableSchedule");
    const buttonSchedule = $("#buttonSchedule");
    const buttonCourseInfo = $("#buttonCourseInfo");
    const tableModules = $("#tableModules");
    const tableStudents = $("#tableStudents");
    const buttonModulesInfo = $("#buttonModules");
    const buttonStudents = $("#buttonStudents");


    $('#message').fadeIn('slow', function () {
        $('#message').delay(3000).fadeOut('slow');
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




});