function ProductViewModel() {
    var self = this;
    self.categoryName = ko.observable();
    self.productID = ko.observable();
    self.productName = ko.observable();
    self.unitPrice = ko.observable(1);
    self.quantity = ko.observable(1);
    self.ProductList = ko.observableArray();
    self.totalPrice = ko.computed(function () {
        return self.quantity() * self.unitPrice();
    });
    self.getAll = function () {
        $.getJSON('ReturnProducts', function (data) {
            self.ProductList(data);
                    
            
            $("#Products_Table").DataTable();
            
            
            $('#loading').css('display', 'none')



        });
    }



    self.SelectProduct = function (product) {
        self.categoryName(product.CategoryName);
        self.productID(product.ProductID);
        self.productName(product.ProductName);
        self.quantity(1);
        self.unitPrice(product.UnitPrice);

    };

    
    }

