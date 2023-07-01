$(function () {
    var countdownElement = $('.product-countdown');
    var remainingTime = parseInt(countdownElement.data('until'));

    function updateCountdown() {
        var days = Math.floor(remainingTime / (24 * 60 * 60));
        var hours = Math.floor((remainingTime % (24 * 60 * 60)) / (60 * 60));
        var minutes = Math.floor((remainingTime % (60 * 60)) / 60);
        var seconds = Math.floor(remainingTime % 60);
        var formattedTime = days + ':' + hours + ':' + minutes + ':' + seconds;

        $('#countdownTimer').text(formattedTime);

        if (remainingTime > 0) {
            remainingTime--;
            setTimeout(updateCountdown, 1000); // Update countdown every second
        }
    }

    updateCountdown();
});