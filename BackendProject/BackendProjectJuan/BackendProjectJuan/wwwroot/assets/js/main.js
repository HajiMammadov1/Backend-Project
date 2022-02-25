$(document).ready(function () {
    $(document).on("click", "#open-modal", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        console.log("click");

        fetch(url)
            .then(response => response.text())
            .then(data => {

                $(".modal-dialog").html(data)

                console.log(data)
            });

        $("#quick_view").modal(true)

    })

    $(document).on("click", ".addToBasket", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

        fetch(url)
            .then(function (response) {
                if (response.ok) {
                    
                    toastr["success"]("Product was added to the cart");
                }
                else {

                    toastr["success"]("Product could not be added to the cart")
                }

                return response.text()
            }).then(data => {
                $(".minicart-content-box").html(data)
            });
    })

})