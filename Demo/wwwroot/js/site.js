
// Listening for change-event on radiobuttons on Create page and calling for relevant changes
function AdjustCreateForm(role) {
	LimitAvailRanks(role.value, 'create');
	LimitAvailManagers(role.value, 'create');
}

// Limiting available ranks
function LimitAvailRanks(role, page) {
	let rank = document.getElementById( page + 'RankDiv' );
	let str;

	if (role == "Employee") {
		str = '<input type="number" name="rank" min="1" max="5" value="1" class="form-control" />';
	} else if (role == "Manager") {
		str = '<input type="number" name="rank" min="6" max="9" value="6" class="form-control" />';
	} else if (role == "CEO") {
		str = '<input type="number" name="rank" min="10" max="10" value="10" class="form-control" />';
	}
	rank.innerHTML = str;
}

//Adjusting possible managers
function LimitAvailManagers(role, page) {
	let employee = document.getElementById( page + 'EmployeeSelect' );
	let manager = document.getElementById( page + 'ManagerSelect' );
	let ceo = document.getElementById( page + 'CeoSelect' );

	if (role.value == 'Employee') {
		employee.style.display = 'block';
		manager.style.display = 'none';
		ceo.style.display = 'none';
	} else if (role.value == 'Manager') {
		employee.style.display = 'none';
		manager.style.display = 'block';
		ceo.style.display = 'none';
	} else if (role.value == 'CEO') {
		employee.style.display = 'none';
		manager.style.display = 'none';
		ceo.style.display = 'block';
	}
}
