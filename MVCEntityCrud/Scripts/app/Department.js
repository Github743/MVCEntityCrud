function saveDepartment() {
    var formData = $('#departmentForm').serialize();
    $.ajax({
        url: '/Department/Save',
        type: 'POST',
        data: formData,
        success: function (response) {
            if (response.success) {
                $('#DepartmentModal').modal('hide');
                location.reload();
            } else {
                alert('Error updating Department.');
            }
        },
        error: function () {
            alert('Error updating Department.');
        }
    });
}

function openEditModal(DepartmentId) {
    if (DepartmentId !== '0') {
        $.get("/Department/Edit/" + DepartmentId, function (data) {
            $("#editModalContainer").html(data);
            $("#departmentModal").modal("show");
        });
    }
    else {
        $.get("/Department/Create/", function (data) {
            $("#editModalContainer").html(data);
            $("#departmentModal").modal("show");
        });
    }
}

function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Department/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                alert('Selected Department deleted');
                window.location.reload();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}