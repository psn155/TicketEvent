//Encapsulates data calls to server using AJAX
//This script follows Revealing Prototype pattern

//constructor
var DataService = function () {
    this.serviceBaseUrl = '/api/Events/';
};

//prototype
DataService.prototype = function () {
    //private members
    var
        getEvents = function (callback) {
            $.getJSON(this.serviceBaseUrl, function (data) {
                callback(data);
            });
        },

        getEvent = function (id, callback) {
            $.getJSON(this.serviceBaseUrl + id, function (data) {
                callback(data);
            });
        },
        
        updateEvent = function (event, callback) {
            $.ajax(this.serviceBaseUrl + event.Id, {
                type: "PUT",
                data: event
            }).done(callback);
        },

        createEvent = function (event, callback) {
            $.ajax(this.serviceBaseUrl, {
                type: "POST",
                data: event
            }).done(callback);
        },

        deleteEvent = function (id, callback) {
            $.ajax(this.serviceBaseUrl + id, {
                type: "DELETE"
            }).done(callback);
        };
    
    //public members
    return {
        getEvents: getEvents,
        getEvent: getEvent,
        updateEvent: updateEvent,
        createEvent: createEvent,
        deleteEvent: deleteEvent
    };
}();