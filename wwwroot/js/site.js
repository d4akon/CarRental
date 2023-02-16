window.onload = function () {
    const pickupDateInput = document.querySelector("#pickupDate");
    const returnDateInput = document.querySelector("#returnDate");

    const minDate = new Date();
    const maxDate = new Date();
    maxDate.setMonth(minDate.getMonth() + 3);

    const minDateString = minDate.toISOString().slice(0, 10);
    const maxDateString = maxDate.toISOString().slice(0, 10);

    // Return date
    const minReturnDate = new Date();
    const maxReturnDate = new Date();

    minReturnDate.setDate(maxDate.getDate() + 1);

    maxReturnDate.setDate(minReturnDate.getDate());
    maxReturnDate.setMonth(minReturnDate.getMonth() + 3);

    const minReturnDateString = minReturnDate.toISOString().slice(0, 10);
    const maxReturnDateString = maxReturnDate.toISOString().slice(0, 10);

    pickupDateInput.setAttribute("min", minDateString);
    pickupDateInput.setAttribute("max", maxDateString);

    returnDateInput.setAttribute("min", minReturnDateString);
    returnDateInput.setAttribute("max", maxReturnDateString);
}