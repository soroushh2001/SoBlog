function SubmitPostForm() {
    $("#filter_form").submit();
}

const swalWithBootstrapButtons = Swal.mixin({
    customClass: {
        confirmButton: "btn btn-success",
        cancelButton: "btn btn-danger"
    },
    buttonsStyling: true
});

function unPublishedPost(postId) {
    swalWithBootstrapButtons.fire({
        text: "آیا از لغو انتشار این پست مطمئن هستید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر",
        reverseButtons: true
    })
        .then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: "/admin/unpublished-post",
                    type: "get",
                    data: {
                        postId: postId
                    },
                    beforeSend: function () {
                        startLoading();
                    },
                    success: function (response) {
                        closeLoading();
                        if (response.status === "success") {
                            swal.fire("موفق", "عملیات با موفقیت انجام شد", "success");
                            $("#tbl-posts").load(location.href + " #tbl-posts");
                        } else {
                            swal.fire("خطا", "عملیات شکست خورد", "error");
                        }
                    },
                    error: function () {
                        closeLoading();
                    }
                });
            }
        });
}

function publishedPost(postId) {
    swalWithBootstrapButtons.fire({
        text: "آیا از انتشار این پست مطمئن هستید؟",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "بله",
        cancelButtonText: "خیر",
        reverseButtons: true
    })
        .then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: "/admin/published-post",
                    type: "get",
                    data: {
                        postId: postId
                    },
                    beforeSend: function () {
                        startLoading();
                    },
                    success: function (response) {
                        closeLoading();
                        if (response.status === "success") {
                            swal.fire("موفق", "عملیات با موفقیت انجام شد", "success");
                            $("#tbl-posts").load(location.href + " #tbl-posts");
                        } else {
                            swal.fire("خطا", "عملیات شکست خورد", "error");
                        }
                    },
                    error: function () {
                        closeLoading();
                    }
                });
            }
        });
}
