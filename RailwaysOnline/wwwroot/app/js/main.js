$(document).ready(function() {
    filterJourneyAsync();
    addToCartAsync();
    showModal();
});

var showModal = function() {
    $('#cart-modal').on('show.bs.modal',
        function(event) {
            var button = $(event.relatedTarget); // Button that triggered the modal
            var journey = button.data('obj');
            var modal = $(this);
            modal.find('#journeyId').val(journey.id);
            modal.find('#journeyLoc').text('From ' + journey.fromCity + ' - To ' + journey.toCity);
            modal.find('#journeyTime').text('Departs at:' + toTime(journey.departureTime) + ' - Arrives at: ' + toTime(journey.arrivalTime));
            modal.find('select').prop('selectedIndex', 0);
            modal.find('input[type=number]').val(1);
            modal.find('.text-danger span').text('');
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
                        $('table').fadeIn('fast');
                    });
            }
            
        });
    
};
var addToCartAsync = function () {
    $('#cart-modal form').on('submit',
        function (e) {
            var button = $(this).find('button[type="submit"]');            
            e.preventDefault();
            if ($(this).valid()) {
                button.button('loading');
                $.post($(this).attr('action'),
                    $(this).serialize(),
                    function (data) {
                        console.log(data);
                        if (null === data || data === undefined) {
                            alert('error!');
                        } else if (false === data.result) {
                            alert(data.message);
                        } else {
                            $('#cart-modal').modal('hide');
                            $('#cart-summary').html(data);
                            $('.alert').slideDown().delay(3000).slideUp();
                        }
                        button.button('reset');

                    });
            }
        });
};
