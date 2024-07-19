const btnToday = document.getElementById('btn-today');
const eventCards = document.querySelectorAll('.event-card');
const dateBlock = document.querySelector('.chosen-date h3');

const options = { weekday: 'short', month: 'long', day: 'numeric', year: 'numeric' };
const currentDate = new Date();
const formattedDate = currentDate.toLocaleDateString('ru-RU', options);

function setActiveDay() {
    const calendarDays = document.querySelectorAll('.calendar__day.day span');

    const today = new Date().getDate();
    const currentMonth = currentDate.getMonth();

    calendarDays.forEach(day => {
        day.classList.remove('active');

        // Тут есть баг, что предыдудщего месяца тоже выделяется
        // Он решается путем создания динамичского календаря, а не статического (как в данный момент написания функции)
        if (Number(day.textContent) === today && currentDate.getMonth() === currentMonth) {
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

// Есть ли лучшее решение?
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

// Здесь он просто получает текущую дату, но это не соответствует изначальным целям при проектировании
// Пользователь должен выбирать дату, она меняется в .chosen-date и отображает какие events созданы для этой даты
// Также решается путем добавления БД и бизнес-логики
function getCurrentDate() {
    const dateBlock = document.querySelector('.chosen-date h3');
    if (dateBlock) {
        dateBlock.textContent = formattedDate;
    } else {
        console.error('Не удалось найти элемент с классом .chosen-date h3');
    }
}

(function () {
    if (window.location.pathname === "/") {
        document.addEventListener('DOMContentLoaded', setActiveDay);
        getCurrentDate();
    }

    if (window.location.pathname === "/") {
        btnToday.addEventListener('click', setActiveDay);
    }
    else {
        btnToday.addEventListener('click', getHomePage);
    }
})();