# Write your MySQL query statement below
select department.name as department, t.name as employee, t.salary as salary from department join(select name,e.departmentId,salary from employee e join(select departmentId, max(salary) as dsalary from employee group by departmentId) d on e.salary = dsalary and e.departmentId = d.departmentId) t where department.id = t.departmentId
