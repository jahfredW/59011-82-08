select * from employee e inner join department d on e.department_id = d.id 
select d.id as departement_id, d."name" as  department_nom, e.last_name  from employee e inner join department d on e.department_id = d.id order by d.id
select e.last_name  from employee e inner join department d on e.department_id = d.id where d."name" = 'distribution'
select e.last_name , e.salary  from employee e inner join employee e2 on e.id = e2.superior_id where e.salary >= e2.salary 
select * from employee e inner join department d on e.department_id = d.id where d.id  in ( select id from department d where d."name" = 'finance' ) 
select * from employee e where e.title = ( select title  from employee e where e.last_name  = lower('amartakaldire') ) 
select e.last_name , e.salary, e.department_id  from employee e where e.salary > any   (select max(salary) from employee e where e.department_id = 31)
select e.last_name , e.salary, e.department_id  from employee e where e.salary > all  ( select salary from employee e where e.department_id = 31) order by department_id , salary
select e.last_name , e.title  from employee e where e.department_id  = 31 and  e.title in ( select title from employee e where e.department_id = 31)
select e.last_name , e.title  from employee e where e.department_id  = 31 and  e.title not in ( select title from employee e where e.department_id = 31)
select e.last_name , e.title , e.salary  from employee e where e.salary  = ( select salary from employee e where e.last_name  = 'fairent') and e.title = (select title from employee e where e.last_name = 'fairent')
select d.id , d."name" , e.last_name  from employee e  right join department d on e.department_id = d.id order by d.id 
select avg(e.salary) from employee e where title like 'secrétaire'
select e.title , count(e.id) from employee e group by e.title 
select avg(e.salary), count(e.salary) from employee e inner join department d on e.department_id  = d.id group by d.region_id 
select d.id  from employee e inner join department d on e.department_id  = d.id group by d.id  having count(e.id) > 2
select substring(e.last_name from 1 for 1 ) as letter, count(*) from employee e group by letter having count(*) > 2
select max(e.salary) as maxi, min(e.salary) as mini, (max(e.salary) - min(e.salary)) as ecart from employee e 
select count( distinct title) from employee e
select e.title, count(*) from employee e group by e.title  
select e.title, avg(e.salary) as moyenne from employee e group by e.title having avg(e.salary) > (select avg(e.salary) from employee e where e.title = 'représentant')
select count(e.salary) , count(e.commission_rate)  from employee e where e.commission_rate is not null and e.salary is not null