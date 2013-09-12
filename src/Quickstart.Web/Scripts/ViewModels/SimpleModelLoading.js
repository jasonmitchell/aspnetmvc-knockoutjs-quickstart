var SimpleModelLoading = function (data) {
    var self = this;

    self.firstName = ko.observable(data.firstName);
    self.lastName = ko.observable(data.lastName);
    self.emailAddress = ko.observable(data.emailAddress);
    self.phoneNumber = ko.observable(data.phoneNumber);
    self.dateOfBirth = ko.observable(data.dateOfBirth);
};