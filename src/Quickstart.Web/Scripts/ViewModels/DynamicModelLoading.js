var DynamicModelLoading = function(data) {
    var self = this;
    ko.mapping.fromJS(data, {}, self);

    self.displayFullName = function(model) {
        var fullName = model.firstName() + " " + model.lastName();
        alert(fullName);
    };
};