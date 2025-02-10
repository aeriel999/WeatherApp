document.addEventListener('DOMContentLoaded', function () {
    window.scrollForecast = (element, amount) => {
        element.scrollBy({ left: amount, behavior: 'smooth' });
    };
});
