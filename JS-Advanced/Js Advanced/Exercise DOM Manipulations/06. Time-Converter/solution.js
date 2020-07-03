function attachEventsListeners() {
    document.getElementById("daysBtn").addEventListener("click", function () {
        const daysValue = Number(document.getElementById("days").value);
        document.getElementById("hours").value = daysValue * 24;
        document.getElementById("minutes").value = daysValue * 1440;
        document.getElementById("seconds").value = daysValue * 86400;
    });

    document.getElementById("hoursBtn").addEventListener("click", function () {
        const hoursValue = Number(document.getElementById("hours").value);
        document.getElementById("days").value = hoursValue / 24;
        document.getElementById("minutes").value = hoursValue * 60;
        document.getElementById("seconds").value = hoursValue * 60 * 60;
    });

    document.getElementById("minutesBtn").addEventListener("click", function () {
        const minutesValue = Number(document.getElementById("minutes").value);
        document.getElementById("days").value = minutesValue / 60 / 24;
        document.getElementById("hours").value = minutesValue / 60;
        document.getElementById("seconds").value = minutesValue * 60;
    });

    document.getElementById("secondsBtn").addEventListener("click", function () {
        const secondsValue = Number(document.getElementById("seconds").value);
        document.getElementById("days").value = secondsValue / 60 / 60 / 24;
        document.getElementById("hours").value = secondsValue / 60 / 60;
        document.getElementById("minutes").value = secondsValue / 60;
    });
}