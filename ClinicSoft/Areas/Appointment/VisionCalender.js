var Calendar = function () {

    var setFullCalendarEvents = function () {

        var resource_data = function () {

            var result;
            $.ajax({
                url: '@Url.Action("GetDoctors", new { area = "Appointment" })?docId=' + localStorage.getItem("selected_doctors") + '&setId=1',  //"Handler/GetDoctors.ashx?docId=" + localStorage.getItem("selected_doctors") + "&setId=1",// + $("#hi_branch_selected").val(),
                type: "GET",
                dataType: "json",
                async: false,
                success: function (response) {
                    result = response;
                    //console.log(response);
                },
                error: function (xhr) {
                    console.log(xhr);
                    alert(xhr);
                }
            });
            return result;
        };

        var appointment_data = function () {
            var result;
            $.ajax({
                url: '@Url.Action("GetAppointments", new { area = "Appointment" })',
                type: "GET",
                dataType: "json",
                async: false,
                success: function (response) {
                    result = response
                    //console.log(response);
                },
                error: function (xhr) {
                    console.log(xhr);
                    alert(xhr);
                }
            });
            return result;
        };


        var calendarEl = document.getElementById('calendar');

        var calendar = new FullCalendar.Calendar(calendarEl, {
            initialView: localStorage.getItem("initial_view"),
            initialDate: $('#dt_select').val(),
            editable: true,
            selectable: true,
            dayMaxEvents: true, // allow "more" link when too many events
            dayMinWidth: 200,
            slotDuration: '00:15',
            //slotLabelInterval: 15,
            slotMinTime: '09:00',
            slotMaxTime: '23:30',
            headerToolbar: {
                left: 'prev,next today',
                center: 'title',
                right: 'resourceTimeGridDay,resourceTimeGridTwoDay,resourceTimeGridThreeDay,timeGridWeek,resourceTimeGridWeek,dayGridMonth'
            },
            views: {
                resourceTimeGridDay: {
                    buttonText: 'Day',
                },
                resourceTimeGridTwoDay: {
                    type: 'resourceTimeGrid',
                    duration: { days: 2 },
                    buttonText: '2 Days',
                },
                resourceTimeGridThreeDay: {
                    type: 'resourceTimeGrid',
                    duration: { days: 3 },
                    buttonText: '3 Days',
                },
                timeGridWeek: {
                    buttonText: 'Week',
                },
                resourceTimeGridWeek: {
                    buttonText: 'Week & Doctors',
                },
                dayGridMonth: {
                    buttonText: 'Month',
                }
            },
            height: 'auto',
            //// uncomment this line to hide the all-day slot
            allDaySlot: false,
            displayEventTime: false,
            resources: resource_data(),
            resourceOrder: 'emp_rank',
            events: appointment_data(),

            select: function (arg) {
                localStorage.setItem("initial_view", arg.view.type);
                console.log(arg.view.type);
            },
            dateClick: function (arg) {
                localStorage.setItem("initial_view", arg.view.type);

                //console.log(
                //    'dateClick',
                //    arg.date,
                //    arg.resource ? arg.resource.id : '(no resource)'
                //);
            },

            eventClick: function (info) {
                localStorage.setItem("initial_view", info.view.type);
                console.log($("#app_doctor").val());
                console.log(info.event); 
            },
            eventDrop: function (info) {
                localStorage.setItem("initial_view", info.view.type);
            },
            eventResize: function (info) {
                localStorage.setItem("initial_view", info.view.type);
            }
        });
        calendar.render();

        $('#dt_select').change(function () {
            calendar.gotoDate($(this).val());
        });

    }


    return {
        init: function () {
            setFullCalendarEvents();
        }
    };
}();