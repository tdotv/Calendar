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

createCalendar();

const btnToday = document.getElementById('btn-today');

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

document.addEventListener('DOMContentLoaded', setActiveDay);
btnToday.addEventListener('click', setActiveDay);