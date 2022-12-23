
// Listening for change-event on radiobuttons on Create page and calling for relevant changes
function AdjustForm(role) {
    LimitAvailRanks(role);
    LimitAvailManagers(role);
}

// Limiting available ranks
function LimitAvailRanks(role) {
    let rank = document.getElementById('rankDiv');
    let str;

    if (role.value == "Employee") {
        str = '<input type="number" min="1" max="5" value="1" class="form-control" />';
    } else if (role.value == "Manager") {
        str = '<input type="number" min="6" max="9" value="6" class="form-control" />';
    } else if (role.value == "CEO") {
        str = '<input type="number" min="10" max="10" value="10" class="form-control" />';
    }
    rank.innerHTML = str;
}

//Adjusting possible managers
function LimitAvailManagers(role) {
    let employee = document.getElementById("employeeSelect");
    let manager = document.getElementById("managerSelect");
    let ceo = document.getElementById("ceoSelect");

    if (role.value == "Employee") {
        employee.style.display = "block";
        manager.style.display = "none";
        ceo.style.display = "none";
    } else if (role.value == "Manager") {
        employee.style.display = "none";
        manager.style.display = "block";
        ceo.style.display = "none";
    } else if (role.value == "CEO") {
        employee.style.display = "none";
        manager.style.display = "none";
        ceo.style.display = "block";
    }
}