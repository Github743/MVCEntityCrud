function saveEmployee() {
    var formData = $('#employeeForm').serialize();

    $.ajax({
        url: '/Employee/Save',
        type: 'POST',
        data: formData,
        success: function (response) {
            if (response.success) {
                $('#employeeModal').modal('hide');
                location.reload(); 
            } else {
                alert('Error updating employee.');
            }
        },
        error: function () {
            alert('Error updating employee.');
        }
    });
}

function openEditModal(employeeId) {
    if (employeeId !== '0') {
        $.get("/Employee/Edit/" + employeeId, function (data) {
            $("#editModalContainer").html(data);
            $("#employeeModal").modal("show");
        });
    }
    else {
        $.get("/Employee/Create/", function (data) {
            $("#editModalContainer").html(data);
            $("#employeeModal").modal("show");
        });
    }
}

function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Employee/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                alert('Selected Employee deleted');
                window.location.reload();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

