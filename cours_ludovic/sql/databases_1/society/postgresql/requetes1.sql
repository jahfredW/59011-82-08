select * from employee 
select last_name, hiring_date , superior_id , department_id , salary  from employee e 
select distinct title from employee e 
select title from employee e  
select * from employee e where salary  >= 25000
select e.last_name , e.id , e.department_id  from employee e where title like 'secrétaire'
select * from department d where d.id > 40
select e.first_name , e.last_name  from employee e where e.first_name < e.last_name 
select e.last_name, e.salary , e.department_id  from employee e where e.title = 'représentant' and e.department_id  = 35 and e.salary > 20000
select e.last_name , e.title  from employee e where e.title = 'représentant' or e.title = 'président'
select * from employee e where e.department_id = 34 and ( e.title = 'représentant' or e.title='secrétaire')
select e.last_name , e.title, e.department_id , e.salary from employee e where e.title = 'représentant' or ( e.title = 'secrétaire' and e.department_id = 34)
select e.last_name , e.salary  from employee e where e.salary >= 20000 and e.salary <= 30000
select e.last_name  from employee e where e.last_name  like 'h%'
select e.last_name  from employee e where e.last_name  like '%n'
select e.last_name  from employee e where e.last_name  like '__u%'
select e.salary , e.last_name  from employee e where e.department_id = 41 order by e.salary 
select e.salary , e.last_name  from employee e where e.department_id = 41 order by e.salary desc
select e.title, e.salary ,e.last_name  from employee e  order by e.salary desc,  e.title 
select e.commission_rate , e.salary , e.last_name  from employee e order by commission_rate
select e.commission_rate , e.salary , e.last_name  from employee e where commission_rate is null  
select e.commission_rate , e.salary , e.last_name  from employee e where commission_rate is not null 
select e.commission_rate , e.salary , e.last_name, e.title  from employee e where commission_rate <= 15
select e.commission_rate , e.salary , e.last_name, e.title  from employee e where commission_rate >= 15
select e.commission_rate , e.salary , e.last_name, e.commission_rate * e.salary as commission from employee e where e.commission_rate * e.salary  is not null
select e.last_name , e.salary , e.commission_rate , e.commission_rate * e.salary as commission from employee e where e.commission_rate  is not null order by e.commission_rate
select concat(e.last_name, e.first_name) as concat from employee e   
select substring(e.last_name, 1,3)  from employee e 
select position('r' in e.last_name) from employee e 
select * from employee e where e.last_name = lower('Vrante')
select length(e.last_name), e.last_name  from employee e 
