
//Jede Checkbox wird ausgewählt und die Summe der Stunden wird berechnet
document.getElementById("selectAll").addEventListener("change", function () {
    var checkboxes = document.querySelectorAll(".dateCheckbox");
    for (var i = 0; i < checkboxes.length; i++) {
        checkboxes[i].checked = this.checked;
    }

    var totalTime = calculateTotalTime();
    document.getElementById('timeDisplay').innerText = totalTime;

});

//um durch die SelectAll checkbox alle anderen ebenfalls abzuwählen
function uncheckSelectAll(element) {
    if (!element.checked) {
        document.getElementById("selectAll").checked = false;
    }
}

//berechnung der Summe der ausgewählten Stunden. Da die Stunden als String übergeben muss erstmal umgeformt werden
function calculateTotalTime() {
    var checkboxes = document.querySelectorAll('.dateCheckbox:checked');

    var totalTimeMinutes = 0; 

    checkboxes.forEach(function (checkbox) {
        var time = checkbox.getAttribute('data-time');
        var parts = time.split(':'); 
        var hours = parseInt(parts[0], 10);
        var minutes = parseInt(parts[1], 10);

        totalTimeMinutes += (hours * 60) + minutes; 
    });

  
    var totalHours = Math.floor(totalTimeMinutes / 60);
    var remainingMinutes = totalTimeMinutes % 60;

    return totalHours + ":" + (remainingMinutes < 10 ? "0" : "") + remainingMinutes;
}

var totalTime = calculateTotalTime();
document.getElementById('timeDisplay').innerText = totalTime;

//weitergabe von der Summe der Stunden an "timeDisplay" bei jedem klicken auf eine checkbox.
//anders als zuvor ist diese funktion dafür da wenn man händisch die checkbox auswählt und nicht alle mit selectAll auswählt
document.querySelectorAll('.dateCheckbox').forEach(function (checkbox) {
    checkbox.addEventListener('change', function () {
        var totalTime = calculateTotalTime();
        document.getElementById('timeDisplay').innerText = totalTime;
    });
});