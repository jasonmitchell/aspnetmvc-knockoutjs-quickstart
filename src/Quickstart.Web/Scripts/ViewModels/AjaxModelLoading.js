var AjaxModelLoading = function(url) {
    var self = this;
    self.isLoaded = ko.observable(false);
    self.isLoading = ko.observable(false);

    self.getRandomModel = function () {
        self.isLoading(true);
        self.isLoaded(false);

        // Setting a timeout so the loading text is visible in the sample
        setTimeout(function() {
            $.ajax(url, {
                type: "GET",
                cache: false,
            }).done(function(data) {
                ko.mapping.fromJS(data, {}, self);

                self.isLoaded(true);
                self.isLoading(false);
            });
        }, 1000);
    };
};