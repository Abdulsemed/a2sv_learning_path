select name as employee from employee where salary > (select salary from employee e where employee.managerId = e.id)
