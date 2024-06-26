const btnToday = document.getElementById('btn-today');

function createCalendar() {
    const currentDate = new Date();
    const currentYear = currentDate.getFullYear();
    const currentMonth = currentDate.getMonth();

    const calendar = document.getElementById('calendar');
    calendar.innerHTML = '';

    const table = document.createElement('table');
    const thead = document.createElement('thead');
    const tbody = document.createElement('tbody');

    const weekdays = ['Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб', 'Вс'];
    const theadRow = document.createElement('tr');
    weekdays.forEach(weekday => {
        const th = document.createElement('th');
        th.textContent = weekday;
        theadRow.appendChild(th);
    });
    thead.appendChild(theadRow);

    let date = new Date(currentYear, currentMonth, 1);
    let day = date.getDay() || 7;
    while (date.getMonth() === currentMonth) {
        const tbodyRow = document.createElement('tr');
        for (let i = 1; i < day; i++) {
            const td = document.createElement('td');
            tbodyRow.appendChild(td);
        }
        while (day <= 7 && date.getMonth() === currentMonth) {
            const td = document.createElement('td');
            td.textContent = date.getDate();
            if (date.getDate() === currentDate.getDate() && date.getMonth() === currentDate.getMonth() && date.getFullYear() === currentDate.getFullYear()) {
                td.classList.add('current-date');
            }
            tbodyRow.appendChild(td);
            date.setDate(date.getDate() + 1);
            day++;
        }
        tbody.appendChild(tbodyRow);
        day = 1;
    }

    table.appendChild(thead);
    table.appendChild(tbody);
    calendar.appendChild(table);
}

function setActiveDay() {
    const calendarDays = document.querySelectorAll('.calendar__day.day span');

    const today = new Date().getDate();

    calendarDays.forEach(day => {
        day.classList.remove('active');
        if (Number(day.textContent) === today) {
            day.classList.add('active');
        }
    });
}

function getHomePage() {
    if (hasUnsavedData()) {
        if (confirm('Вы действительно хотите перейти? Несохраненные данные будут потеряны.')) {     // Toaster or Alertify ???
            window.location.href = '/';
            setActiveDay();
        }
    } else {
        window.location.href = '/';
        setActiveDay();
    }
}

function hasUnsavedData() {
    if (window.location.pathname === "/CalendarEvent/Create" || window.location.pathname === "/CalendarEvent/Edit") {
        const titleInput = document.getElementById('Name');
        const startDateInput = document.getElementById('StartDate');
        const endDateInput = document.getElementById('EndDate');
        const locationInput = document.getElementById('Location');
        const descriptionInput = document.getElementById('Description');

        return titleInput.value !== '' ||
            startDateInput.value !== '' ||
            endDateInput.value !== '' ||
            locationInput.value !== '' ||
            descriptionInput.value !== '';
    }
}

(function () {
    if (window.location.pathname === "/") {
        document.addEventListener('DOMContentLoaded', setActiveDay);
        createCalendar();
    }

    if (window.location.pathname === "/") {
        btnToday.addEventListener('click', setActiveDay);
    }
    else {
        btnToday.addEventListener('click', getHomePage);
    }
})();