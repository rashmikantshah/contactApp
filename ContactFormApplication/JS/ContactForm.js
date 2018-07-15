app.controller('contactController', ['$scope', '$http', function ($scope, $http) {
    $scope.loading = false;
    scope = $scope;

    $scope.clearForm = function () {
        $scope.contactForm = {
            status: 1
        };
    };
    $scope.clearForm();
    

    $scope.getContacts = function () {
        $http.get(url + '/api/contactController/')
            .then(function (response) {
                console.log("response");
                console.log(response);
                $scope.contactdetails = response.data;
            }, function (error) {
                $scope.error = "An Error has occured while loading posts!";
            });
    };
    $scope.getContacts();

    $scope.add = function () {
        console.log("$scope.contactForm : ");
        console.log($scope.contactForm);

        console.log("$scope.contactFrm ----------");
        console.log($scope.contactFrm);

        if ($scope.contactFrm.$valid) {
            $scope.loading = "Processing...";

            $http.post(url + '/api/contactController/', $scope.contactForm)
            .then(function (response) {
                console.log("response");
                console.log(response);
                $scope.contactdetails = response.data;
                $scope.clearForm();
                $scope.loading = false;
                $('#addModal').modal('show');

            }, function (error) {
                console.log("error");
                console.log(error);
                $scope.loading = false;
            });

        } else {
            alert("Enter all required fields...");
        }
        
    };

 
   
    $scope.edit = function (data) {
        console.log("data to update");
        console.log(data);
       
        var obj = {};
        for (var key in data) {
            obj[key] = data[key];
        };
        $scope.contactForm = obj;
    };

    $scope.obj = {};

    $scope.changeStatus = function (data, status) {
        //console.log(data,status);
        //for (var key in data) {
        //    $scope.obj[key] = data[key];
        //};
        //$scope.obj.status = status;
        //console.log($scope.obj);
        //$('#CommonModal').modal('show');

        $scope.contactForm = data;
        $scope.contactForm.status = status;
        $scope.update(true);
    };

    $scope.update = function (data) {
        
        if ($scope.contactFrm.$valid || data) {
            //if (data) {
            //    $scope.contactForm = obj;
            //}

            $scope.loading = "Processing...";
            console.log("Updated Data : ");
            console.log($scope.contactForm);
            $http.put(url + '/api/contactController/', $scope.contactForm)
                .then(function (response) {
                    $scope.contactdetails = response.data;
                    $scope.clearForm();
                    $scope.loading = false;
                    $('#CommonUpdateModal').modal('show');

                    if (data) {
                        $scope.obj = null;
                    }
                }, function (error) {
                    $scope.loading = false;
                    $scope.error = "An Error has occured while Updating contact detail! " + error;
                });
        } else {
            alert("Enter all required field...")
        }
    };

    $scope.delete = function (id) {
        
        $http.delete(url + '/api/contactController/' + id)
            .then(function (response) {
                $scope.contactdetails = response.data;
                $('#deleteModal').modal('show');
            }, function (error) {
                $scope.error = "An Error has occured while Delete contact detail! " + error;
            });
    };
    
    $scope.yesContact = function () {
        console.log("Yes Update contact...");
        $scope.update($scope.obj);
        //$('#CommonUpdateModal').modal('show');
    };

    $scope.noContact = function () {
        $('#CommonModal').modal('hide');
    }

}]);

