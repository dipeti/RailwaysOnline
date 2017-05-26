$(document).ready(function() {
    filterJourneyAsync();
    addToCartAsync();
    showModal();
});

var showModal = function() {
    $('#cart-form').on('show.bs.modal',
        function(event) {
            var button = $(event.relatedTarget) // Button that triggered the modal
            var journey = button.data('obj');
            var modal = $(this);
            modal.find('#journeyId').val(journey.id);
            modal.find('#journeyLoc').text('From ' + journey.fromCity + ' - To ' + journey.toCity);
            modal.find('#journeyTime').text('Departs at:' + toTime(journey.departureTime) + ' - Arrives at: ' + toTime(journey.arrivalTime));
        });
};
var toTime = function(time) {
    var date = new Date(time);
   return date.toLocaleTimeString();
}



var filterJourneyAsync = function() {
    $('#filter-form').on('submit',
        function(e) {
            e.preventDefault();
            if ($(this).valid()) {
                $.post($(this).attr('action'),
                    $(this).serialize(),
                    function(data) {
                        $('table').fadeOut('fast',
                            function() {
                                $('table tbody').html(data);
                            });
                        $('table').fadeIn('fast', function(){
                                addToCartAsync();
                            });
                    });
            }
            
        });
    
};
var addToCartAsync = function () {
    $('#cart-form form').on('submit',
        function (e) {
            console.log($(this));
            e.preventDefault();
                $.post($(this).attr('action'),
                    $(this).serialize(),
                    function (data) {
                        if (null === data || data === undefined) {
                            alert('error!');
                        } else {
                            alert(data + 'successfully added to the cart!');
                        }
                    });
        });
};
